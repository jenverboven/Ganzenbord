using Ganzenbord.Business;

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
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(4, player.Position);
        }

        [Fact]
        public void WhenPlayerPlaysTurn_ThenPlayerMoves()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(1);

            //act
            player.PlayTurn(2);

            //assert
            Assert.NotEqual(1, player.Position);
        }
    }
}