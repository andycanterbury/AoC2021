namespace AoC2021
{
    internal class Day9
    {
        public static int Puzzle1(string[] input)
        {
            var lowPoints = 0;

            var matrix = ParseInput(input);
            var rowMax = matrix.GetLength(0);
            var colMax = matrix.GetLength(1);
            for(int i = 0; i < rowMax; i++)
            {
                for(int j = 0; j < colMax; j++)
                {
                    var center = matrix[i, j];
                    if (i > 0)
                    {
                        //Check top neighbor
                        if (center >= matrix[i - 1, j]) continue;
                    }
                    if (i < rowMax - 1)
                    {
                        //Check bottom neighbor
                        if (center >= matrix[i + 1, j]) continue;
                    }
                    if (j > 0)
                    {
                        //Check left neighbor
                        if (center >= matrix[i, j - 1]) continue;
                    }
                    if (j < colMax - 1)
                    {
                        //Check right neighbor
                        if (center >= matrix[i, j + 1]) continue;
                    }
                    lowPoints += (1 + center);
                }

            }

            return lowPoints;
        }

        public static int Puzzle2(string[] input)
        {
            throw new NotImplementedException();
        }

        public static int[,] ParseInput(string [] input)
        {
            var matrix = new int[input.Length, input[0].Length];
            for(int i = 0; i < input.Length; i++)
            {
                for(int j = 0; j < input[i].Length; j++)
                {
                    matrix[i,j] = int.Parse(input[i][j].ToString());
                }
            }
            return matrix;
        }
    }
}
