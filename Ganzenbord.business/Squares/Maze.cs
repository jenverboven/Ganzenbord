using Ganzenbord.Business.Players;

namespace Ganzenbord.Business.Squares
{
    internal class Maze : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.MoveToPosition(39);
        }
    }
}