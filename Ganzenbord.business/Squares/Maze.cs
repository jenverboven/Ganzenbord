using Ganzenbord.Business.Players;

namespace Ganzenbord.Business.Squares
{
    internal class Maze : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.Logger.LogMessage($"{player.Player_ID} landed on the maze and was moved backwards");
            player.MoveToPosition(39);
        }
    }
}