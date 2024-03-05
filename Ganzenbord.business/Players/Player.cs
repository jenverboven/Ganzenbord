using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Players
{
    public class Player : IPlayer
    {
        public string Player_ID { get; set; }
        public bool CanMove { get; private set; } = true;

        //public bool CanMove => TurnsToSkip > 0;
        public bool MovesBackwards { get; set; } = false;

        public bool IsWinner { get; set; } = false;
        public int Position { get; set; } = 0;
        public int TurnsToSkip { get; private set; } = 0;
        public int[] LastRolls { get; set; }

        private int AmountDice = 2;

        private static Random random = new Random();

        public Player(string player_ID)
        {
            Player_ID = player_ID;
        }

        public void Move()
        {
            if (MovesBackwards)
            {
                HandleBackwardMovement();
            }
            else
            {
                HandleForwardMovement();
            }

            CheckForNegativePosition();

            HandlePlayerEnteringSquare(Position);
        }

        private void HandleBackwardMovement()
        {
            Position -= LastRolls.Sum();
        }

        private void HandleForwardMovement()
        {
            int newPosition = Position + LastRolls.Sum();

            if (newPosition <= 63)
            {
                Position = newPosition;
            }
            else
            {
                MovesBackwards = true;
                Position = 63 - (newPosition - 63);
            }
        }

        private void CheckForNegativePosition()
        {
            if (Position < 0)
            {
                Position = 0;
            }
        }

        public void MoveToPosition(int position)
        {
            Position = position;
            HandlePlayerEnteringSquare(position);
        }

        public void PlayTurn()
        {
            if (CanMove)
            {
                Move();

                MovesBackwards = false;
                //altijd loggen met logger klasse
            }
            else if (TurnsToSkip > 0)
            {
                SkipTurn(this);
            }
            //niet zelfde afchecken meerdere keren
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