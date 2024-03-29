﻿using Ganzenbord.Business.Board;
using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Players;

namespace Ganzenbord.Business.Game
{
    public class Game : IGame
    {
        public int Turn { get; private set; } = 1;
        public bool HasEnded { get; private set; } = false;
        public List<Player> Players;
        public int AmountDice = 2;

        private ILogger Logger;
        private readonly IBoard _board;
        public IDice Dice { get; set; }

        public Game(ILogger logger, IBoard board, IDice dice, int amountPlayers = 2)
        {
            Logger = logger;
            _board = board;
            Dice = dice;
            Players = new List<Player>();

            for (int i = 0; i < amountPlayers; i++)
            {
                Player player = new(logger, board, $"Player_{i + 1}");
                Players.Add(player);
            }
        }

        public void Start()
        {
            while (!HasEnded)
            {
                PlayRound(Players);
            }

            Player winner = Players.Single(player => player.IsWinner);
            Logger.LogMessage($"{winner.Player_ID} has landed on the end and won the game!");
        }

        public void PlayRound(List<Player> players)
        {
            Logger.LogMessage($"Starting turn {Turn}");
            Logger.LogMessage($"--------------{new string('-', Turn.ToString().Length)}");

            if (Turn == 1)
            {
                PlayFirstTurn(players);
            }
            else
            {
                PlayRegularTurn(players);
            }

            Logger.LogMessage("");

            Turn++;
        }

        private void PlayFirstTurn(List<Player> players)
        {
            foreach (Player player in players)
            {
                player.LastRolls = Dice.RollDice();
                LogDiceRolls(player);

                if (player.LastRolls.Sum() != 9)
                {
                    player.Move();
                }
                else
                {
                    MovePlayerExceptionally(player);
                }

                if (PlayerWon(player)) break;
            }
        }

        private void PlayRegularTurn(List<Player> players)
        {
            foreach (Player player in players)
            {
                player.LastRolls = Dice.RollDice();

                if (player.CanMove)
                {
                    LogDiceRolls(player);
                }

                player.PlayTurn();

                if (PlayerWon(player)) break;
            }
        }

        private static void MovePlayerExceptionally(Player player)
        {
            if (player.LastRolls.Contains(6))
            {
                player.MoveToPosition(53);
                player.Logger.LogMessage("");
            }
            else
            {
                player.MoveToPosition(26);
                player.Logger.LogMessage("");
            }
        }

        private bool PlayerWon(Player player)
        {
            if (player.IsWinner)
            {
                HasEnded = true;
                return true;
            }

            return false;
        }

        public void SetTurn(int turn)
        {
            Turn = turn;
        }

        private void LogDiceRolls(Player player)
        {
            Logger.LogMessage($"{player.Player_ID} rolled {player.LastRolls.Sum()}");
        }
    }
}