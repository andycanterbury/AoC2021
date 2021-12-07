namespace AoC2021
{
    internal class Day4
    {
        public static int Puzzle1(string[] input)
        {
            var score = 0;
            var randNums = input[0].Split(',');
            var boards = ParseBoards(input);
            foreach(var num in randNums)
            {
                MarkBoards(boards, num);
                var winner = CheckForWinners(boards);
                if (winner != null)
                {
                    score = ScoreBoard(winner) * int.Parse(num);
                    return score;
                }
            }
            return score;
        }

        private static List<List<List<string>>> ParseBoards(string[] input)
        {
            var boards = new List<List<List<string>>>();
            var newBoard = new List<List<string>>();
            for(int i = 1; i < input.Length; i++)
            {
                if (input[i] == "")
                {
                    continue;
                }
                var newRow = input[i].Trim().Replace("  ", " ").Split(" ");
                newBoard.Add(newRow.ToList());
                if (newBoard.Count == 5)
                {
                    boards.Add(newBoard);
                    newBoard = new List<List<string>>();
                }
            }
            return boards;
        }

        private static void MarkBoards(List<List<List<string>>> boards, string num)
        {
            foreach(var board in boards)
            {
                foreach(var row in board)
                {
                    if (row.Any(x => x == num))
                    {
                        row[row.IndexOf(num)] = "*";
                    }
                }
            }
        }

        private static List<List<string>> CheckForWinners(List<List<List<string>>> boards)
        {
            foreach(var board in boards)
            {
                foreach(var row in board)
                {
                    if (row.All(x => x == "*"))
                    {
                        return board;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    var col = board.Select(c => c[i]).ToList();
                    if (col.All(x => x == "*"))
                    {
                        return board;
                    }
                }
            }
            return null;
        }

        private static int ScoreBoard(List<List<string>> winningBoard)
        {
            var total = 0;
            foreach(var row in winningBoard)
            {
                row.RemoveAll(x => x == "*");
                var rowTotal = row.Select(r => int.Parse(r)).Sum();
                total += rowTotal;
            }
            return total;
        }

        public static int Puzzle2(string[] input)
        {
            var score = 0;
            var randNums = input[0].Split(',');
            var boards = ParseBoards(input);
            var lastWinner = new List<List<string>>();
            var lastWinningNumber = 0;
            foreach (var num in randNums)
            {
                MarkBoards(boards, num);
                List<List<string>> winner = null;
                do
                {
                    winner = CheckForWinners(boards);
                    if (winner != null)
                    {
                        lastWinner = winner;
                        lastWinningNumber = int.Parse(num);
                        boards.Remove(winner);
                    }
                }
                while (winner != null);
            }

            score = ScoreBoard(lastWinner) * lastWinningNumber;
            return score;
        }

    }
}
