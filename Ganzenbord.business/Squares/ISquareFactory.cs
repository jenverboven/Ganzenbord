namespace Ganzenbord.Business.Squares
{
    public interface ISquareFactory
    {
        ISquare Create(SquareType type, int position);
    }
}