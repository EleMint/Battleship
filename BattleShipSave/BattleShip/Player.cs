using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Player
    {
        // Member Variables
        public string name;
        public GameBoard playerBoard;
        public GameBoard opponentBoard;
        public Ships battleShip;
        public Ships destroyer;
        public Ships aircraftCarrier;
        public Ships submarine;
        public List<int[]> shipPlacements = new List<int[]> { };
        public List<string> xAxis = new List<string>
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t"
        };

        // Constructor
        public Player()
        {
            playerBoard = new GameBoard();
            opponentBoard = new GameBoard();
            battleShip = new BattleShip();
            destroyer = new Destroyer();
            aircraftCarrier = new AircraftCarrier();
            submarine = new Submarine();
            
        }
        // Member Methods
        public virtual void PickShipsLocation(Ships ship, int[] startLocation)
        {
            Console.WriteLine("Pick the starting Location of your "+ship.name+ ".   Your ship's length is "+ship.length+".");
            int[] shipLocation= MoveInterpritation(Console.ReadLine());
            Console.WriteLine("Pick direction of the ship from the starting location. 'left' 'right' 'up' 'down'");
            string shipOrientation = Console.ReadLine().ToLower().Trim();
            ShipPlacement(ship, shipOrientation, startLocation);
            //playerBoard
        }
        public void ShipPlacement(Ships ship, string shipOrientation, int[] startLocation)
        {
            playerBoard.gameBoard[startLocation[0],startLocation[1]] = ship.abbreviation;
            shipPlacements.Add(startLocation);
            switch(shipOrientation)
            {
                case "left":
                    for(int i = 0; i<ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[0]-i, startLocation[1]};
                        playerBoard.gameBoard[nextLocation[0], nextLocation[1]] = ship.abbreviation;
                        shipPlacements.Add(nextLocation);
                    }
                    break;
                case "right":
                    for (int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[0]+i, startLocation[1]};
                        playerBoard.gameBoard[nextLocation[0], nextLocation[1]] = ship.abbreviation;
                        shipPlacements.Add(nextLocation);
                    }
                    break;
                case "up":
                    for (int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[0], startLocation[1]-i};
                        playerBoard.gameBoard[nextLocation[0], nextLocation[1]] = ship.abbreviation;
                        shipPlacements.Add(nextLocation);
                    }
                    break;
                case "down":
                    for (int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[0], startLocation[1]+i};
                        playerBoard.gameBoard[nextLocation[0], nextLocation[1]] = ship.abbreviation;
                        shipPlacements.Add(nextLocation);
                    }
                    break;
            }
        }
        public virtual void MakeMove()
        {
            Console.WriteLine("Please enter a valid move (Example: 'D 12')");
            int[] move = MoveInterpritation(Console.ReadLine());
            opponentBoard.UpdateBoard(move);
            

        }

        public int[] MoveInterpritation(string guessLocation)
        {
            int moveY = 0;
            string[] move = guessLocation.Trim().ToLower().Split(' ');
            int moveX = int.Parse(move[1]);
            for (int i = 0; i < xAxis.Count; i++)
            {
                if (move[0] == xAxis[i])
                {
                    moveX = i + 1;
                }
            }
            int[] moves = new int[] { moveX, moveY };
            return moves;
        }
    }
}
