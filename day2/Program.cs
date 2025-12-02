using day2;

using StreamReader reader = new("input1.txt");

var input = reader.ReadToEnd();

var productIdRanges = input.Split(',');

var sum = productIdRanges.Sum(GetFalseIdsSumPart2);
Console.WriteLine(sum);

return;

long GetFalseIdsSum(string idRange)
{
    var startId = Int64.Parse(idRange.Split('-')[0]);
    var endId = Int64.Parse(idRange.Split('-')[1]);

    var falseIdsSum = 0L;

    for (long id = startId; id <= endId; id++)
    {
        var stringId = id.ToString();
        if (stringId.Length % 2 == 0) //
        {
            var firstPart = stringId.Substring(0, (stringId.Length / 2)); 
            var secondPart = stringId.Substring(stringId.Length / 2);

            if (firstPart == secondPart)
            {
                falseIdsSum += Int64.Parse(stringId);
            }
        }
    }
    return falseIdsSum;
}


long GetFalseIdsSumPart2(string idRange)
{
    var startId = Int64.Parse(idRange.Split('-')[0]);
    var endId = Int64.Parse(idRange.Split('-')[1]);

    var falseIdsSum = 0L;

    for (long id = startId; id <= endId; id++)
    {
        var stringId = id.ToString();
        var isFalseId = FalseIdFinder.IsFalseId(stringId);
        if (isFalseId)
        {
            falseIdsSum += Int64.Parse(stringId);
        }
    }
    return falseIdsSum;
}