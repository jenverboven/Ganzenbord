using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business
{
    public class Board
    {
        public List<ISquare> squares = new List<ISquare>();

        internal static Dictionary<int, SquareType> configuration = new Dictionary<int, SquareType>
        {
            { 0, SquareType.Generic },
            { 1, SquareType.Generic },
            { 2, SquareType.Generic },
            { 3, SquareType.Generic },
            { 4, SquareType.Generic },
            { 5, SquareType.Generic },
            { 6, SquareType.Bridge },
            { 7, SquareType.Generic },
            { 8, SquareType.Generic },
            { 9, SquareType.Generic },
            { 10, SquareType.Generic },
            { 11, SquareType.Generic },
            { 12, SquareType.Generic },
            { 13, SquareType.Generic },
            { 14, SquareType.Generic },
            { 15, SquareType.Generic },
            { 16, SquareType.Generic },
            { 17, SquareType.Generic },
            { 18, SquareType.Generic },
            { 19, SquareType.Inn },
            { 20, SquareType.Generic },
            { 21, SquareType.Generic },
            { 22, SquareType.Generic },
            { 23, SquareType.Generic },
            { 24, SquareType.Generic },
            { 25, SquareType.Generic },
            { 26, SquareType.Generic },
            { 27, SquareType.Generic },
            { 28, SquareType.Generic },
            { 29, SquareType.Generic },
            { 30, SquareType.Generic },
            { 31, SquareType.Well },
            { 32, SquareType.Generic },
            { 33, SquareType.Generic },
            { 34, SquareType.Generic },
            { 35, SquareType.Generic },
            { 36, SquareType.Generic },
            { 37, SquareType.Generic },
            { 38, SquareType.Generic },
            { 39, SquareType.Generic },
            { 40, SquareType.Generic },
            { 41, SquareType.Generic },
            { 42, SquareType.Maze },
            { 43, SquareType.Generic },
            { 44, SquareType.Generic },
            { 45, SquareType.Generic },
            { 46, SquareType.Generic },
            { 47, SquareType.Generic },
            { 48, SquareType.Generic },
            { 49, SquareType.Generic },
            { 50, SquareType.Generic },
            { 51, SquareType.Generic },
            { 52, SquareType.Prison },
            { 53, SquareType.Generic },
            { 54, SquareType.Generic },
            { 55, SquareType.Generic },
            { 56, SquareType.Generic },
            { 57, SquareType.Generic },
            { 58, SquareType.Death },
            { 59, SquareType.Generic },
            { 60, SquareType.Generic },
            { 61, SquareType.Generic },
            { 62, SquareType.Generic },
            { 63, SquareType.End }
        };

        public Board()
        {
            foreach (var square in configuration)
            {
                int position = square.Key;
                SquareType type = square.Value;

                squares.Add(SquareFactory.create(type, position));
            }
        }
    }
}