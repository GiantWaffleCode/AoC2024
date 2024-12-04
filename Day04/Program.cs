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
    for (int y = 0; y < readText.Length; y++)
    {
        for (int x = 0; x < readText[y].Length; x++)
        {
            if (readText[y][x] == 'A')
            {
                total += WordSearch(readText, x, y);
            }
        }

        int WordSearch(string[] words, int x, int y)
        {
            var count = 0;
            char topLeftChar;
            char topRightChar;
            char bottomLeftChar;
            char bottomRightChar;
            
            // Check Dia Up Right
            if (y >= 1 && x + 1 < words[y].Length)
            {
                topRightChar = words[y-1][x + 1];
                if (topRightChar == 'S' || topRightChar == 'M')
                {
                    if (y < words.Length - 1 && x - 1 >= 0)
                    {
                        bottomLeftChar = words[y + 1][x - 1];
                        if (topRightChar == 'S' && bottomLeftChar == 'M') { count++; }
                        if (topRightChar == 'M' && bottomLeftChar == 'S') { count++; }
                    }
                }
            }
            // Check Dia Down Right
            if (y < words.Length - 1 && x + 1 < words[y].Length)
            {
                bottomRightChar = words[y+1][x + 1];
                if (bottomRightChar == 'S' || bottomRightChar == 'M')
                {
                    if (y >= 1 && x - 1 >= 0)
                    {
                        topLeftChar = words[y - 1][x - 1];
                        if (topLeftChar == 'S' && bottomRightChar == 'M') { count++; }
                        if (topLeftChar == 'M' && bottomRightChar == 'S') { count++; }
                    }
                }
            }
            return count == 2 ? 1 : 0;
        }
    }
    return total;
}

Console.WriteLine($"Part 2: {PartTwo()}");
