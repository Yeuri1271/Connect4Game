namespace Connect4Solution
{
    public class Player
    {
        private readonly int playerNumber;
        public int Movements { get; set; }
        public bool IsWinner { get; set; }
        public string WinnerPattern { get; }
        public int GetPlayerNumber 
        { 
            get 
            {
                return playerNumber; 
            }
        }

        public Player(int playerNumber)
        {
            this.playerNumber = playerNumber;

            WinnerPattern = $"{playerNumber}{playerNumber}{playerNumber}{playerNumber}";
        }
    }
}
