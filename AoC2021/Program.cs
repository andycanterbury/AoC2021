namespace AoC2021
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: AOC20201 puzzleNumber inputFilePath");
                return;
            }
            var input = InputLoader.LoadFile(args[1]);

            var result = "";
            switch (args[0])
            {
                case "1.1":
                    result = Day1.Puzzle1(input).ToString();
                    break;
                case "1.2":
                    result = Day1.Puzzle2(input).ToString();
                    break;
                case "2.1":
                    result = Day2.Puzzle1(input).ToString();
                    break;
                case "2.2":
                    result = Day2.Puzzle2(input).ToString();
                    break;
                case "3.1":
                    result = Day3.Puzzle1(input).ToString();
                    break;
                case "3.2":
                    result = Day3.Puzzle2(input).ToString();
                    break;
                case "4.1":
                    result = Day4.Puzzle1(input).ToString();
                    break;
                case "4.2":
                    result = Day4.Puzzle2(input).ToString();
                    break;
                case "5.1":
                    result = Day5.Puzzle1(input).ToString();
                    break;
                case "5.2":
                    result = Day5.Puzzle2(input).ToString();
                    break;
                case "6.1":
                    result = Day6.Puzzle1(input).ToString();
                    break;
                case "6.2":
                    result = Day6.Puzzle2(input).ToString();
                    break;
                default:
                    Console.WriteLine("Puzzle Not Found");
                    break;
            }
            Console.WriteLine(result);
        }
    }
}