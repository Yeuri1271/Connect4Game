namespace Connect4Solution
{
    public class Connect4
    {
        private readonly int[] Positions = { 5, 5, 5, 5, 5, 5, 5 };

        private readonly int[,] table;
        private readonly Player playerOne;
        private readonly Player playerTwo;

        private bool payerOneTurn = true;

        public Connect4()
        {
            this.table = new int[6, 7];
            this.playerOne = new Player(1);
            this.playerTwo = new Player(2);
        }

        public string Play(int column)
        {
            if (playerOne.IsWinner || playerTwo.IsWinner)
                return StandardMessage.GameOverMessage();

            var position = Positions[column];

            if (position < 0)
                return StandardMessage.FullColumnMessage();

            int row;

            if (payerOneTurn)
            {
                row = Positions[column]--;

                payerOneTurn = false;

                table[row, column] = 1;

                playerOne.Movements++;

                if (playerOne.Movements >= 4)
                {
                    var isWinner = IsWinner(playerOne, table, row, column);
                    if (isWinner)
                    {
                        playerOne.IsWinner = true;
                        return StandardMessage.WinnerMessage(playerOne.GetPlayerNumber);
                    }
                }
                return StandardMessage.PlayerTurnMessage(playerOne.GetPlayerNumber);
            }
            else
            {
                row = Positions[column]--;

                payerOneTurn = true;
                table[row, column] = 2;

                playerTwo.Movements++;

                if (playerTwo.Movements >= 4)
                {
                    var isWinner = IsWinner(playerTwo, table, row, column);
                    if (isWinner)
                    {
                        playerTwo.IsWinner = true;
                        return StandardMessage.WinnerMessage(playerTwo.GetPlayerNumber);
                    }
                }
                return StandardMessage.PlayerTurnMessage(playerTwo.GetPlayerNumber);
            }
        }

        private bool IsWinner(Player player, int[,] grid, int x, int y)
        {
            return CalculateColumns(player, grid, y) ||
                CalculateRows(player, grid, x) ||
                 CalculateDiagonal(player, grid, x, y) ||
            CalculateUpwardDiagonal(player, grid, x, y);
        }

        private bool CalculateColumns(Player player, int[,] grid, int y)
        {
            var plays = "";

            for (var i = 0; i < 6; i++)
            {
                plays += grid[i, y].ToString();
            }

            return IsPatternContained(player, plays);
        }

        private bool CalculateRows(Player player, int[,] grid, int x)
        {
            var plays = "";

            for (var i = 0; i < 7; i++)
            {
                plays += grid[x, i].ToString();
            }

            return IsPatternContained(player, plays);
        }

        private bool CalculateDiagonal(Player player, int[,] grid, int x, int y)
        {
            if (x >= y)
            {
                var row = x - y;

                if (row <= 2)
                {
                    var limit = 6 - row;

                    var plays = "";

                    for (var i = 0; i < limit; i++)
                    {
                        plays += grid[row + i, i].ToString();
                    }

                    return IsPatternContained(player, plays);
                }
            }
            else
            {
                var column = y - x;

                if (column <= 3)
                {
                    var limit = 7 - column;

                    var plays = "";

                    for (var i = 0; i < limit; i++)
                    {
                        plays += grid[i, column + i].ToString();
                    }

                   return IsPatternContained(player, plays);
                }
            }

            return false;
        }

        private bool CalculateUpwardDiagonal(Player player, int[,] grid, int x, int y)
        {
            var row = x + y;
            var column = y - (5 - x);

            if (row is >= 3 and <= 5)
            {
                var limit = 0;

                var plays = "";

                for (var i = row; i >= 0; i--)
                {
                    plays += grid[i, limit++].ToString();
                }

                return IsPatternContained(player, plays);
            }
            else if (row > 5 && column <= 3)
            {
                var rowLimit = 5;

                var plays = "";

                for (var i = column; i <= 6; i++)
                {
                    plays += grid[rowLimit--, i].ToString();
                }

                return IsPatternContained(player, plays);
            }

            return false;
        }

        private bool IsPatternContained(Player player, string plays)
        {
            return plays.Contains(player.WinnerPattern);
        }
    }
}
