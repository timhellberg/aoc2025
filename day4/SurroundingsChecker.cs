namespace day4;

public static class SurroundingsChecker
{
    private static readonly List<(int x, int y)> Directions = [
        (-1, 0), // left
        (-1, -1), // up left
        (0, -1), // up
        (1, -1), // up right
        (1, 0), // right
        (1, 1), // down right
        (0, 1), // down
        (-1, 1), // down left
    ];

    public static bool IsMovable(Dictionary<(int x, int y), char> map, (int x, int y) currentPos)
    {
        var surroundingWallsOfPaper = 0;
        foreach (var direction in Directions)
        {
            var positionToCheck = (currentPos.x + direction.x, currentPos.y + direction.y);
            if (map.TryGetValue(positionToCheck, out char value))
            {
                if (value == '@')
                {
                    surroundingWallsOfPaper++;
                }
            }
        }

        return surroundingWallsOfPaper < 4;
    } 
    
}