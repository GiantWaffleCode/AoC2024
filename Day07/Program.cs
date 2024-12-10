string path = @"C:\Repo\AoC2024\Inputs\Day07.txt";
string samplePath = @"C:\Repo\AoC2024\Inputs\Day07Sample.txt";

string[] input = File.ReadAllLines(samplePath);

int PartOne()
{
    foreach (string line in input)
    {
        var instruction = ParseLine(line);
    }
    
    int[] ParseLine(string instruction)
    {
        string[] parts = instruction.Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] resultArray = parts.Select(int.Parse).ToArray();
        
        return resultArray;
    }
    
    // [1,2,3,4,5]
    // 1+2+3+4+5
    
    // 1*2+3+4+5
    // 1+2*3+4+5
    // 1+2+3*4+5
    // 1+2+3+4*5
    
    // 1*2*3+4+5
    // 1*2+3*4+5
    // 1*2+3+4*5
    
    // 1+2*3*4+5
    // 1+2*3+4*5
    
    // 1+2+3*4*5
    
    // 1*2*3*4+5
    // 1*2*3+4*5
    // 1*2+3*4*4
    
    // 1+2*3*4*5
    
    
    // 1*2*3*4*5
    
    

    int DetermineOperators(int[] input)
    {
        var result = -1;
        
        
        
        return result;
    }
    
    
        
    
    return 0;
}

Console.WriteLine($"Part 1: {PartOne()}");

int PartTwo()
{
    return 0;
}

Console.WriteLine($"Part 2: {PartTwo()}");