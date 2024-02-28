using Ganzenbord.Business;
using Ganzenbord.Business.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

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
            //Assert.True(player.CanMove);
        }

        [Fact]
        public void WhenPlayerLandsOnMaze_PutPlayerOnSquare39()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(31);
            int[] dice = { 5, 6 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(39, player.Position);
        }

        [Fact]
        public void WhenPlayerLandsOnDeath_PutPlayerOnStart()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(53);
            int[] dice = { 4, 1 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(0, player.Position);
        }
    }
}