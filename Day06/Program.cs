string path = @"C:\Repo\AoC2024\Inputs\Day06.txt";
string samplePath = @"C:\Repo\AoC2024\Inputs\Day06Sample.txt";

char[][] map = File.ReadAllLines(path).Select(x => x.ToCharArray()).ToArray();

// ["....#....."]   map[0][4]

int PartOne()
{
    //Get Starting Position
    (int x, int y) startPos = (0, 0);
    for (int y = 0; y < map.Length; y++)
    {
        for (int x = 0; x < map[y].Length; x++)
        {
            if (map[y][x] == '^')
            {
                startPos = (x, y);
            }
        }
    }

    var dir = 'N';
    map[startPos.y][startPos.x] = 'X';
    var width = map[0].Length;
    var height = map.Length;

    (int, int, char) Step(int x, int y, char dir)
    {
        (int x, int y) newPos = (x, y);
        (int x, int y) checkPos = (0, 0);
        var newDir = dir;
        char[] symbolCheck = ['X', '.'];
        switch (dir) //move
        {
            case 'N':
            {
                if (y - 1 < 0) //Out of Bound Check
                {
                    newPos = (-1, -1);
                    break;
                }
                checkPos = (x, y - 1);
                if (symbolCheck.Contains(map[checkPos.y][checkPos.x])) // X or .
                {
                    newPos = (x, y - 1);
                    map[newPos.y][newPos.x] = 'X';
                    break;
                }
                if (map[checkPos.y][checkPos.x] == '#')
                {
                    newDir = 'E';
                    break;
                }
                break;
            }
            case 'E':
            {
                if (x + 1 >= width) //Out of Bound Check
                {
                    newPos = (-1, -1);
                    break;
                }
                checkPos = (x + 1, y);
                if (symbolCheck.Contains(map[checkPos.y][checkPos.x])) // X or .
                {
                    newPos = (x + 1, y);
                    map[newPos.y][newPos.x] = 'X';
                    break;
                }
                if (map[checkPos.y][checkPos.x] == '#')
                {
                    newDir = 'S';
                    break;
                }
                break;
            }
            case 'S':
            {
                if (y + 1 >= height) //Out of Bound Check
                {
                    newPos = (-1, -1);
                    break;
                }
                checkPos = (x, y + 1);
                if (symbolCheck.Contains(map[checkPos.y][checkPos.x])) // X or .
                {
                    newPos = (x, y + 1);
                    map[newPos.y][newPos.x] = 'X';
                    break;
                }
                if (map[checkPos.y][checkPos.x] == '#')
                {
                    newDir = 'W';
                    break;
                }
                break;
            }
            case 'W':
            {
                if (x - 1 < 0) //Out of Bound Check
                {
                    newPos = (-1, -1);
                    break;
                }
                checkPos = (x - 1 , y);
                if (symbolCheck.Contains(map[checkPos.y][checkPos.x])) // X or .
                {
                    newPos = (x - 1, y);
                    map[newPos.y][newPos.x] = 'X';
                    break;
                }
                if (map[checkPos.y][checkPos.x] == '#')
                {
                    newDir = 'N';
                    break;
                }
                break;
            }
        }
        return (newPos.x, newPos.y, newDir);
    }
    
    (int x, int y, char dir) curPos = (startPos.x, startPos.y, dir);

    while (curPos.x != -1)
    {
        curPos = Step(curPos.x, curPos.y, curPos.dir);
    }

    int count = 0;
    foreach (var line in map)
    {
        count += line.Count(x => x == 'X');
    }
    
    return count;
}

Console.WriteLine($"Part 1: {PartOne()}");

int PartTwo()
{
    return 0;
}

Console.WriteLine($"Part 2: {PartTwo()}");