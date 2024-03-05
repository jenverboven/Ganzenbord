using Ganzenbord.Business.Players;

namespace Ganzenbord.Business.Squares
{
    internal class Death(int position) : ISquare
    {
        public int Position { get; set; } = position;

        public void PlayerEntersSquare(Player player)
        {
            player.Logger.LogMessage($"{player.Player_ID} landed on death and was put back on start");
            player.MoveToPosition(0);
        }
    }
}