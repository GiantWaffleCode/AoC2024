string path = @"C:\Repo\AoC2024\Inputs\Day02.txt";
string samplePath = @"C:\Repo\AoC2024\Inputs\Day02Sample.txt";

string[] readText = File.ReadAllLines(path);
int[][] input = new int[readText.Length][];
var counter = 0;

foreach (string line in readText)
{
    input[counter] = (line.Split(" ").Select(int.Parse).ToArray());
    counter++;
}

// for (int i = 0; i < input.Length; i++)
// {
//     Console.WriteLine(string.Join(" ",input[i]));
// }

int PartOne()
{
    var lines = new List<bool>();

    for (int i = 0; i < input.Length; i++)
    {
        var line = new List<int>();
        for (int j = 0; j < input[i].Length-1; j++)
        {
            int a = input[i][j];
            int b = input[i][j + 1];
            line.Add(IsValid(a,b));
        }

        if (line.Contains(0))
        {
            lines.Add(false);
        }
        else if (line.Distinct().Count() == 1)
        {
            lines.Add(true);
        }
        else
        {
            lines.Add(false);
        }
    }

    return lines.Count(x => x);
}

// for (int i = 0; i < lines.Count; i++)
// {
//     Console.WriteLine(string.Join(" ",lines[i]));
// }

Console.WriteLine("Part 1: " + PartOne());

int PartTwo()
{
    var lines = new List<bool>();
    for (int i = 0; i < input.Length; i++)
    {
        bool check = CheckList(input[i].ToList());
        if (!check)
        {
            check = DoubleCheckList(input[i].ToList());
        }
        //Console.WriteLine(check);
        lines.Add(check);
    }
    return lines.Count(x => x);
}
Console.WriteLine("Part 2: " + PartTwo());



bool CheckList(List<int> list) // <0,0,-1,1,-1>
{
    var line = new List<int>();
    for (int j = 0; j < list.Count-1; j++)
    {
        int a = list[j];
        int b = list[j + 1];
        line.Add(IsValid(a,b));
    }
    return !line.Contains(0) && line.Distinct().Count() == 1;
}

bool DoubleCheckList(List<int> list) // <1,2,3,4,5> <2,3,4,5> <1,3,4,5> <1,2,4,5>
{
    var lines = new List<bool>();
    
    for (int i = 0; i < list.Count; i++)
    {
        var modList = new List<int>(list);
        modList.RemoveAt(i);
        lines.Add(CheckList(modList));
    }
    return lines.Contains(true);
}

int IsValid(int a, int b)
{
    int diff = a - b;
    
    if (diff == 0) //Inputs are Equal
    {
        return 0;
    }
    else if (diff < 0 && Math.Abs(diff) <= 3) // Inputs are Increasing
    {
        return 1;
    }
    else if (diff > 0 && Math.Abs(diff) <= 3) // Inputs and Decreasing
    {
        return -1;
    }
    else
    {
        return 0;
    }
}