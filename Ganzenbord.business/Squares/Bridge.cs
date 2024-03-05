using Ganzenbord.Business.Players;

namespace Ganzenbord.Business.Squares
{
    public class Bridge : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.Logger.LogMessage($"{player.Player_ID} landed on the bridge and was moved forward");
            player.MoveToPosition(12);
        }
    }
}