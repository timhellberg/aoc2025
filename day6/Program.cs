const string input = "testinput.txt";

using var reader = new StreamReader(input);

var operatorTokens = new List<string> { "*", "+" };

// Task 1
var numbers = new List<int[]>();
var operators = new List<string>();

while (!reader.EndOfStream)
{
    var line = reader.ReadLine();
    var tokens =   line!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (operatorTokens.Contains(tokens[0]))
    {
        foreach (var token in tokens)
        {
            operators.Add(token);
        }
        break;
    }
    
    var rowNumbers = tokens.Select(int.Parse).ToArray();
    numbers.Add(rowNumbers);
}

long totalSum = 0;
for (var i = 0; i < operators.Count; i++)
{
    bool isMultiplication = operators[i] == "*";
    var sum = isMultiplication ? 1L : 0L;
    foreach (var row in numbers)
    {
        if (isMultiplication)
            sum *= row[i];
        else
            sum += row[i];
    } 
    totalSum += sum;
}


// Task 2
using var reader2 = new StreamReader(input);

var problemLengths = new List<int>();
while (!reader2.EndOfStream)
{
    var line = reader2.ReadLine(); 
    if(operatorTokens.Contains(line!.First().ToString()))
    {
        var problemLength = 0;
        for(var i = 0; i < line!.Length; i++)
        {
            if (i + 1 == line.Length) 
            {
                problemLength++;
                problemLengths.Add(problemLength);
                break;
            }
            if (line[i] == ' ' && operatorTokens.Contains(line[i + 1].ToString())) 
            {
                problemLengths.Add(problemLength);
                problemLength = 0;
                continue;    
            }
            problemLength++;
        }
    }
}

using var reader3 = new StreamReader(input);

var numbersToOperateOn = new List<List<string>>();
for (var i = 0; i < operators.Count; i++)
{
    numbersToOperateOn.Add([]);
}

while (!reader3.EndOfStream)
{
    var line = reader3.ReadLine();
    if (operatorTokens.Contains(line!.First().ToString()))
    {
        break;
    }

    var index = 0;
    for (var i = 0; i < problemLengths.Count; i++)
    {
       var problemLength = problemLengths[i];
       var number = "";
       for (var j = 1; j <= problemLength; j++)
       {
           number += line![index];
           index++;
       }

       numbersToOperateOn[i].Add(number);
       index++;
    }
}

long totalSumTask2 = 0;
foreach (var (column, index) in numbersToOperateOn.Select((n, i) => (n, i)))
{
    var lengthOfNumbers = problemLengths[index];
    bool isMultiplication = operators[index] == "*";
    var sum = isMultiplication ? 1L : 0L;

    for (var i = 0; i < lengthOfNumbers; i++)
    {
        var newNumber = "";
        foreach (var number in column)
        {
            newNumber += number[i];
        }
        
        if (isMultiplication)
            sum *= Int64.Parse(newNumber);
        else
            sum += Int64.Parse(newNumber);
    }
    
    totalSumTask2 += sum;
}

Console.WriteLine($"Task 1: {totalSum}");
Console.WriteLine($"Task 2: {totalSumTask2}");
