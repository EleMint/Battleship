using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShip;

namespace BattleShipUnitTesting
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void BS11Left_ValipPlacement_False()
        {
            Game game = new Game();
            Player player = new Player();
            int[] startLocation = new int[] { 1, 1 };
            bool expected = false;
            bool actual;

            actual = Game.ValidPlacement(player.battleShip, startLocation, "left");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BS11Right_ValipPlacement_False()
        {
            Game game = new Game();
            Player player = new Player();
            int[] startLocation = new int[] { 1, 1 };
            bool expected = true;
            bool actual;

            actual = Game.ValidPlacement(player.battleShip, startLocation, "right");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BS11Up_ValipPlacement_False1()
        {
            Game game = new Game();
            Player player = new Player();
            int[] startLocation = new int[] { 1, 1 };
            bool expected = false;
            bool actual;

            actual = Game.ValidPlacement(player.battleShip, startLocation, "up");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BS11Down_ValipPlacement_False()
        {
            Game game = new Game();
            Player player = new Player();
            int[] startLocation = new int[] { 1, 1 };
            bool expected = true;
            bool actual;

            actual = Game.ValidPlacement(player.battleShip, startLocation, "down");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BS1414Right_CheckOverlapping_xAxis_True()
        {
            Player player = new Player();
            int[] startLocation = new int[] { 14, 14 };
            int xAxis = 15;
            int yAxis = 15;
            int[] FilledLocation1 = { xAxis, yAxis };
            int[] FilledLocation2 = { xAxis + 1, yAxis };
            int[] FilledLocation3 = { xAxis + 2, yAxis };
            int[] FilledLocation4 = { xAxis + 3, yAxis };
            player.shipPlacements.Add(FilledLocation1);
            player.shipPlacements.Add(FilledLocation2);
            player.shipPlacements.Add(FilledLocation3);
            player.shipPlacements.Add(FilledLocation4);
            bool expected = true;
            bool actual;

            actual = Game.CheckOverlappingShips(player, player.battleShip, startLocation, "right");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BS1414Down_CheckOverlapping_xAxis_True()
        {
            Player player = new Player();
            int[] startLocation = new int[] { 14, 14 };
            int xAxis = 15;
            int yAxis = 15;
            int[] FilledLocation1 = { xAxis, yAxis };
            int[] FilledLocation2 = { xAxis + 1, yAxis };
            int[] FilledLocation3 = { xAxis + 2, yAxis };
            int[] FilledLocation4 = { xAxis + 3, yAxis };
            player.shipPlacements.Add(FilledLocation1);
            player.shipPlacements.Add(FilledLocation2);
            player.shipPlacements.Add(FilledLocation3);
            player.shipPlacements.Add(FilledLocation4);
            bool expected = true;
            bool actual;

            actual = Game.CheckOverlappingShips(player, player.battleShip, startLocation, "down");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BS1414Left_CheckOverlapping_xAxis_True()
        {
            Player player = new Player();
            int[] startLocation = new int[] { 14, 14 };
            int xAxis = 15;
            int yAxis = 15;
            int[] FilledLocation1 = { xAxis, yAxis };
            int[] FilledLocation2 = { xAxis + 1, yAxis };
            int[] FilledLocation3 = { xAxis + 2, yAxis };
            int[] FilledLocation4 = { xAxis + 3, yAxis };
            player.shipPlacements.Add(FilledLocation1);
            player.shipPlacements.Add(FilledLocation2);
            player.shipPlacements.Add(FilledLocation3);
            player.shipPlacements.Add(FilledLocation4);
            bool expected = true;
            bool actual;

            actual = Game.CheckOverlappingShips(player, player.battleShip, startLocation, "left");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BS1414Up_CheckOverlapping_xAxis_True()
        {
            Player player = new Player();
            int[] startLocation = new int[] { 14, 14 };
            int xAxis = 15;
            int yAxis = 15;
            int[] FilledLocation1 = { xAxis, yAxis };
            int[] FilledLocation2 = { xAxis + 1, yAxis };
            int[] FilledLocation3 = { xAxis + 2, yAxis };
            int[] FilledLocation4 = { xAxis + 3, yAxis };
            player.shipPlacements.Add(FilledLocation1);
            player.shipPlacements.Add(FilledLocation2);
            player.shipPlacements.Add(FilledLocation3);
            player.shipPlacements.Add(FilledLocation4);
            bool expected = true;
            bool actual;

            actual = Game.CheckOverlappingShips(player, player.battleShip, startLocation, "up");

            Assert.AreEqual(expected, actual);
        }
    }
}
