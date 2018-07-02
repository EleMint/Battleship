using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShip;

namespace BattleShipUnitTesting
{
    [TestClass]
    public class GameTests
    {

        [TestMethod]
        public void BS00Left_ValidPlacement_False()
        {
            Game game = new Game();
            Player player = new Player();
            int[] startLocation = new int[] { 0, 0 };
            bool expected = false;
            bool actual;

            actual = Game.ValidPlacement(player.battleShip, startLocation, "left");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BS2121Left_ValidPlacement_True()
        {
            Game game = new Game();
            Player player = new Player();
            int[] startLocation = new int[] { 21, 21 };
            bool expected = true;
            bool actual;

            actual = Game.ValidPlacement(player.battleShip, startLocation, "left");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BS03Left_ValidPlacement_False()
        {
            Game game = new Game();
            Player player = new Player();
            int[] startLocation = new int[] { 0, 3 };
            bool expected = false;
            bool actual;

            actual = Game.ValidPlacement(player.battleShip, startLocation, "left");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BS2121Right_ValidPlacement_False()
        {
            Game game = new Game();
            Player player = new Player();
            int[] startLocation = new int[] { 21, 21 };
            bool expected = false;
            bool actual;

            actual = Game.ValidPlacement(player.battleShip, startLocation, "right");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BS2015Right_ValidPlacement_False()
        {
            Game game = new Game();
            Player player = new Player();
            int[] startLocation = new int[] { 15, 20 };
            bool expected = false;
            bool actual;

            actual = Game.ValidPlacement(player.battleShip, startLocation, "right");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BS2122Right_ValidPlacement_False()
        {
            Game game = new Game();
            Player player = new Player();
            int[] startLocation = new int[] { 21, 21 };
            bool expected = false;
            bool actual;

            actual = Game.ValidPlacement(player.battleShip, startLocation, "right");

            Assert.AreEqual(expected, actual);
        }
    }
}


// Arrange
// Act
// Assert
