namespace Ganzenbord.Business.Squares
{
    internal class End : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.SetWinner(true);
            Game.Instance.EndGame();
        }
    }
}