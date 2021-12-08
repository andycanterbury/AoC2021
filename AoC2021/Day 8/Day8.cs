namespace AoC2021
{
    internal class Day8
    {
        public static int Puzzle1(string[] input)
        {
            var uniques = 0;
            foreach (var item in input)
            {
                var data = item.Split("|");
                var patterns = data[0].Split(" ");
                var values = data[1].Split(" ");

                var ones = values.Count(v => v.Length == 2);
                var fours = values.Count(v => v.Length == 4);
                var sevens = values.Count(v => v.Length == 3);
                var eights = values.Count(v => v.Length == 7);

                uniques += (ones + fours + sevens + eights);
            }
            return uniques;
        }

        public static int Puzzle2(string[] input)
        {
            var total = 0;
            foreach (var item in input)
            {
                var data = item.Split("|");
                var patterns = data[0].Trim().Split(" ");
                var values = data[1].Trim().Split(" ");

                var sortedPatterns = patterns.Select(p => new string(p.ToCharArray().OrderBy(c => c).ToArray()));

                var one = sortedPatterns.First(v => v.Length == 2);
                var three = sortedPatterns.First(v => v.Length == 5 && one.All(o => v.Contains(o)));
                var four = sortedPatterns.First(v => v.Length == 4);
                var seven = sortedPatterns.First(v => v.Length == 3);
                var eight = sortedPatterns.First(v => v.Length == 7);
                var nine = sortedPatterns.First(v => v.Length == 6 && three.All(t => v.Contains(t)) && four.All(f => v.Contains(f)));
                var zero = sortedPatterns.First(v => v.Length == 6 && v != nine && one.All(o => v.Contains(o)));
                var six = sortedPatterns.First(v => v.Length == 6 && v != nine && v != zero);
                var five = sortedPatterns.First(v => v.Length == 5 && v != three && v.All(t => nine.Contains(t)));
                var two = sortedPatterns.First(v => v.Length == 5 && v != three && v != five);

                var digits = new Dictionary<string, int>
                {
                    { zero, 0 },
                    { one, 1 },
                    { two, 2 },
                    { three, 3 },
                    { four, 4 },
                    { five, 5 },
                    { six, 6 },
                    { seven, 7 },
                    { eight, 8 },
                    { nine, 9 }
                };

                var value = "";
                foreach(var num in values)
                {
                    var toFind = new string(num.ToCharArray().OrderBy(c => c).ToArray());
                    value += digits[toFind];
                }
                total += int.Parse(value);
            }
            return total;
        }
    }
}
