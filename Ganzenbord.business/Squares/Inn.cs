﻿using Ganzenbord.Business.Players;

namespace Ganzenbord.Business.Squares
{
    internal class Inn : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.SetCanMove(false);
            player.SetTurnsToSkip(1);
            player.Logger.LogMessage($"{player.Player_ID} landed on the inn and won't be able to move for {player.TurnsToSkip} turn");
        }
    }
}