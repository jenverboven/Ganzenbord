using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business
{
    public class Player
    {
        public int Position { get; private set; }
        public bool CanMove { get; private set; } = true;
        public int TurnsToSkip { get; private set; } = 0;
        public bool Winner { get; set; } = false;

        private static Random random = new Random();

        public void Move(int[] diceRolls)
        {
            Position += diceRolls.Sum();

            GetSquare(Position);
        }

        public void MoveToPosition(int position)
        {
            Position = position;

            GetSquare(position);
        }

        //public void SetTurn(int turn)
        //{
        //    Turn = turn;
        //}

        //public void IncrementTurn()
        //{
        //    Turn++;
        //}

        public void SetCanMove(bool canMove)
        {
            CanMove = canMove;
        }

        public void SetWinner(bool winner)
        {
            Winner = winner;
        }

        public void SetTurnsToSkip(int amountTurns)
        {
            TurnsToSkip = amountTurns;
        }

        public void PlayTurn(int amountDice)
        {
            if (CanMove)
            {
                Move(RollDice(amountDice));
            }
            else if (TurnsToSkip > 0)
            {
                SkipTurn(this);
            }
        }

        private void SkipTurn(Player player)
        {
            if (player.TurnsToSkip > 0)
            {
                player.TurnsToSkip--;

                if (TurnsToSkip == 0)
                {
                    CanMove = true;
                }
            }
        }

        public int[] RollDice(int amount)
        {
            List<int> rolls = new List<int>();

            for (int i = 0; i < amount; i++)
            {
                rolls.Add(random.Next(1, 7));
            }

            return rolls.ToArray();
        }

        private void GetSquare(int position)
        {
            ISquare square = SquareFactory.create(Board.configuration[position], position);

            //ISquare square = Game.Instance.board.squares[position];

            square.PlayerEntersSquare(this);
        }
    }
}