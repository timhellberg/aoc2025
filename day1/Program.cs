using StreamReader reader = new("input1.txt");

var timesLandingOnZero = 0;
var timesPointingOnZero = 0;
var currentDial = 50;

while (!reader.EndOfStream)
{
    var dialRotation = reader.ReadLine()!;
    var direction = dialRotation[0];
    var amount =  Convert.ToInt32(dialRotation[1..]);
    timesPointingOnZero += CountZeroPasses(currentDial, amount, direction);

    switch (direction)
    {
        case 'R':
            currentDial += amount;
            break;
        case 'L':
            currentDial -= amount;
            break;
    }

    currentDial = NormalizeDial(currentDial);
    if (currentDial == 0)
    {
        timesLandingOnZero++;
        timesPointingOnZero++;
    }
}

Console.WriteLine($"Task 1 answer: {timesLandingOnZero}");
Console.WriteLine($"Task 2 answer: {timesPointingOnZero}");
return;


int NormalizeDial(int dial)
{
    if (dial < 0)
    {
        if (Math.Abs(dial) % 100 == 0)
            return 0;
        
        return 100 - Math.Abs(dial) % 100;
    }

    return dial % 100;
}

int CountZeroPasses(int dial, int rotationAmount, char rotationDirection)
{
    var passes = 0;
    while (rotationAmount > 100)
    {
       rotationAmount -= 100;
       passes++;
    }

    switch (rotationDirection)
    {
        case 'R':
            dial += rotationAmount;
            if (dial > 100)
                passes++;
            break;
        case 'L':
            if (dial != 0)
            {
               dial -= rotationAmount; 
               if (dial < 0)
                   passes++;
            }
            break;
    }
    
    return passes;
}
