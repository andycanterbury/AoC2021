namespace AoC2021
{
    internal class Day3
    {
        public static int Puzzle1(string[] input)
        {
            int[] sums = new int[input[0].Length];

            foreach(var value in input)
            {
                for (int i = 0; i < sums.Length; i++)
                {
                    sums[i] += int.Parse(value[i].ToString());
                }
            }
            var avg = input.Length / 2;
            var gammaString = "";
            var epsilonString = "";
            foreach(var sum in sums)
            {
                gammaString += (sum > avg) ? "1" : "0";
                epsilonString += (sum < avg) ? "1" : "0";
            }
            var gamma = Convert.ToInt32(gammaString, 2);
            var epsilon = Convert.ToInt32(epsilonString, 2);
            return gamma * epsilon;
        }

        public static int Puzzle2(string[] input)
        {
            var inputLen = input[0].Length;
            string[] oxyArray = new string[input.Length];
            input.CopyTo(oxyArray, 0);
            var oxyStr = OxygenRating(oxyArray, inputLen);

            string[] co2Array = new string[input.Length];
            input.CopyTo(co2Array, 0);
            var co2Str = CO2Rating(co2Array, inputLen);

            var oxy = Convert.ToInt32(oxyStr, 2);
            var co2 = Convert.ToInt32(co2Str, 2);
            return oxy * co2;
        }

        private static string OxygenRating(string[] oxyArray, int inputLen)
        {
            for(int i = 0;i < inputLen;i++)
            {
                char common = FindMostCommon(oxyArray, i);
                oxyArray = oxyArray.Where(x => x[i] == common).ToArray();
                if (oxyArray.Length == 1)
                {
                    break;
                }
            }
            return oxyArray[0];
        }

        private static string CO2Rating(string[] co2Array, int inputLen)
        {
            for (int i = 0; i < inputLen; i++)
            {
                char common = FindMostCommon(co2Array, i);
                co2Array = co2Array.Where(x => x[i] != common).ToArray();
                if (co2Array.Length == 1)
                {
                    break;
                }
            }
            return co2Array[0];
        }

        private static char FindMostCommon(string[] input, int position)
        {
            var positionTotal = input.Sum(i => int.Parse(i[position].ToString()));
            double average = input.Length / 2.0;
            return (positionTotal >= average) ? '1' : '0';
        }
    }
}
