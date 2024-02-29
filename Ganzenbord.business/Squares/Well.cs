using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord.Business.Squares
{
    internal class Well : ISquare
    {
        public int Position { get; set; }

        private Player? CaughtPlayer { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            if (CaughtPlayer != null)
            {
                CaughtPlayer.SetCanMove(true);
            }

            player.SetCanMove(false);
            CaughtPlayer = player;
        }
    }
}