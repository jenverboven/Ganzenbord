using Ganzenbord.Business.Board;
using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Game;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Players;
using Ganzenbord.Business.Squares;
using Moq;

namespace Ganzenbord.Unittests
{
    public class SquareTests
    {
        private Game SetupGame(int amountPlayers)
        {
            var mockLogger = new Mock<ILogger>();
            var mockDice = new Mock<Dice>();
            Board board = new Board(new SquareFactory());

            Game game = new Game(mockLogger.Object, board, mockDice.Object, amountPlayers);

            return game;
        }

        // Bridge
        // ------
        [Fact]
        public void WhenPlayerLandsOnBridge_PutPlayerOnSquare12()
        {
            //arrange
            Game game = SetupGame(1);

            Player player = game.Players[0];

            player.MoveToPosition(3);
            player.LastRolls = [1, 2];

            //act
            player.Move();

            //assert
            Assert.Equal(12, player.Position);
        }

        // Inn
        // ---
        [Fact]
        public void WhenPlayerLandsOnInn_MakePlayerSkipTurn()
        {
            //arrange
            Game game = SetupGame(1);

            Player player = game.Players[0];

            player.MoveToPosition(15);
            player.LastRolls = [2, 2];

            //act
            player.Move();

            //assert
            Assert.False(player.CanMove);
            Assert.Equal(1, player.TurnsToSkip);

            player.PlayTurn();

            Assert.True(player.CanMove);
            Assert.Equal(0, player.TurnsToSkip);
        }

        // Well
        // ----
        [Fact]
        public void WhenFirstPlayerLandsOnWell_SetCanMoveToFalse()
        {
            //arrange
            Game game = SetupGame(1);

            Player player = game.Players[0];

            player.MoveToPosition(29);
            player.LastRolls = [1, 1];

            //act
            player.Move();

            //assert
            Assert.False(player.CanMove);
        }

        [Fact]
        public void WhenSecondPlayerLandsOnWell_SetCanMoveToFalseAndReleaseOtherPlayer()
        {
            //arrange
            Game game = SetupGame(2);

            Player player1 = game.Players[0];
            Player player2 = game.Players[1];

            player1.MoveToPosition(29);
            player2.MoveToPosition(29);
            player1.LastRolls = [1, 1];
            player2.LastRolls = [1, 1];

            //act
            player1.Move();
            player2.Move();

            //assert
            Assert.True(player1.CanMove);
            Assert.False(player2.CanMove);
        }

        // Maze
        // ----
        [Fact]
        public void WhenPlayerLandsOnMaze_PutPlayerOnSquare39()
        {
            //arrange
            var mockLogger = new Mock<ILogger>();
            Board board = new Board(new SquareFactory());
            Player player = new Player(mockLogger.Object, board, "player1");

            player.MoveToPosition(34);
            player.LastRolls = [5, 3];

            //act
            player.Move();

            //assert
            Assert.Equal(39, player.Position);
        }

        // Prison
        // ------
        [Fact]
        public void WhenPlayerLandsOnPrison_PlayerCanMoveAfterThreeTurns()
        {
            //arrange
            Game game = SetupGame(1);

            Player player = game.Players[0];

            player.MoveToPosition(49);
            player.LastRolls = [1, 2];

            //act
            player.Move();

            //play 3 turns
            Enumerable.Range(0, 3).ToList().ForEach(_ => player.PlayTurn());

            //assert
            Assert.True(player.CanMove);
            Assert.Equal(0, player.TurnsToSkip);
        }

        [Fact]
        public void WhenPlayerLandsOnPrison_PlayerCantMoveAfterOneTurn()
        {
            //arrange
            Game game = SetupGame(1);
            Player player = game.Players[0];

            player.MoveToPosition(49);
            player.LastRolls = [1, 2];

            //act
            player.Move();
            player.PlayTurn();

            //assert
            Assert.False(player.CanMove);
            Assert.Equal(2, player.TurnsToSkip);
        }

        // Death
        // -----
        [Fact]
        public void WhenPlayerLandsOnDeath_PutPlayerOnStart()
        {
            //arrange
            Game game = SetupGame(1);

            Player player = game.Players[0];

            player.MoveToPosition(53);
            player.LastRolls = [4, 1];

            //act
            player.Move();

            //assert
            Assert.Equal(0, player.Position);
        }

        // End
        // ---
        [Fact]
        public void WhenPlayerLandsOnEnd_EndGame()
        {
            //arrange
            var mockLogger = new Mock<ILogger>();
            Board board = new Board(new SquareFactory());
            var mockDice = new Mock<Dice>();

            mockDice.SetupSequence(dice => dice.RollDice())
                .Returns([1, 1])
                .Returns([2, 3]);

            Game game = new Game(mockLogger.Object, board, mockDice.Object, 2);

            Player player1 = game.Players[0];
            Player player2 = game.Players[1];

            player1.MoveToPosition(61);
            player2.MoveToPosition(1);

            //act
            game.PlayRound(game.Players);

            //assert
            Assert.True(game.HasEnded);
            Assert.True(player1.IsWinner);
            Assert.False(player2.IsWinner);
        }

        // Voorbeeld van test die geskipt moet worden

        //[Fact(Skip = "niet klaar")]
        //public void Authentication_Works()
        //{
        //    Assert.Fail();
        //}
    }
}