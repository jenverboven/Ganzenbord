using Ganzenbord.Business.Players;

namespace Ganzenbord.Business.Game
{
    public interface IGame
    {
        bool HasEnded { get; }
        int Turn { get; }

        void PlayRound(List<Player> players);

        void SetTurn(int turn);

        void Start();
    }
}