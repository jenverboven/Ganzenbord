using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Board
{
    public interface IBoard
    {
        ISquare GetSquare(int position);
    }
}