namespace AoC2021
{
    internal class Day2
    {
        public static int Puzzle1(string[] input)
        {
            var horizPos = 0;
            var verticalPos = 0;

            foreach(var command in input)
            {
                var cmdParts = command.Split(' ');
                switch (cmdParts[0])
                {
                    case "forward":
                        horizPos += int.Parse(cmdParts[1]);
                        break;
                    case "down":
                        verticalPos += int.Parse(cmdParts[1]);
                        break;
                    case "up":
                        verticalPos -= int.Parse(cmdParts[1]);
                        break;
                }

            }
            return horizPos * verticalPos;
        }

        public static int Puzzle2(string[] input)
        {
            var horizPos = 0;
            var verticalPos = 0;
            var aim = 0;

            foreach (var command in input)
            {
                var cmdParts = command.Split(' ');
                var cmd = cmdParts[0];
                var value = int.Parse(cmdParts[1]);
                switch (cmd)
                {
                    case "forward":
                        horizPos += value;
                        verticalPos += aim * value;
                        break;
                    case "down":
                        aim += value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                }

            }
            return horizPos * verticalPos;
        }
    }
}
