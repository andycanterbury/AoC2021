namespace AoC2021
{
    internal class Day1
    {
        public static int Puzzle1(string[] input)
        {
            var depthIncreases = 0;
            int prevDepth = int.Parse(input[0]);
            foreach(var depth in input)
            {
                var newDepth = int.Parse(depth);
                if (newDepth > prevDepth)
                {
                    depthIncreases++;
                }
                prevDepth = newDepth;
            }
            return depthIncreases;
        }

        public static int Puzzle2(string[] input)
        {
            var depthIncreases = 0;
            int prevWindow = int.Parse(input[0]) + int.Parse(input[1]) + int.Parse(input[2]);
            for (int i = 1; i < input.Length-2; i++)
            {
                int currWindow = int.Parse(input[i]) + int.Parse(input[i + 1]) + int.Parse(input[i + 2]);
                if (currWindow > prevWindow)
                {
                    depthIncreases++;
                }
                prevWindow = currWindow;
            }
            return depthIncreases;
        }
    }
}
