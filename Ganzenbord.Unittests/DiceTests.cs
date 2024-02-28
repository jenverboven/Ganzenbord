using Ganzenbord.Business;

namespace Ganzenbord.Unittests
{
    public class DiceTests
    {
        [Fact]
        public void WhenRollTwoDice_ReturnArrayOfTwoIntegers()
        {
            //arrange
            Player player = new Player();

            //act
            int[] rolls = player.RollDice(2);

            //assert
            Assert.Equal(2, rolls.Length);
            Assert.All(rolls, item => Assert.IsType<int>(item));
        }
    }
}