using Ganzenbord.Business;
using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Players;
using Moq;

namespace Ganzenbord.Unittests
{
    public class PlayerMovementTests
    {
        [Fact]
        public void WhenPlayerRollsDice_ThenPlayerMoves()
        {
            //arrange
            var mockLogger = new Mock<ILogger>();
            var mockDice = new Mock<Dice>();
            Game game = new Game(mockLogger.Object, mockDice.Object, 1);
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
            var mockLogger = new Mock<ILogger>();
            var mockDice = new Mock<Dice>();
            Game game = new Game(mockLogger.Object, mockDice.Object, 1);
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
            var mockLogger = new Mock<ILogger>();
            var mockDice = new Mock<Dice>();
            Game game = new Game(mockLogger.Object, mockDice.Object, 1);

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
            var mockDice = new Mock<Dice>();

            mockDice.Setup(dice => dice.RollDice()).Returns(diceRolls);

            Game game = new Game(mockLogger.Object, mockDice.Object, 1);

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
            var mockLogger = new Mock<ILogger>();
            var mockDice = new Mock<Dice>();
            Game game = new Game(mockLogger.Object, mockDice.Object, 1);
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
            Player player = new Player("player1");
            player.MoveToPosition(62);
            player.LastRolls = [40, 30];

            //act
            player.Move();

            //assert
            Assert.Equal(0, player.Position);
        }

        //[Fact]
        //public void WhenPlayerPlaysTurn_ThenPlayerMoves()
        //{
        //    //arrange
        //    Player player = new Player();
        //    player.MoveToPosition(1);

        //    //act
        //    player.PlayTurn(2);

        //    //assert
        //    Assert.NotEqual(1, player.Position);
        //}
    }
}