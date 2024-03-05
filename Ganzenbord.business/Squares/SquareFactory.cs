namespace Ganzenbord.Business.Squares
{
    public class SquareFactory : ISquareFactory
    {
        public ISquare Create(SquareType type, int position)
        {
            switch (type)
            {
                case SquareType.Bridge:
                    Bridge bridge = new(position);
                    return bridge;

                case SquareType.Death:
                    Death death = new(position);
                    return death;

                case SquareType.End:
                    End end = new(position);
                    return end;

                case SquareType.Generic:
                    Generic generic = new(position);
                    return generic;

                case SquareType.Inn:
                    Inn inn = new(position);
                    return inn;

                case SquareType.Maze:
                    Maze maze = new(position);
                    return maze;

                case SquareType.Prison:
                    Prison prison = new(position);
                    return prison;

                case SquareType.Well:
                    Well well = new(position);
                    return well;

                case SquareType.Goose:
                    Goose goose = new(position);
                    return goose;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}