using System.IO;
using System.Runtime.CompilerServices;

List<int> left = new List<int>();
List<int> right = new List<int>();
int totalDistance = 0;

try
{
    String? line;
    StreamReader sr = new StreamReader(@"C:/Repo/AoC2024/Inputs/Day01.txt");
    line = sr.ReadLine();

    while (!string.IsNullOrEmpty(line))
    {
        string[] parts = line.Split("   ");
        left.Add(int.Parse(parts[0]));
        right.Add(int.Parse(parts[1]));
        
        line = sr.ReadLine();
    }
    sr.Close();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

left.Sort();
right.Sort();

for (int i = 0; i < left.Count; i++)
{
    int diff = Math.Abs(left[i] - right[i]);
    totalDistance += diff;
}

Console.WriteLine($"Part 1: {totalDistance}");

int sim = 0;

foreach (int num in left)
{
    int count = 0;
    for (int i = 0; i < right.Count; i++)
    {
        if (right[i] == num)
        {
            count++;
        }
    }
    sim += num * count;
}

Console.WriteLine($"Part 2: {sim}");
