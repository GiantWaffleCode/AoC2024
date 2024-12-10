string path = @"C:\Repo\AoC2024\Inputs\Day10.txt";
string samplePath = @"C:\Repo\AoC2024\Inputs\Day10Sample.txt";

string[] input = File.ReadAllLines(path);

var height = input.Length;
var width = input[0].Length;

int PartOne()
{
    List<List<int>> zeros = [];
    
    for (int y = 0; y < input.Length; y++)
    {
        for (int x = 0; x < input[0].Length; x++)
        {
            if (input[y][x] == '0')
            {
                List<int> start = [0, x, y];
                zeros.Add(start);
            }
        }
    }

    var ends = 0;

    foreach (List<int> zero in zeros)
    {
        Queue<List<int>> queue = [];
        queue.Enqueue(zero);

        List<(int, int)> endPoints = [];
        
        while (queue.TryDequeue(out List<int> item))
        {
            var num = item[0];
            var (x,y) = (item[1], item[2]);

            if (num == 9)
            {
                endPoints.Add((x,y));
                continue;
            }
            //Check N
            if (y - 1 >= 0)
            {
                if (input[y - 1][x] == num + 1 + '0')
                {
                    queue.Enqueue([num + 1, x, y - 1]);
                }
            }
            //Check E
            if (x + 1 < width)
            {
                if (input[y][x + 1] == num + 1 + '0')
                {
                    queue.Enqueue([num + 1, x + 1, y]);
                }
            }
            //Check S
            if (y + 1 < height)
            {
                if (input[y + 1][x] == num + 1 + '0')
                {
                    queue.Enqueue([num + 1, x, y + 1]);
                }
            }
            //Check W
            if (x - 1 >= 0)
            {
                if (input[y][x - 1] == num + 1 + '0')
                {
                    queue.Enqueue([num + 1, x - 1, y]);
                }
            }
        }
        ends += endPoints.Distinct().Count();
    }
    return ends;
}

Console.WriteLine($"Part 1: {PartOne()}");

int PartTwo()
{
    List<List<int>> zeros = [];
    
    for (int y = 0; y < input.Length; y++)
    {
        for (int x = 0; x < input[0].Length; x++)
        {
            if (input[y][x] == '0')
            {
                List<int> start = [0, x, y];
                zeros.Add(start);
            }
        }
    }

    var ends = 0;

    foreach (List<int> zero in zeros)
    {
        Queue<List<int>> queue = [];
        queue.Enqueue(zero);

        List<(int, int)> endPoints = [];
        
        while (queue.TryDequeue(out List<int> item))
        {
            var num = item[0];
            var (x,y) = (item[1], item[2]);

            if (num == 9)
            {
                endPoints.Add((x,y));
                continue;
            }
            //Check N
            if (y - 1 >= 0)
            {
                if (input[y - 1][x] == num + 1 + '0')
                {
                    queue.Enqueue([num + 1, x, y - 1]);
                }
            }
            //Check E
            if (x + 1 < width)
            {
                if (input[y][x + 1] == num + 1 + '0')
                {
                    queue.Enqueue([num + 1, x + 1, y]);
                }
            }
            //Check S
            if (y + 1 < height)
            {
                if (input[y + 1][x] == num + 1 + '0')
                {
                    queue.Enqueue([num + 1, x, y + 1]);
                }
            }
            //Check W
            if (x - 1 >= 0)
            {
                if (input[y][x - 1] == num + 1 + '0')
                {
                    queue.Enqueue([num + 1, x - 1, y]);
                }
            }
        }
        ends += endPoints.Count();
    }
    return ends;
}

Console.WriteLine($"Part 2: {PartTwo()}");