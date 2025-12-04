using day4;

using var input = new StreamReader("input1.txt");

var map = new Dictionary<(int x, int y), char>();

var row = 0;
while (!input.EndOfStream)
{
    var line = input.ReadLine();
    var column = 0;
    foreach (var c in line!)
    {
        map[(column, row)] = c;
        column++;
    }
    row++;
}

var movableRolls = Solver.SolveTask2(map);

Console.WriteLine(movableRolls);

