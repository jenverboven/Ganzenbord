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
            int[] diceRolls = player.RollDice(2);

            //assert
            Assert.Equal(2, diceRolls.Length);
            Assert.All(diceRolls, item => Assert.IsType<int>(item));
        }
    }
}