using Ganzenbord.Business.Board;
using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Game;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Players;
using Ganzenbord.Business.Squares;
using Moq;

namespace Ganzenbord.Unittests
{
    public class GooseTests
    {
        private Game SetupGame()
        {
            var mockLogger = new Mock<ILogger>();
            var mockDice = new Mock<Dice>();
            Board board = new Board(new SquareFactory());

            Game game = new Game(mockLogger.Object, board, mockDice.Object, 1);

            return game;
        }

        [Theory]
        [InlineData(new int[] { 1, 1 }, 3, 7)]
        [InlineData(new int[] { 3, 1 }, 10, 22)]
        public void WhenPlayerLandsOnGoose_AndPlayerMovingForward_PlayerGetsMovedForward(int[] diceRolls, int startPosition, int endPosition)
        {
            //arrange
            var mockLogger = new Mock<ILogger>();
            Board board = new Board(new SquareFactory());
            Player player = new Player(mockLogger.Object, board, "player1");
            player.MoveToPosition(startPosition);
            player.LastRolls = diceRolls;

            //act
            player.Move();

            //assert
            Assert.Equal(endPosition, player.Position);
        }

        [Theory]
        [InlineData(new int[] { 3, 3 }, 61, 53)]
        [InlineData(new int[] { 3, 2 }, 62, 49)]
        public void WhenPlayerLandsOnGoose_AndPlayerMovingBackwards_PlayerGetsMovedBackwards(int[] diceRolls, int startPosition, int endPosition)
        {
            //arrange
            var mockLogger = new Mock<ILogger>();
            Board board = new Board(new SquareFactory());
            Player player = new Player(mockLogger.Object, board, "player1");
            player.MoveToPosition(startPosition);
            player.LastRolls = diceRolls;

            //act
            player.Move();

            //assert
            Assert.Equal(endPosition, player.Position);
        }

        [Theory]
        [InlineData(new int[] { 5, 4 }, 1)]
        [InlineData(new int[] { 4, 5 }, 1)]
        [InlineData(new int[] { 6, 3 }, 1)]
        [InlineData(new int[] { 3, 6 }, 1)]
        [InlineData(new int[] { 5, 4 }, 2)]
        [InlineData(new int[] { 4, 5 }, 2)]
        [InlineData(new int[] { 6, 3 }, 2)]
        [InlineData(new int[] { 3, 6 }, 2)]
        public void WhenPlayerIsOnStart_AndPlayerRolls9_PlayerWinsIfNotTurn1(int[] diceRolls, int turn)
        {
            //arrange
            var mockLogger = new Mock<ILogger>();
            Board board = new(new SquareFactory());
            var mockDice = new Mock<Dice>();

            mockDice.Setup(dice => dice.RollDice()).Returns(diceRolls);

            Game game = new Game(mockLogger.Object, board, mockDice.Object, 1);

            Player player = game.Players[0];

            game.SetTurn(turn);

            //act
            game.PlayRound(game.Players);

            //assert
            if (turn == 1)
            {
                Assert.False(player.IsWinner);
                Assert.False(game.HasEnded);
            }
            else
            {
                Assert.True(player.IsWinner);
                Assert.True(game.HasEnded);
            }
        }
    }
}