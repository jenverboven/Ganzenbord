using Ganzenbord.Business.Players;

namespace Ganzenbord.Business
{
    public class Game
    {
        public int Turn { get; private set; } = 1;
        public bool End { get; private set; } = false;

        private Board Board { get; set; }
        private List<Player> Players;
        private int AmountDice = 2;
        private ILogger Logger;

        public Game(ILogger logger, int amountPlayers)
        {
            Logger = logger;
            Board = new Board();
            Players = new List<Player>();

            for (int i = 0; i < amountPlayers; i++)
            {
                Player player = new();
                Players.Add(player);
            }
        }

        private void PlayRound(List<Player> players)
        {
            if (Turn == 1)
            {
            }

            foreach (Player player in players)
            {
                if (player.IsWinner)
                {
                    EndGame();
                    break;
                }
                player.PlayTurn(AmountDice);
            }
            Turn++;
        }

        public void EndGame()
        {
            End = true;
        }

        public void SetTurn(int turn)
        {
            Turn = turn;
        }

        public void Start()
        {
            while (!End)
            {
                PlayRound(Players);
            }

            Logger.LogMessage("player x won the game");
        }
    }
}