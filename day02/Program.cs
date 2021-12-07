using System.Diagnostics;

var sw = new Stopwatch();
sw.Start();

void GetPositionAndDepth(IEnumerable<string> instructions, out int position, out int depth, out int depthWrong)
{
    var aim = 0;
    position = 0;
    depth = 0;
    depthWrong = 0;

    foreach (var instruction in instructions)
    {
        var value = Convert.ToInt32(instruction.Last().ToString());
        if (instruction.StartsWith("d"))
        {
            aim += value;
            depthWrong += value;
        }
        else if (instruction.StartsWith("u"))
        {
            aim -= value;
            depthWrong -= value;
        }
        else
        {
            position += value;
            depth += aim * value;
        }        
    }
}

string filename = Environment.GetEnvironmentVariable("INPUT_DAY02_01") ??
                  Path.Combine(Environment.CurrentDirectory, "input.txt");
var text = File.ReadAllLines(filename);

GetPositionAndDepth(text, out var position, out var depth, out var depthWrong);
Console.WriteLine(position * depthWrong);
Console.WriteLine(position * depth);
sw.Stop();
Console.WriteLine("Time: {0}", sw.ElapsedTicks * 1000000L / Stopwatch.Frequency);