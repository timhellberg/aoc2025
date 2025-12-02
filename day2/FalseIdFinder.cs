namespace day2;

public static class FalseIdFinder
{
    public static bool IsFalseId(string id)
    {
        var isFalseId = false;
        for (var subStringLength = 2; subStringLength <= id.Length; subStringLength++)
        {
           isFalseId = CheckIfFalseIdForSubstringSize(id, subStringLength);

           if (isFalseId)
               return isFalseId;
        }
        
        return isFalseId;;
    }

    private static bool CheckIfFalseIdForSubstringSize(string id, int nrOfSubstrings)
    {
        if (id.Length % nrOfSubstrings != 0)
        {
            return false;
        }
        
        var parts = new string[nrOfSubstrings];
        var stringSize = id.Length / nrOfSubstrings;
        var stringStartIndex = 0;
        
        for (var i = 0; i < nrOfSubstrings; i++)
        {
            parts[i] = id.Substring(stringStartIndex, stringSize);
            stringStartIndex += stringSize; 
        }

        for (var i = 1; i < parts.Length; i++)
        {
            if(parts[i] != parts[i-1])
                return false;
        }

        return true;
    }
}