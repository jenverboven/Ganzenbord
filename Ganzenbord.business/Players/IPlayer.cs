using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord.Business.Players
{
    internal interface IPlayer
    {
        public int Position { get; set; }
        public bool CanMove { get; set; }
        public int TurnsToSkip { get; set; }
        public bool Reverse { get; set; }
        public bool IsWinner { get; set; }

        public void Move(int[] diceRolls);

        public void MoveToPosition(int position);

        public void PlayTurn(int amountDice);
    }
}