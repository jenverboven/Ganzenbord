using Ganzenbord.Business.Board;
using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Game;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Players;
using Ganzenbord.Business.Squares;
using Moq;

namespace Ganzenbord.Unittests
{
    public class PlayerMovementTests
    {
        private Game SetupGame()
        {
            var mockLogger = new Mock<ILogger>();
            var mockDice = new Mock<Dice>();
            Board board = new Board(new SquareFactory());

            Game game = new Game(mockLogger.Object, board, mockDice.Object, 1);

            return game;
        }

        [Fact]
        public void WhenPlayerRollsDice_ThenPlayerMoves()
        {
            //arrange
            Game game = SetupGame();
            Player player = game.Players[0];
            player.MoveToPosition(1);
            player.LastRolls = [1, 2];

            //act
            player.Move();

            //assert
            Assert.Equal(4, player.Position);
        }

        [Fact]
        public void WhenPlayerPassesEnd_ReverseMovementDirection()
        {
            //arrange
            Game game = SetupGame();
            Player player = game.Players[0];
            player.MoveToPosition(62);
            player.LastRolls = [2, 2];

            //act
            player.Move();

            //assert
            Assert.Equal(60, player.Position);
            Assert.True(player.MovesBackwards);
        }

        [Fact]
        public void WhenPlayerMovedBackwards_ReverseFalseAtEndOfTurn()
        {
            //arrange
            Game game = SetupGame();

            Player player = game.Players[0];
            player.LastRolls = [1, 2];

            player.MoveToPosition(62);

            //act
            player.PlayTurn();

            //assert
            Assert.False(player.MovesBackwards);
        }

        [Theory]
        [InlineData(new int[] { 6, 3 }, 1, 53)]
        [InlineData(new int[] { 3, 6 }, 1, 53)]
        [InlineData(new int[] { 4, 5 }, 1, 26)]
        [InlineData(new int[] { 5, 4 }, 1, 26)]
        public void TestPlayerMoveExceptionsOnDifferentTurns(int[] diceRolls, int turn, int endPosition)
        {
            //arrange
            var mockLogger = new Mock<ILogger>();
            Board board = new Board(new SquareFactory());
            var mockDice = new Mock<Dice>();

            mockDice.Setup(dice => dice.RollDice()).Returns(diceRolls);

            Game game = new Game(mockLogger.Object, board, mockDice.Object, 1);

            Player player = game.Players[0];

            game.SetTurn(turn);

            //act
            game.PlayRound(game.Players);

            //assert
            Assert.Equal(endPosition, player.Position);
        }

        [Fact]
        public void WhenIsNotTurnOne_CheckForNoPlayerMoveException()
        {
            //arrange
            Game game = SetupGame();

            Player player = game.Players[0];
            player.MoveToPosition(1);
            player.LastRolls = [5, 4];

            game.SetTurn(2);

            //act
            player.Move();

            //assert
            Assert.Equal(10, player.Position);
        }

        [Fact]
        public void WhenPlayerMovesBackwards_PlayerCantMovePastStart()
        {
            //arrange
            var mockLogger = new Mock<ILogger>();
            Board board = new Board(new SquareFactory());

            Player player = new Player(mockLogger.Object, board, "player1");
            player.MoveToPosition(62);
            player.LastRolls = [40, 30];

            //act
            player.Move();

            //assert
            Assert.Equal(0, player.Position);
        }
    }
}