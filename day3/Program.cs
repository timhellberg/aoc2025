using day3;

var reader = new StreamReader("input1.txt");

var batterySum = 0L;
var batteriesPerBank = 12;
while (!reader.EndOfStream)
{
    var batteryBank = reader.ReadLine();
    batterySum += JoltageFinder.FindJoltage(batteryBank!, batteriesPerBank);
}

Console.WriteLine(batterySum);