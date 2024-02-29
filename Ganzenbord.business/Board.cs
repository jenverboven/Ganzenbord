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
            { 63, SquareType.End }
        };

        public Board()
        {
            for (int i = 0; i < 64; i++)
            {
                if (configuration.ContainsKey(i))
                {
                    SquareType type = configuration[i];

                    squares.Add(SquareFactory.create(type, i));
                }
                else
                {
                    squares.Add(SquareFactory.create(SquareType.Generic, i));
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