string path = @"C:\Repo\AoC2024\Inputs\Day09.txt";
string samplePath = @"C:\Repo\AoC2024\Inputs\Day09Sample.txt";

int[] input = File.ReadAllText(path).ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();

long PartOne()
{
    List<int> Generate(int[] input) // Expand Compressed Input
    {
        List<int> result = new List<int>();
        int itemCount = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 0) // Data
            {
                for (int j = 0; j < input[i]; j++)
                {
                    result.Add(itemCount);
                }

                itemCount++;
            }
            else
            {
                for (int j = 0; j < input[i]; j++)
                {
                    result.Add(-1);
                }
            }
        }
        return result;
    }

    List<int> Compress(List<int> input)
    {
        int firstSpaceIndex = 0;
        int lastItemIndex = 1;

        while (firstSpaceIndex <= lastItemIndex)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == -1)
                {
                    firstSpaceIndex = i;
                    break;
                }
            }
            for (int i = input.Count - 1; i >= 0; i--)
            {
                if (input[i] != -1)
                {
                    lastItemIndex = i;
                    break;
                }
            }

            if (firstSpaceIndex < lastItemIndex)
            {
                (input[firstSpaceIndex], input[lastItemIndex]) = (input[lastItemIndex], input[firstSpaceIndex]);
            }
        }
        return input;
    }

    long CheckSum(List<int> input)
    {
        long total = 0;
        for (int i = 0; i < input.Count; i++)
        {
            if (input[i] != -1)
            { 
                total += i * input[i];
            }
        }
        
        return total;
    }
    
    var expandedList = Generate(input);
    var compressedList = Compress(expandedList);
    
    return CheckSum(compressedList);
}

Console.WriteLine($"Part 1: {PartOne()}");

int PartTwo()
{
    return 0;
}

Console.WriteLine($"Part 1: {PartTwo()}");