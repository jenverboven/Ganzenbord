namespace Ganzenbord.Business.Squares
{
    public class Bridge : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.MoveToPosition(12);
        }
    }
}