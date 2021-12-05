using System.Diagnostics;

var sw = new Stopwatch();
sw.Start();

int GetNumberOfIncreases(List<int> values)
{
    int counter = 0;
    int temp = values.First();
    for (int i = 1; i < values.Count; i++)
    {
        if (values[i] > temp) counter++;
        temp = values[i];
    }
    return counter;
}

int GetNumberOfIncreasesSliding(List<int> values)
{
    var counter = 0;
    var temp = values[0] + values[1] + values[2];
    for (int i = 1; i < values.Count - 2; i++)
    {
        var cur = values.Skip(i).Take(3).Sum();
        if (cur > temp) counter++;
        temp = cur;
    }
    return counter;
}

string filename = Environment.GetEnvironmentVariable("INPUT_DAY01_01") ??
                  Path.Combine(Environment.CurrentDirectory, "input.txt");
var text = File.ReadAllLines(filename);

List<int> input = text.Select(int.Parse).ToList();

Console.WriteLine(GetNumberOfIncreases(input));
Console.WriteLine(GetNumberOfIncreasesSliding(input));
sw.Stop();
Console.WriteLine("Time: {0}", sw.ElapsedTicks * 1000000L / Stopwatch.Frequency);
