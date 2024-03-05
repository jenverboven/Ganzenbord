namespace Ganzenbord.Business.Squares
{
    public class SquareFactory
    {
        public static ISquare create(SquareType type, int position)
        {
            switch (type)
            {
                case SquareType.Bridge:
                    Bridge bridge = new Bridge();
                    bridge.Position = position;
                    return bridge;

                case SquareType.Inn:
                    Inn inn = new Inn();
                    inn.Position = position;
                    return inn;

                case SquareType.Well:
                    Well well = new Well();
                    well.Position = position;
                    return well;

                case SquareType.Maze:
                    Maze maze = new Maze();
                    maze.Position = position;
                    return maze;

                case SquareType.Prison:
                    Prison prison = new Prison();
                    prison.Position = position;
                    return prison;

                case SquareType.Death:
                    Death death = new Death();
                    death.Position = position;
                    return death;

                case SquareType.End:
                    End end = new End();
                    end.Position = position;
                    return end;

                case SquareType.Generic:
                    Generic generic = new Generic();
                    generic.Position = position;
                    return generic;

                case SquareType.Goose:
                    Goose goose = new Goose();
                    goose.Position = position;
                    return goose;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}