namespace AoC2021
{
    internal class Day5
    {
        public static int Puzzle1(string[] input)
        {
            var points = FindAllNonDiagPoints(input);
            var overlaps = FindOverlaps(points);
            return overlaps.Count;
        }

        public static int Puzzle2(string[] input)
        {
            var points = FindAllPoints(input);
            var overlaps = ParallelFindOverlaps(points);
            return overlaps.Count;         //18864
        }

        private static List<Point> FindAllNonDiagPoints(string[] input)
        {
            var points = new List<Point>();
            foreach (var line in input)
            {
                var ln = line.Replace("-> ", "").Split(" ");
                
                var startPoint = new Point(ln[0]);
                var endPoint = new Point(ln[1]);

                if (startPoint.x > endPoint.x || startPoint.y > endPoint.y)
                {
                    var temp = startPoint;
                    startPoint = endPoint;
                    endPoint = temp;
                }

                //check horiz or vertical
                if (startPoint.x == endPoint.x || startPoint.y == endPoint.y)
                {
                    for (int i = startPoint.x; i <= endPoint.x; i++)
                    {
                        for (int j = startPoint.y; j <= endPoint.y; j++)
                        {
                            points.Add(new Point(i, j));
                        }
                    }
                }
            }
            return points;
        }

        private static List<Point> FindAllPoints(string[] input)
        {
            var points = new List<Point>();
            foreach (var line in input)
            {
                var ln = line.Replace("-> ", "").Split(" ");

                var startPoint = new Point(ln[0]);
                var endPoint = new Point(ln[1]);

                //check horiz or vertical
                if (startPoint.x == endPoint.x || startPoint.y == endPoint.y)
                {

                    if (startPoint.x > endPoint.x || startPoint.y > endPoint.y)
                    {
                        var temp = startPoint;
                        startPoint = endPoint;
                        endPoint = temp;
                    }

                    for (int i = startPoint.x; i <= endPoint.x; i++)
                    {
                        for (int j = startPoint.y; j <= endPoint.y; j++)
                        {
                            points.Add(new Point(i, j));
                        }
                    }
                }
                else
                {
                    var xStep = (startPoint.x > endPoint.x) ? -1 : 1;
                    var yStep = (startPoint.y > endPoint.y) ? -1 : 1;

                    var newX = startPoint.x;
                    var newY = startPoint.y;
                    while (newX != endPoint.x || newY != endPoint.y)
                    {
                        points.Add(new Point(newX, newY));
                        newX += xStep;
                        newY += yStep;
                    }
                    points.Add(endPoint);
                }
            }
            return points;
        }

        private static List<Point> FindOverlaps(List<Point> allPoints)
        {
            var overlaps = new List<Point>();
            foreach(var point in allPoints)
            {
                if (!overlaps.Any(p => p.x == point.x && p.y == point.y))
                {
                    var count = allPoints.Count(p => p.x == point.x && p.y == point.y);
                    if (count > 1)
                    {
                        overlaps.Add(point);
                    }
                }
            }
            
            return overlaps;
        }

        private static List<Point> ParallelFindOverlaps(List<Point> allPoints)
        {
            var overlaps = new List<Point>();
            Parallel.ForEach(allPoints, point =>
            {
                var count = allPoints.Count(p => p.x == point.x && p.y == point.y);
                if (count > 1)
                {
                    overlaps.Add(point);
                }
            });

            return overlaps.Distinct().ToList();
        }

        public class Point 
        {
            public int x;
            public int y;

            public Point(int newX, int newY)
            {
                x = newX;
                y = newY;
            }
            public Point(string coords)
            {
                var xy = coords.Split(",");
                x = int.Parse(xy[0]);
                y = int.Parse(xy[1]);
            }

            public override bool Equals(object? obj)
            {
                var other = obj as Point;
                return (other?.x == x && other?.y == y);
            }

            public override int GetHashCode()
            {
                return x.GetHashCode() + y.GetHashCode();
            }
        }


    }
}
