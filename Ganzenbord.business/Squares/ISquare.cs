using Ganzenbord.Business.Players;

namespace Ganzenbord.Business.Squares
{
    public interface ISquare
    {
        int Position { get; set; }

        void PlayerEntersSquare(Player player);
    }
}