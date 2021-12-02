namespace Connect4Solution
{
    public static class StandardMessage
    {
        public static string WinnerMessage(int playerNumber)
        {
            return $"Player {playerNumber} wins!";
        }

        public static string PlayerTurnMessage(int playerNumber)
        {
            return $"Player {playerNumber} has a turn";
        }

        public static string GameOverMessage()
        {
            return "Game has finished!";
        }

        public static string FullColumnMessage()
        {
            return "Column full!";
        }
    }
}
