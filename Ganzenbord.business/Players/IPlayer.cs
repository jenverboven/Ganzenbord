﻿using Ganzenbord.Business.Logger;

namespace Ganzenbord.Business.Players
{
    public interface IPlayer
    {
        bool CanMove { get; }
        bool MovesBackwards { get; set; }
        bool IsWinner { get; set; }
        string Player_ID { get; set; }
        int Position { get; }
        int TurnsToSkip { get; }
        ILogger Logger { get; }

        void Move();

        void MoveToPosition(int position);

        void PlayTurn();

        void SetCanMove(bool canMove);

        void SetTurnsToSkip(int amountTurns);

        void SetWinner(bool isWinner);
    }
}