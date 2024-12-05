string path = @"C:\Repo\AoC2024\Inputs\Day05.txt";
string samplePath = @"C:\Repo\AoC2024\Inputs\Day05Sample.txt";

string[] readText = File.ReadAllLines(path);

int PartOne()
{
    Dictionary<int, List<int>> map = [];
    List<List<int>> inputs = [];

    foreach (string line in readText)
    {
        if (line.Contains('|'))
        {
            var parts = line.Split('|').Select(int.Parse).ToList();
            if (!map.TryGetValue(parts[0], out var list))
            {
                list = [];
                map[parts[0]] = list;
            }
            list.Add(parts[1]);
        }
        if (line.Contains(','))
        {
            inputs.Add(line.Split(',').Select(int.Parse).ToList());
        }
    }
    // [75,47,61,53,29]
    // 75 Skip First
    // 47 Look Backwards at rules, Check X for 47, See if any Y Values are before
    
    // 47: [53]
    // 97: [13,61,47]
    // 75: [29]
    
    List<List<int>> validLists = [];

    foreach (List<int> input in inputs)
    {
        bool valid = true;
        for (int i = 1; i < input.Count; i++)
        {
            var mainVal = input[i];
            if (map.ContainsKey(mainVal))
            {
                var checkList = map[mainVal];
                for (int j = i-1; j >= 0; j--) // [61,13,29]
                {
                    var compareVal = input[j];
                    if (checkList.Contains(compareVal)) { valid = false; break; }
                }
            }
        }
        if (valid)
        {
            validLists.Add(input);
        }
    }
    var total = 0;
    foreach (var list in validLists)
    {
        var middle = list.Count / 2;
        total += list[middle];
    }
    return total;
}

Console.WriteLine($"Part 1: {PartOne()}");

int PartTwo()
{
    Dictionary<int, List<int>> map = [];
    List<List<int>> inputs = [];

    foreach (string line in readText)
    {
        if (line.Contains('|'))
        {
            var parts = line.Split('|').Select(int.Parse).ToList();
            if (!map.TryGetValue(parts[0], out var list))
            {
                list = [];
                map[parts[0]] = list;
            }
            list.Add(parts[1]);
        }
        if (line.Contains(','))
        {
            inputs.Add(line.Split(',').Select(int.Parse).ToList());
        }
    }
    
    List<List<int>> validLists = [];

    foreach (List<int> input in inputs)
    {
        bool valid = false;
        bool swapped = false;
        bool wasSwapped = false;
        while (!valid)
        {
            for (int i = 1; i < input.Count; i++)
            {
                swapped = false;
                var mainVal = input[i];
                if (map.ContainsKey(mainVal))
                {
                    var checkList = map[mainVal];
                    for (int j = i-1; j >= 0; j--) // [61,13,29]
                    {
                        var compareVal = input[j];
                        if (checkList.Contains(compareVal)) // incorrect
                        {
                            (input[i], input[j]) = (input[j], input[i]);
                            swapped = true;
                            wasSwapped = true;
                            break;
                        }
                    }
                }
                if (swapped) { break;}
            }
            if (!swapped) { valid = true; }
        }
        if (wasSwapped) { validLists.Add(input); }
    }
    var total = 0;
    foreach (var list in validLists)
    {
        var middle = list.Count / 2;
        total += list[middle];
    }
    return total;
}

Console.WriteLine($"Part 2: {PartTwo()}");