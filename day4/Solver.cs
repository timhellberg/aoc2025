namespace day4;

public static class Solver
{
    public static int SolveTask1(Dictionary<(int x, int y), char> map)
    {
        var movableRolls = 0;
        foreach (var position in map)
        {
            if (position.Value == '@')
            {
                var isMovable = SurroundingsChecker.IsMovable(map, position.Key);
                if (isMovable)
                    movableRolls++;
            }
        } 
        return movableRolls;
    }
    
    public static int SolveTask2(Dictionary<(int x, int y), char> map)
    {
        var movableRolls = 0;
        var rollWasMoved = false;
        var keepGoing = true;
        while (keepGoing)
        {
            foreach (var position in map)
            {
                if (position.Value == '@')
                {
                    var isMovable = SurroundingsChecker.IsMovable(map, position.Key);
                    if (isMovable)
                    {
                        movableRolls++;
                        map[position.Key] = '.';
                        rollWasMoved = true;
                    }
                }
            }

            if (!rollWasMoved)
            {
                keepGoing = false; 
            }
            rollWasMoved = false;
        }
        
        return movableRolls;
    }
    
}