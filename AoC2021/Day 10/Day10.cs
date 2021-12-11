namespace AoC2021
{
    internal class Day10
    {
        private static char[] openingChars = new char[4] { '(', '[', '{', '<' };
        private static char[] closingChars = new char[4] { ')', ']', '}', '>' };
        public static int Puzzle1(string[] input)
        {
            var points = 0;
            var scoring = new Dictionary<char, int>() { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };

            foreach (var line in input)
            {
                var nextExpectedClosing = "";
                foreach(var chr in line)
                {
                    //Are we starting a new chunk?
                    if (openingChars.Contains(chr))
                    {
                        var idx = Array.IndexOf(openingChars, chr);
                        nextExpectedClosing = closingChars[idx] + nextExpectedClosing;
                        continue;
                    }

                    //Are we closing a chunk?
                    if (closingChars.Contains(chr))
                    {
                        var idx = Array.IndexOf(closingChars, chr);
                        if (closingChars[idx] == nextExpectedClosing[0])
                        {
                            //Closing a chunk
                            nextExpectedClosing = nextExpectedClosing.Substring(1);
                        } 
                        else
                        {
                            //Corrupted chunk
                            points += scoring[chr];
                            break;
                        }
                    }
                    
                }
            }
            return points;
        }

        public static long Puzzle2(string[] input)
        {
            var points = new List<long>();
            var scoring = new Dictionary<char, int>() { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };

            foreach (var line in input)
            {
                long lineScore = 0;
                var nextExpectedClosing = "";
                var corrupt = false;
                foreach (var chr in line)
                {
                    //Are we starting a new chunk?
                    if (openingChars.Contains(chr))
                    {
                        var idx = Array.IndexOf(openingChars, chr);
                        nextExpectedClosing = closingChars[idx] + nextExpectedClosing;
                        continue;
                    }

                    //Are we closing a chunk?
                    if (closingChars.Contains(chr))
                    {
                        var idx = Array.IndexOf(closingChars, chr);
                        if (closingChars[idx] == nextExpectedClosing[0])
                        {
                            //Closing a chunk
                            nextExpectedClosing = nextExpectedClosing.Substring(1);
                        }
                        else
                        {
                            //Corrupted chunk
                            corrupt = true;
                            break;
                        }
                    }

                }

                //Incomplete line
                if (!corrupt && nextExpectedClosing != "")
                {
                    foreach(var closer in nextExpectedClosing)
                    {
                        lineScore = (lineScore * 5) + scoring[closer];
                    }
                    points.Add(lineScore);
                }
            }

            //Find middle score
            var sortedScores = points.OrderBy(p => p).ToList();
            var middleIndex = sortedScores.Count / 2;
            return sortedScores[middleIndex];
        }
    }
}
