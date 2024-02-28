using Ganzenbord.Business.Squares;
using System;

namespace Ganzenbord.Business
{
    public class Player
    {
        public int Position { get; private set; }
        public bool CanMove { get; private set; } = true;
        public int TurnsToSkip { get; private set; } = 0;

        private static Random random = new Random();
        //public int Turn { get; private set; } = 1;

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
                TurnsToSkip--;

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
            if (position == 6)
            {
                ISquare square = new Bridge();
                square.PlayerEntersSquare(this);
            }

            if (position == 42)
            {
                ISquare square = new Maze();
                square.PlayerEntersSquare(this);
            }

            if (position == 58)
            {
                ISquare square = new Death();
                square.PlayerEntersSquare(this);
            }

            if (position == 19)
            {
                ISquare square = new Inn();
                square.PlayerEntersSquare(this);
            }
        }
    }
}