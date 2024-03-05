using Ganzenbord.Business.Players;

namespace Ganzenbord.Business.Squares
{
    internal class Generic(int position) : ISquare
    {
        public int Position { get; set; } = position;

        public void PlayerEntersSquare(Player player)
        {
            player.Logger.LogMessage($"{player.Player_ID} landed on {(Position == 0 ? "start" : $"square {Position}")}");
        }
    }
}