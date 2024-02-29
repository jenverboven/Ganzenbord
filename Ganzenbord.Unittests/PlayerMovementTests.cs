using Ganzenbord.Business;
using Ganzenbord.Business.Players;

namespace Ganzenbord.Unittests
{
    public class PlayerMovementTests
    {
        [Fact]
        public void WhenPlayerRollsDice_ThenPlayerMoves()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(1);
            int[] diceRolls = { 1, 2 };

            //act
            player.Move(diceRolls);

            //assert
            Assert.Equal(4, player.Position);
        }

        [Fact]
        public void WhenPlayerPassesEnd_ReverseMovementDirection()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(62);
            int[] diceRolls = { 1, 3 };

            //act
            player.Move(diceRolls);

            //assert
            Assert.Equal(60, player.Position);
            Assert.True(player.Reverse);
        }

        [Fact]
        public void WhenPlayerMovedBackwards_ReverseFalseAtEndOfTurn()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(62);

            //act
            player.PlayTurn(2);

            //assert
            Assert.False(player.Reverse);
        }

        [Fact]
        public void WhenIsTurnOne_CheckForPlayerMoveException1()
        {
            //arrange
            Player player = new();
            int[] diceRolls = [6, 3];
            Game.Instance.SetTurn(1);

            //act
            player.Move(diceRolls);

            //assert
            Assert.Equal(53, player.Position);
        }

        [Fact]
        public void WhenIsTurnOne_CheckForPlayerMoveException2()
        {
            //arrange
            Player player = new();
            int[] diceRolls = [4, 5];
            Game.Instance.SetTurn(1);

            //act
            player.Move(diceRolls);

            //assert
            Assert.Equal(26, player.Position);
        }

        [Fact]
        public void WhenIsNotTurnOne_CheckForNoPlayerMoveException()
        {
            //arrange
            Player player = new();
            player.MoveToPosition(1);
            int[] diceRolls = [5, 4];
            Game.Instance.SetTurn(2);

            //act
            player.Move(diceRolls);

            //assert
            Assert.Equal(10, player.Position);
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