using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShip;

namespace BattleShipUnitTesting
{ 
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void D12_MoveInterperitation_412()
        {
            Player player = new Player();
            int[] expected = new int[] {12, 4};
            int[] actual;

            actual = player.MoveInterpritation("d 12");

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }
        [TestMethod]
        public void D4_MoveInterperitation_44()
        {
            Player player = new Player();
            int[] expected = new int[] { 4, 4 };
            int[] actual;

            actual = player.MoveInterpritation("D 4");

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }
        [TestMethod]
        public void A1_MoveInterperitation_11()
        {
            Player player = new Player();
            int[] expected = new int[] { 1, 1 };
            int[] actual;

            actual = player.MoveInterpritation(" a 1 ");

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }
        [TestMethod]
        public void B20_MoveInterperitation_22()
        {
            Player player = new Player();
            int[] expected = new int[] { 20, 2 };
            int[] actual;

            actual = player.MoveInterpritation("b20");

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }
        [TestMethod]
        public void D14_MoveInterperitation_414()
        {
            Player player = new Player();
            int[] expected = new int[] { 14, 4 };
            int[] actual;

            actual = player.MoveInterpritation(" dd 14");

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }
        [TestMethod]
        public void C3_MoveInterperitation_33()
        {
            Player player = new Player();
            int[] expected = new int[] { 3, 3 };
            int[] actual;

            actual = player.MoveInterpritation(" c3 ");

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }
        [TestMethod]
        public void BSA1Right_ShipPlacement_Valid()
        {
            Player guesser = new Player();
            int[] startLocation = new int[] { 1, 1 };
            string[] expected = new string[] { "[B]", "[B]", "[B]", "[B]" };


            guesser.ShipPlacement(guesser, guesser.battleShip, "right", startLocation);
            string[] actual = new string[] { guesser.playerBoard.gameBoard[1, 1], guesser.playerBoard.gameBoard[1, 2], guesser.playerBoard.gameBoard[1, 3], guesser.playerBoard.gameBoard[1, 4] };
            

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }
        [TestMethod]
        public void BSA5Up_ShipPlacement_Valid()
        {
            Player guesser = new Player();
            int[] startLocation = new int[] { 4, 1 };
            string[] expected = new string[] { "[B]", "[B]", "[B]", "[B]" };

            guesser.ShipPlacement(guesser, guesser.battleShip, "up", startLocation);
            string[] actual = new string[] { guesser.playerBoard.gameBoard[4, 1], guesser.playerBoard.gameBoard[3, 1], guesser.playerBoard.gameBoard[2, 1], guesser.playerBoard.gameBoard[1, 1], };

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }
        [TestMethod]
        public void BSA5Left_ShipPlacement_Valid()
        {
            Player guesser = new Player();
            int[] startLocation = new int[] { 1, 4 };
            string[] expected = new string[] { "[B]", "[B]", "[B]", "[B]" };

            guesser.ShipPlacement(guesser, guesser.battleShip, "left", startLocation);
            string[] actual = new string[] { guesser.playerBoard.gameBoard[1, 4], guesser.playerBoard.gameBoard[1, 3], guesser.playerBoard.gameBoard[1, 2], guesser.playerBoard.gameBoard[1, 1] };

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }
        [TestMethod]
        public void BSA1Down_ShipPlacement_Valid()
        {
            Player guesser = new Player();
            int[] startLocation = new int[] { 1, 1 };
            string[] begining = new string[] { "[B]", "[B]", "[B]", "[B]" };
            string[] expected = begining;

            guesser.ShipPlacement(guesser, guesser.battleShip, "down", startLocation);
            string[] actual = new string[] { guesser.playerBoard.gameBoard[1, 1], guesser.playerBoard.gameBoard[2, 1], guesser.playerBoard.gameBoard[3, 1], guesser.playerBoard.gameBoard[4, 1] };

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }
    }
}
//public virtual void ShipPlacement(Player guesser, Ships ship, string shipOrientation, int[] startLocation)
//{
//    playerBoard.gameBoard[startLocation[0], startLocation[1]] = ship.abbreviation;
//    switch (shipOrientation)
//    {
//        case "left":
//            for (int i = 0; i < ship.length; i++)
//            {
//                int[] nextLocation = new int[] { startLocation[0], startLocation[1] - i };
//                playerBoard.gameBoard[nextLocation[0], nextLocation[1]] = ship.abbreviation;
//                guesser.shipPlacements.Add(nextLocation);
//            }
//            break;
//        case "right":
//            for (
//                int i = 0; i < ship.length; i++)
//            {
//                int[] nextLocation = new int[] { startLocation[0], startLocation[1] + i };
//                playerBoard.gameBoard[nextLocation[0], nextLocation[1]] = ship.abbreviation;
//                guesser.shipPlacements.Add(nextLocation);
//            }
//            break;
//        case "up":
//            for (int i = 0; i < ship.length; i++)
//            {
//                int[] nextLocation = new int[] { startLocation[0] - i, startLocation[1] };
//                playerBoard.gameBoard[nextLocation[0], nextLocation[1]] = ship.abbreviation;
//                guesser.shipPlacements.Add(nextLocation);
//            }
//            break;
//        case "down":
//            for (int i = 0; i < ship.length; i++)
//            {
//                int[] nextLocation = new int[] { startLocation[0] + i, startLocation[1] };
//                playerBoard.gameBoard[nextLocation[0], nextLocation[1]] = ship.abbreviation;
//                guesser.shipPlacements.Add(nextLocation);
//            }
//            break;
//        default:
//            break;
//    }
//}
