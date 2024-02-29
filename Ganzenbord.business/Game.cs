namespace Ganzenbord.Business
{
    public class Game
    {
        public static Game instance;
        public Board board { get; set; }
        private List<Player> players;
        public int Turn { get; private set; } = 1;
        private int AmountDice = 2;

        public bool End = false;

        // ...

        public Game(int amountPlayers)
        {
            board = new Board();
            players = new List<Player>();

            for (int i = 1; i <= amountPlayers; i++)
            {
                Player player = new Player();
                players.Add(player);
            }
        }

        public static Game Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Game(4);
                }
                return instance;
            }
        }

        private void PlayRound(List<Player> players, int amountDice)
        {
            if (!End)
            {
                foreach (Player player in players)
                {
                    player.PlayTurn(amountDice);
                }
                Turn++;
            }
        }

        internal void EndGame()
        {
            End = true;
        }

        public void SetTurn(int turn)
        {
            Turn = turn;
        }
    }
}