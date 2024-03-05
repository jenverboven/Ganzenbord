using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Board
{
    public class Board : IBoard
    {
        //private static Board instance;
        private readonly List<ISquare> squares = [];

        private readonly ISquareFactory _squareFactory;

        private readonly Dictionary<int, SquareType> configuration = new()
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

        public Board(ISquareFactory squareFactory)
        {
            _squareFactory = squareFactory;

            CreateBoard();
        }

        private void CreateBoard()
        {
            for (int i = 0; i < 64; i++)
            {
                if (configuration.TryGetValue(i, out SquareType type))
                {
                    squares.Add(_squareFactory.Create(type, i));
                }
                else
                {
                    squares.Add(_squareFactory.Create(SquareType.Generic, i));
                }
            }
        }

        //public static Board Instance
        //{
        //    get
        //    {
        //        instance ??= new Board();
        //        return instance;
        //    }
        //}

        public ISquare GetSquare(int position)
        {
            return squares.Single(square => square.Position == position);
        }
    }
}