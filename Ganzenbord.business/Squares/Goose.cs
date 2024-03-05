using Ganzenbord.Business.Players;

namespace Ganzenbord.Business.Squares
{
    internal class Goose : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.Logger.LogMessage($"{player.Player_ID} landed on the goose on square {Position} and was moved forward {player.LastRolls.Sum()} spaces");
            player.Move();
        }
    }
}