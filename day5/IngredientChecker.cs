namespace day5;

public class IngredientChecker
{
    private Dictionary<Guid, (long min, long max)> FreshIngredients { get; set; } = new();
    public IngredientChecker(List<string> ingredientRanges)
    {
        List<(long firstNumber, long secondNumber)> sortedRanges = [];

        foreach (var ingredientRange in ingredientRanges)
        {
            var firstNumber = Int64.Parse(ingredientRange.Split("-")[0]);
            var secondNumber = Int64.Parse(ingredientRange.Split("-")[1]);
            sortedRanges.Add((firstNumber, secondNumber));
        }
        sortedRanges.Sort();
        
        foreach (var range in sortedRanges)
        {
            var updatedExistingEntry = false;
            var redundantRange = false;

            foreach (var keyValuePair in FreshIngredients)
            {
                var current = keyValuePair.Value;
                if (range.firstNumber >= current.min && range.secondNumber <= current.max)
                {
                    redundantRange = true;
                    break;
                }
                
                if (range.firstNumber < current.min && range.secondNumber >= current.min)
                {
                    updatedExistingEntry = true;
                    current.min = range.firstNumber;
                }

                if (range.firstNumber <= current.max && range.secondNumber > current.max)
                {
                    updatedExistingEntry = true; 
                    current.max = range.secondNumber;
                }

                if (updatedExistingEntry)
                {
                    FreshIngredients[keyValuePair.Key] = current;
                    break;
                }
            }

            if (!updatedExistingEntry && !redundantRange)
            {
                FreshIngredients[Guid.NewGuid()] = (range.firstNumber, range.secondNumber);
            }
         
        }
      
    }

    public bool IsFreshIngredient(long ingredient)
    {
        return FreshIngredients.Any(range => ingredient >= range.Value.min && ingredient <= range.Value.max);
    }

    public long GetTotalFreshIngredients()
    {
        return FreshIngredients.Values.Sum(range => range.max - range.min + 1);
    }
}