using Ganzenbord.Business.Players;

namespace Ganzenbord.Business.Squares
{
    internal class Prison : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.SetCanMove(false);
            player.SetTurnsToSkip(3);
            player.Logger.LogMessage($"{player.Player_ID} landed on the prison and won't be able to move for {player.TurnsToSkip} turns");
        }
    }
}