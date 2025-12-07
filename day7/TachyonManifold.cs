using System.Numerics;

namespace day7;

public class TachyonManifold
{
    private readonly Dictionary<string, Complex> _directions = new()
    {
        { "left", new Complex(-1, 0) },
        { "right", new Complex(1, 0) },
        { "down", new Complex(0, 1) },
    };
    private Dictionary<Complex, char> Map { get; } = new();
    private Complex StartPosition { get; }
    public int NumberOfSplits { get; set; }
    public int NumberOfBeamsReachingTheEnd { get; set; }
    public long NumberOfTimelines { get; set; }
    private readonly Dictionary<(Complex position, Complex direction), long> _memo = new();


    public TachyonManifold(StreamReader reader)
    {
        var iPosition = 0;
        while (!reader.EndOfStream)
        {
            var line =  reader.ReadLine();
            foreach (var (c, index) in line!.Select((c, i) =>  (c, i )))
            {
                var position = new Complex(index, iPosition);
                if(c == 'S')
                    StartPosition = position;
                Map[position] = c;
            }
            iPosition++;
        }
    }

    public void InitiateBeam()
    {
        var beamPositions = new HashSet<Complex>()
        {
            StartPosition
        };

        var reachedEnd = false;
        while (!reachedEnd)
        {
            var newBeamPositions = new HashSet<Complex>();
            foreach (var beamPosition in beamPositions)
            {
                var nextPosition = beamPosition + _directions["down"];
                
                var positionInMap = Map.TryGetValue(nextPosition, out var token);
                if (!positionInMap)
                    continue;

                if (token == '^')
                { 
                    NumberOfSplits++;
                    newBeamPositions.Add(beamPosition + _directions["right"] + _directions["down"]); 
                    newBeamPositions.Add(beamPosition + _directions["left"] + _directions["down"]); 
                }
                else if (token == '.')
                {
                    newBeamPositions.Add(beamPosition + _directions["down"]);
                }
            }

            if (beamPositions.All(x => !Map.ContainsKey(x + _directions["down"])))
            {
                reachedEnd = true;
                NumberOfBeamsReachingTheEnd = beamPositions.Count;
            }

            beamPositions = newBeamPositions;
        }
        
    }
    
    public void InitiateBeamTask2()
    {
        NumberOfTimelines = CountPaths(StartPosition, _directions["down"]);
    }

    private long CountPaths(Complex position, Complex direction)
    {
        while (true)
        {
            var key = (position, direction);
            if (_memo.TryGetValue(key, out var paths))
            {
                return paths;
            }
            var nextPosition = position + direction;
            
            if (!Map.ContainsKey(nextPosition))
            {
                _memo[key] = 1L;
                return 1L;
            }
            
            position = nextPosition;
            
            if (Map[position] == '^')
            {
                long leftPaths = CountPaths(position, _directions["left"]);
                long rightPaths = CountPaths(position, _directions["right"]);
                long result = leftPaths + rightPaths;
                _memo[key] = result;
                return result;
            }
            
            direction = _directions["down"];
        }
    }

}