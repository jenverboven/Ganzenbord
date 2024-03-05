using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business
{
    public class Board
    {
        private static Board instance;
        private List<ISquare> squares = new List<ISquare>();

        private static readonly Dictionary<int, SquareType> configuration = new Dictionary<int, SquareType>
        {
            { 6, SquareType.Bridge },
            { 19, SquareType.Inn },
            { 31, SquareType.Well },
            { 42, SquareType.Maze },
            { 52, SquareType.Prison },
            { 58, SquareType.Death },
            { 63, SquareType.End },
            { 5, SquareType.Goose },
            { 9, SquareType.Goose },
            { 14, SquareType.Goose },
            { 18, SquareType.Goose },
            { 23, SquareType.Goose },
            { 27, SquareType.Goose },
            { 32, SquareType.Goose },
            { 36, SquareType.Goose },
            { 41, SquareType.Goose },
            { 45, SquareType.Goose },
            { 50, SquareType.Goose },
            { 54, SquareType.Goose },
            { 59, SquareType.Goose },
        };

        public Board()
        {
            for (int i = 0; i < 64; i++)
            {
                if (configuration.ContainsKey(i))
                {
                    SquareType type = configuration[i];

                    squares.Add(SquareFactory.Create(type, i));
                }
                else
                {
                    squares.Add(SquareFactory.Create(SquareType.Generic, i));
                }
            }
        }

        public static Board Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Board();
                }
                return instance;
            }
        }

        public ISquare GetSquare(int position)
        {
            return squares.Single(square => square.Position == position);
        }
    }
}