using System.Text.RegularExpressions;

string path = @"C:\Repo\AoC2024\Inputs\Day03.txt";
string samplePath = @"C:\Repo\AoC2024\Inputs\Day03Sample.txt";

string readText = File.ReadAllText(path);


int PartOne() {
    string pat = @"mul\((?<a>\d{1,3}),(?<b>\d{1,3})\)";

    Regex r = new Regex(pat);
    var m = r.Matches(readText);

    int total = 0;
    for (int i = 0; i < m.Count; i++)
    {
        int a = int.Parse(m[i].Groups["a"].Value);
        int b = int.Parse(m[i].Groups["b"].Value);
        total += a * b;
    }
    return total;
}

Console.WriteLine($"Part 1: {PartOne()}");

int PartTwo()
{
    string pat = @"mul\((?<a>\d{1,3}),(?<b>\d{1,3})\)|do\(\)|don't\(\)";
    
    Regex r = new Regex(pat);
    var m = r.Matches(readText);

    int total = 0;
    bool active = true;
    
    for (int i = 0; i < m.Count; i++)
    {
        switch (m[i].Value)
        {
            case "don't()":
                active = false;
                break;
            case "do()":
                active = true;
                break;
            default:
                if (active)
                {
                    int a = int.Parse(m[i].Groups["a"].Value);
                    int b = int.Parse(m[i].Groups["b"].Value);
                    total += a * b;
                }
                break;
        }
        
    }
    return total;
}

Console.WriteLine($"Part 2: {PartTwo()}");