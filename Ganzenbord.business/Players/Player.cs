using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Players
{
    public class Player
    {
        private static Random random = new Random();

        public bool CanMove { get; private set; } = true;

        //public bool CanMove => TurnsToSkip > 0;
        public bool IsReverse { get; set; } = false;

        public bool IsWinner { get; set; } = false;
        public int Position { get; private set; } = 0;
        public int TurnsToSkip { get; private set; } = 0;

        public void Move(int[] diceRolls)
        {
            int newPosition = Position + diceRolls.Sum();

            if (!IsReverse)
            {
                if (newPosition <= 63)
                {
                    Position = newPosition;
                }
                else
                {
                    IsReverse = true;
                    Position = 63 - (newPosition - 63);
                }
            }
            else
            {
                Position -= diceRolls.Sum();
            }

            HandlePlayerEnteringSquare(Position);
        }

        public void MoveToPosition(int position)
        {
            Position = position;
            HandlePlayerEnteringSquare(position);
        }

        public void PlayTurn(int amountDice)
        {
            if (CanMove)
            {
                Move(RollDice(amountDice));

                IsReverse = false;
                //altijd loggen met logger klasse
            }
            else if (TurnsToSkip > 0)
            {
                SkipTurn(this);
            }
            //niet zelfde afchecken meerdere keren
        }

        public int[] RollDice(int amount)
        {
            int[] myArray = new int[amount];

            for (int i = 0; i < amount; i++)
            {
                myArray[i] = random.Next(1, 7);
            }

            return myArray;
        }

        public void SetCanMove(bool canMove)
        {
            CanMove = canMove;
        }

        public void SetTurnsToSkip(int amountTurns)
        {
            TurnsToSkip = amountTurns;
        }

        public void SetWinner(bool isWinner)
        {
            IsWinner = isWinner;
        }

        private void HandlePlayerEnteringSquare(int position)
        {
            ISquare square = Board.Instance.GetSquare(position);

            square.PlayerEntersSquare(this);
            //hier zoeken naar vakje met position property van vakje zelf
        }

        private void SkipTurn(Player player)
        {
            if (player.TurnsToSkip <= 0) return;

            player.TurnsToSkip--;

            if (TurnsToSkip == 0)
            {
                CanMove = true;
            }
            //zo weinig mogelijk nesting
        }
    }
}