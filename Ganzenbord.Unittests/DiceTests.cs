using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Players;
using Moq;

namespace Ganzenbord.Unittests
{
    public class DiceTests
    {
        [Fact]
        public void WhenRollTwoDice_ReturnArrayOfTwoIntegers()
        {
            //arrange
            Dice dice = new(2);

            //act
            int[] diceRolls = dice.RollDice();

            //assert
            Assert.Equal(2, diceRolls.Length);
            Assert.All(diceRolls, item => Assert.IsType<int>(item));
        }
    }
}