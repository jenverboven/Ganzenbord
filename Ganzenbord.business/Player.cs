using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business
{
    public class Player
    {
        public int Position { get; private set; } = 0;
        public bool CanMove { get; private set; } = true;
        public int TurnsToSkip { get; private set; } = 0;
        public bool IsWinner { get; set; } = false;
        public bool Reverse { get; set; } = false;

        private static Random random = new Random();

        public void Move(int[] diceRolls)
        {
            if (!(Game.Instance.Turn == 1 && diceRolls.Sum() == 9))
            {
                MoveRegular(diceRolls);
            }
            else
            {
                if (diceRolls.Contains(6))
                {
                    MoveToPosition(53);
                }
                else
                {
                    MoveToPosition(26);
                }
            }

            GetSquare(Position);
        }

        private void MoveRegular(int[] diceRolls)
        {
            int newPosition = Position + diceRolls.Sum();

            if (!Reverse)
            {
                if (newPosition <= 63)
                {
                    Position = newPosition;
                }
                else
                {
                    Reverse = true;
                    Position = 63 - (newPosition - 63);
                }
            }
            else
            {
                Position -= diceRolls.Sum();
            }
        }

        public void MoveToPosition(int position)
        {
            Position = position;

            GetSquare(position);
        }

        public void SetCanMove(bool canMove)
        {
            CanMove = canMove;
        }

        public void SetWinner(bool isWinner)
        {
            IsWinner = isWinner;
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

                if (Reverse)
                {
                    Reverse = false;
                }
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
            Game.Instance.board.squares[position].PlayerEntersSquare(this);
        }
    }
}