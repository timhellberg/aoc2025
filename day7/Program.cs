using day7;

using var reader = new StreamReader("input.txt");

var tachyonManifold = new TachyonManifold(reader);

tachyonManifold.InitiateBeam();
tachyonManifold.InitiateBeamTask2();

Console.WriteLine($"Task 1: {tachyonManifold.NumberOfSplits}");
Console.WriteLine($"Task 2: {tachyonManifold.NumberOfTimelines}");
