using Ganzenbord.Business;

namespace Ganzenbord.Unittests
{
    public class SquareTests
    {
        [Fact]
        public void WhenPlayerLandsOnBridge_PutPlayerOnSquare12()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(3);
            int[] diceRolls = { 1, 2 };

            //act
            player.Move(diceRolls);

            //assert
            Assert.Equal(12, player.Position);
        }

        //[Fact(Skip = "niet klaar")]
        //public void Authentication_Works()
        //{
        //    Assert.Fail();
        //}

        [Fact]
        public void WhenPlayerLandsOnInn_MakePlayerSkipTurn()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(15);
            int[] diceRolls = { 2, 2 };

            //act
            player.Move(diceRolls);

            //assert
            Assert.False(player.CanMove);
            Assert.Equal(1, player.TurnsToSkip);

            player.PlayTurn(2);

            Assert.True(player.CanMove);
            Assert.Equal(0, player.TurnsToSkip);
        }

        [Fact]
        public void WhenFirstPlayerLandsOnWell_SetCanMoveToFalse()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(29);
            int[] diceRolls = { 1, 1 };

            //act
            player.Move(diceRolls);

            //assert
            Assert.False(player.CanMove);
        }

        [Fact]
        public void WhenSecondPlayerLandsOnWell_SetCanMoveToFalseAndReleaseOtherPlayer()
        {
            //arrange
            Player player1 = new Player();
            Player player2 = new Player();
            player1.MoveToPosition(29);
            player2.MoveToPosition(29);
            int[] diceRolls = { 1, 1 };

            //act
            player1.Move(diceRolls);
            player2.Move(diceRolls);

            //assert
            Assert.True(player1.CanMove);
            Assert.False(player2.CanMove);
        }

        [Fact]
        public void WhenPlayerLandsOnMaze_PutPlayerOnSquare39()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(32);
            int[] diceRolls = { 4, 6 };

            //act
            player.Move(diceRolls);

            //assert
            Assert.Equal(39, player.Position);
        }

        [Fact]
        public void WhenPlayerLandsOnPrison_PlayerCanMoveAfterThreeTurns()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(49);
            int[] diceRolls = { 1, 2 };

            //act
            player.Move(diceRolls);
            Enumerable.Range(0, 3).ToList().ForEach(_ => player.PlayTurn(2));

            //assert
            Assert.True(player.CanMove);
            Assert.Equal(0, player.TurnsToSkip);
        }

        [Fact]
        public void WhenPlayerLandsOnPrison_PlayerCantMoveAfterOneTurn()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(49);
            int[] diceRolls = { 1, 2 };

            //act
            player.Move(diceRolls);
            player.PlayTurn(2);

            //assert
            Assert.False(player.CanMove);
            Assert.Equal(2, player.TurnsToSkip);
        }

        [Fact]
        public void WhenPlayerLandsOnDeath_PutPlayerOnStart()
        {
            //arrange
            Player player = new();
            player.MoveToPosition(53);
            int[] diceRolls = { 4, 1 };

            //act
            player.Move(diceRolls);

            //assert
            Assert.Equal(0, player.Position);
        }

        [Fact]
        public void WhenPlayerLandsOnEnd_EndGame()
        {
            //arrange
            Player player1 = new Player();
            Player player2 = new Player();

            player1.MoveToPosition(61);
            player2.MoveToPosition(1);

            int[] diceRolls = { 1, 1 };

            //act
            player1.Move(diceRolls);

            //assert
            Assert.True(Game.Instance.End);
            Assert.True(player1.IsWinner);
            Assert.False(player2.IsWinner);
        }
    }
}