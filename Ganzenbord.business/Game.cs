using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Players;

namespace Ganzenbord.Business
{
    public class Game
    {
        public int Turn { get; private set; } = 1;
        public bool HasEnded { get; private set; } = false;
        public List<Player> Players;
        public int AmountDice = 2;

        private ILogger Logger;
        private IDice dice { get; set; }

        public Game(ILogger logger, IDice _dice, int amountPlayers)
        {
            Logger = logger;
            dice = _dice;
            Players = new List<Player>();

            for (int i = 0; i < amountPlayers; i++)
            {
                Player player = new($"Player_{i + 1}");
                Players.Add(player);
            }
        }

        public void PlayRound(List<Player> players)
        {
            if (Turn == 1)
            {
                PlayFirstTurn(players);
            }
            else
            {
                PlayRegularTurn(players);
            }

            Turn++;
        }

        private void PlayFirstTurn(List<Player> players)
        {
            foreach (Player player in players)
            {
                player.LastRolls = dice.RollDice();

                if (player.LastRolls.Sum() != 9)
                {
                    player.Move();
                }
                else
                {
                    MovePlayerExceptionally(player);
                }

                if (PlayerWon(player)) break;
            }
        }

        private void PlayRegularTurn(List<Player> players)
        {
            foreach (Player player in players)
            {
                player.LastRolls = dice.RollDice();

                player.PlayTurn();

                if (PlayerWon(player)) break;
            }
        }

        private static void MovePlayerExceptionally(Player player)
        {
            if (player.LastRolls.Contains(6))
            {
                player.MoveToPosition(53);
            }
            else
            {
                player.MoveToPosition(26);
            }
        }

        private bool PlayerWon(Player player)
        {
            if (player.IsWinner)
            {
                HasEnded = true;
                return true;
            }

            return false;
        }

        public void SetTurn(int turn)
        {
            Turn = turn;
        }

        public void Start()
        {
            while (!HasEnded)
            {
                PlayRound(Players);
            }

            Player winner = Players.Single(player => player.IsWinner);
            Logger.LogMessage($"{winner.Player_ID} won the game");
        }
    }
}