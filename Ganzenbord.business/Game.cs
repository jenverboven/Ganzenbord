namespace Ganzenbord.Business
{
    internal class Game
    {
        private static Game _instance;
        public int Turn { get; private set; } = 1;

        private int AmountDice = 2;

        // ...

        private Game()
        { }

        public static Game Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Game();
                }
                return _instance;
            }
        }

        private void PlayRound(List<Player> players, int amountDice)
        {
            foreach (Player player in players)
            {
                player.PlayTurn(amountDice);
            }
            Turn++;
        }
    }
}