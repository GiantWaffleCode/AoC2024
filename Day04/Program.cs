string path = @"C:\Repo\AoC2024\Inputs\Day04.txt";
string samplePath = @"C:\Repo\AoC2024\Inputs\Day04Sample.txt";

string[] readText = File.ReadAllLines(path);

int PartOne()
{
    var total = 0;
    for (int y = 0; y < readText.Length; y++)
    {
        for (int x = 0; x < readText[y].Length; x++)
        {
            if (readText[y][x] == 'X')
            {
                total += WordSearch(readText, x, y);
            }
        }
    }
    
    int WordSearch(string[] words, int x, int y)
    {
        var count = 0;

        // Check Hor Right
        if (x + 3 < words[y].Length &&
            words[y][x + 1] == 'M' &&
            words[y][x + 2] == 'A' &&
            words[y][x + 3] == 'S') { count += 1; }
        // Check Hor Left
        if (x - 3 >= 0 &&
            words[y][x - 1] == 'M' &&
            words[y][x - 2] == 'A' &&
            words[y][x - 3] == 'S') { count += 1; }
        // Check Ver Up
        if (y >= 3 &&
            words[y - 1][x] == 'M' &&
            words[y - 2][x] == 'A' &&
            words[y - 3][x] == 'S') { count += 1; }
        // Check Ver Down
        if (y < words.Length - 3 &&
            words[y + 1][x] == 'M' &&
            words[y + 2][x] == 'A' &&
            words[y + 3][x] == 'S') { count += 1; }
        // Check Dia Up Right
        if (y >= 3 &&
            x + 3 < words[y].Length &&
            words[y - 1][x + 1] == 'M' &&
            words[y - 2][x + 2] == 'A' &&
            words[y - 3][x + 3] == 'S') { count += 1; }
        //Check Dia Up Left
        if (y >= 3 &&
            x - 3 >= 0 &&
            words[y - 1][x - 1] == 'M' &&
            words[y - 2][x - 2] == 'A' &&
            words[y - 3][x - 3] == 'S') { count += 1; }
        //Check Dia Down Right
        if (y < words.Length - 3 &&
            x + 3 < words[y].Length &&
            words[y + 1][x + 1] == 'M' &&
            words[y + 2][x + 2] == 'A' &&
            words[y + 3][x + 3] == 'S') { count += 1; }
        //Check Dia Down Left
        if (y < words.Length - 3 &&
            x - 3 >= 0 &&
            words[y + 1][x - 1] == 'M' &&
            words[y + 2][x - 2] == 'A' &&
            words[y + 3][x - 3] == 'S') { count += 1; }
        
        return count;
    }
    return total;
}

Console.WriteLine($"Part 1: {PartOne()}");

int PartTwo()
{
    var total = 0;
    for (int y = 1; y < readText.Length - 1; y++)
    {
        for (int x = 1; x < readText[y].Length - 1; x++)
        {
            if (readText[y][x] == 'A')
            {
                total += WordSearch(readText, x, y);
            }
        }
    }

    int WordSearch(string[] words, int x, int y)
    {
        var count = 0;
        var topLeftChar = words[y - 1][x - 1];
        var topRightChar = words[y - 1][x + 1];
        var bottomLeftChar = words[y + 1][x - 1];
        var bottomRightChar = words[y + 1][x + 1];

        if ((topLeftChar, bottomRightChar) is ('M', 'S') or ('S', 'M')) count++;
        if ((topRightChar, bottomLeftChar) is ('M', 'S') or ('S', 'M')) count++;

        return count == 2 ? 1 : 0;
    }
    return total;
}

Console.WriteLine($"Part 2: {PartTwo()}");
