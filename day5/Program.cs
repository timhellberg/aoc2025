
using day5;

using var reader = new StreamReader("input.txt");


var readingFreshIngredients = true;
var freshIngredientRanges = new List<string>();
var availableIngredients = new List<string>();
while (!reader.EndOfStream)
{
    var line = reader.ReadLine()!;
    if (line == "")
    {
        readingFreshIngredients = false;
        continue;
    }

    if (readingFreshIngredients)
    {
        freshIngredientRanges.Add(line);
    }
    else
    {
        availableIngredients.Add(line);
    }
}

var ingredientChecker = new IngredientChecker(freshIngredientRanges);

var freshAvailableIngredients = availableIngredients.Count(ingredient => ingredientChecker.IsFreshIngredient(Int64.Parse(ingredient)));
var totalNumberOfFreshIngredients = ingredientChecker.GetTotalFreshIngredients();
Console.WriteLine($"Task 1: {freshAvailableIngredients}");
Console.WriteLine($"Task 2: {totalNumberOfFreshIngredients}");

