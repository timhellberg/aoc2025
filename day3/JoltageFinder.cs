namespace day3;

public static class JoltageFinder
{
    public static long FindJoltage(string batteryBank, int batteries)
    {
        var startPosition = 0;
        var joltage = "";
        
        while (batteries > 0)
        {
            (var batteryMax, startPosition) = FindMaxNumber(batteryBank, startPosition, batteries-1);
            joltage += batteryMax;
            batteries--;
        }
        
        return Int64.Parse(joltage);
    }

    private static (string, int) FindMaxNumber(string batteryBank, int startPosition, int endLimit)
    {
        var maxNumber = 9;
        bool foundMaxNumber = false;
        while (!foundMaxNumber)
        {
            for (var i = startPosition; i < batteryBank.Length - endLimit; i++)
            { 
                int battery = batteryBank[i] - '0';
                if (battery == maxNumber)
                {
                    startPosition = i+1;
                    foundMaxNumber = true;
                    break;
                }
            }

            if(!foundMaxNumber)
                maxNumber--;
        }
        
        return (maxNumber.ToString(),  startPosition);
    }
}