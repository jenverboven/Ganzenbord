using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord.Business.Squares
{
    internal class Death : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.MoveToPosition(0);
        }
    }
}