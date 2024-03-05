using Ganzenbord.Business.Board;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Players
{
    public class Player : IPlayer
    {
        public string Player_ID { get; set; }
        public bool CanMove { get; private set; } = true;
        public bool MovesBackwards { get; set; } = false;
        public bool IsWinner { get; set; } = false;
        public int Position { get; set; } = 0;
        public int TurnsToSkip { get; private set; } = 0;
        public int[] LastRolls { get; set; } = [0, 0];
        public ILogger Logger { get; }
        private IBoard _board;

        public Player(ILogger logger, IBoard board, string player_ID)
        {
            Logger = logger;
            _board = board;
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

            Logger.LogMessage("");
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
            }
            else if (TurnsToSkip > 0)
            {
                SkipTurn(this);

                Logger.LogMessage($"{this.Player_ID} didn't move this turn, has {this.TurnsToSkip} turns left to skip");
            }
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

        private void HandlePlayerEnteringSquare(int position)
        {
            ISquare square = _board.GetSquare(position);

            square.PlayerEntersSquare(this);
        }

        private void SkipTurn(Player player)
        {
            if (player.TurnsToSkip <= 0) return;

            player.TurnsToSkip--;

            if (TurnsToSkip == 0)
            {
                CanMove = true;
            }
        }
    }
}