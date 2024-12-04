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

    bool IsValid(string[] words, int x, int signX, int y, int signY)
    {
        return words[y + 1 * signY][x + 1 * signX] == 'M' &&
               words[y + 2 * signY][x + 2 * signX] == 'A' &&
               words[y + 3 * signY][x + 3 * signX] == 'S';
    }

    int WordSearch(string[] words, int x, int y)
    {
        var count = 0;
        var validRight = x + 3 < words[y].Length;
        var validLeft = x - 3 >= 0;
        var validTop = y >= 3;
        var validBottom = y < words.Length - 3;

        // Check Hor Right
        if (validRight && IsValid(words, x, 1, y, 0)) { count += 1; }
        // Check Hor Left
        if (validLeft && IsValid(words, x, -1, y, 0)) { count += 1; }
        // Check Ver Up
        if (validTop && IsValid(words, x, 0, y, -1)) { count += 1; }
        // Check Ver Down
        if (validBottom && IsValid(words, x, 0, y, 1)) { count += 1; }
        // Check Dia Up Right
        if (validTop && validRight && IsValid(words, x, 1, y, -1)) { count += 1; }
        //Check Dia Up Left
        if (validTop && validLeft && IsValid(words, x, -1, y, -1)) { count += 1; }
        //Check Dia Down Right
        if (validBottom && validRight && IsValid(words, x, 1, y, 1)) { count += 1; }
        //Check Dia Down Left
        if (validBottom && validLeft && IsValid(words, x, -1, y, 1)) { count += 1; }

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
