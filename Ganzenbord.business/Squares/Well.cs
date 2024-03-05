using Ganzenbord.Business.Players;

namespace Ganzenbord.Business.Squares
{
    internal class Well(int position) : ISquare
    {
        public int Position { get; set; } = position;

        private Player? CaughtPlayer { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.Logger.LogMessage($"{player.Player_ID} landed on the well and won't be able to move until someone else arrives here");
            if (CaughtPlayer != null)
            {
                CaughtPlayer.Logger.LogMessage($"{CaughtPlayer.Player_ID} was released from the well");
            }

            if (CaughtPlayer != null)
            {
                CaughtPlayer.SetCanMove(true);
            }

            player.SetCanMove(false);
            CaughtPlayer = player;
        }
    }
}