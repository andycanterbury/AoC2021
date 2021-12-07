namespace AoC2021
{
    internal class Day6
    {
        public static long Puzzle1(string[] input)
        {
            var daysToSimulate = 80;
            long totalFish = 0;

            var school = InitializeSchool(input[0]);
            for (int i = 0; i < daysToSimulate; i++)
            {
                SimulateDay(school);
            }

            foreach(var count in school)
            {
                totalFish += count;
            }

            return totalFish;
        }

        public static long Puzzle2(string[] input)
        {
            var daysToSimulate = 256;
            long totalFish = 0;

            var school = InitializeSchool(input[0]);
            for (int i = 0; i < daysToSimulate; i++)
            {
                SimulateDay(school);
            }

            foreach (var count in school)
            {
                totalFish += count;
            }
            return totalFish;
        }

        private static long[] InitializeSchool(string input)
        {
            var school = new long[9];
            var states = input.Split(',');
            foreach(var state in states)
            {
                school[int.Parse(state)]++;
            }
            return school;
        }

        private static void SimulateDay(long[] school)
        {
            var temp = school[0];
            for(var i=1; i < 9; i++)
            {
                school[i-1] = school[i];
            }
            school[6] += temp;
            school[8] = temp;
        }

        public class Fish 
        {
            public int SpawnTimer { get; set; }

        }


    }
}
