using Ganzenbord.Business.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord.Business
{
    public class Player
    {
        public int Position { get; private set; }

        public void Move(int[] dice)
        {
            Position += dice.Sum();

            // LATER AAN TE PASSEN !!!!!!!!!!!!!!!!!!!!!!!!!!!!
            GetSquare(6);
        }

        public void MoveToPosition(int position)
        {
            this.Position = position;

            // LATER AAN TE PASSEN !!!!!!!!!!!!!!!!!!!!!!!!!!!!
            GetSquare(6);
        }

        private void GetSquare(int position)
        {
            if (position == 6)
            {
                ISquare square = new Bridge();
                square.PlayerEntersSquare(this);
            }
        }

    }
}
