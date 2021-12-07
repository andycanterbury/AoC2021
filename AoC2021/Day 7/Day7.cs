namespace AoC2021
{
    internal class Day7
    {
        public static int Puzzle1(string[] input)
        {
            var fuelUsed = 0;

            var crabs = PopulateCrabList(input[0]);
            var target = FindMedianTarget(crabs);
            fuelUsed = CalculateFuel(crabs, target);

            return fuelUsed;
        }

        public static int Puzzle2(string[] input)
        {
            var fuelUsed = 0;

            var crabs = PopulateCrabList(input[0]);
            var target = FindMedianTarget(crabs);
            fuelUsed = CalculateFuelPart2(crabs, target);
            var search = 1;
            var switched = 0;
            while (switched < 2)
            {
                target += search;
                var newFuel = CalculateFuelPart2(crabs, target);
                if (newFuel > fuelUsed )
                {
                    search *= -1;
                    switched++;
                } 
                else
                {
                    fuelUsed = newFuel;
                }
            }

            return fuelUsed;
        }

        private static List<int> PopulateCrabList(string input)
        {
            var crabs = new List<int>();
            var crabsStrings = input.Split(',');
            foreach(var crabsString in crabsStrings)
            {
                crabs.Add(int.Parse(crabsString));
            }
            return crabs;
        }

        private static int FindMedianTarget(List<int> crabs)
        {
            var target = 0;
            var sortedCrabs = crabs.OrderBy(c => c);
            if (crabs.Count % 2 == 0)
            {
                target = (sortedCrabs.ElementAt(crabs.Count/2) + sortedCrabs.ElementAt(crabs.Count/2 - 1))/2;
            } 
            else
            {
                target = sortedCrabs.ElementAt(crabs.Count / 2);
            }
            return target;
        }

        private static int CalculateFuel(List<int> crabs, int target)
        {
            int fuel = 0;
            foreach(var crab in crabs)
            {
                fuel += Math.Abs(crab - target);
            }

            return fuel;
        }

        private static int CalculateFuelPart2(List<int> crabs, int target)
        {
            int fuel = 0;
            foreach (var crab in crabs)
            {
                var distance = Math.Abs(crab - target);
                fuel += (int)((Math.Pow(distance, 2) + distance) / 2);
            }
            return fuel;
        }
    }
}
