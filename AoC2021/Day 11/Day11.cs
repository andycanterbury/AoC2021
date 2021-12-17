namespace AoC2021
{
    internal class Day11
    {
        public static int Puzzle1(string[] input)
        {
            var flashes = 0;
            var steps = 100;
            var matrix = BuildMatrix(input);
            for(var i = 0; i < steps; i++)
            {
                matrix = IncreaseLevel(matrix);
                matrix = HandleFlashes(matrix);
            }

            return flashes;
        }

        public static int Puzzle2(string[] input)
        {
            throw new NotImplementedException();
        }

        private static List<List<int>> BuildMatrix(string[] input)
        {
            var matrix = new List<List<int>>();
            foreach(var line in input)
            {
                var newLine = line.Select(x => int.Parse(x.ToString())).ToList();
                matrix.Add(newLine);
            }

            return matrix;
        }

        private static List<List<int>> IncreaseLevel(List<List<int>> matrix)
        {
            for(int i=0; i< matrix.Count; i++)
            {
                matrix[i] = matrix[i].Select(x => x + 1).ToList();
            }
            return matrix;
        }

        private static List<List<int>> HandleFlashes(List<List<int>> matrix)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i].Any(s => s > 9))
                {
                    
                }
                var flashers = matrix[i].IndexOf();
            }
            return matrix;
        }

        private static List<List<int>> IncreaseNeighbors(List<List<int>> matrix, int x, int y)
        {
            int startx = (x > 0) ? x - 1 : 0;
            int starty = (y > 0) ? y - 1 : 0;
            int endx = (x < matrix.Count - 1) ? x + 1 : x;
            int endy = (y < matrix[x].Count - 1) ? y + 1 : y;

            for(int i = startx; i < endx; i++)
            {
                for (int j = starty; j < endy; j++)
                {
                    if (i != x && j != y)
                    {
                        matrix[i][j]++;
                        if (matrix[i][j] == 10)
                        {
                            matrix = IncreaseNeighbors(matrix, i, j);
                        }
                    }
                }
            }
            return matrix;
        }
    }
}
