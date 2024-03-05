using Ganzenbord.Business.Players;

namespace Ganzenbord.Business.Squares
{
    internal class End(int position) : ISquare
    {
        public int Position { get; set; } = position;

        public void PlayerEntersSquare(Player player)
        {
            player.SetWinner(true);
        }
    }
}