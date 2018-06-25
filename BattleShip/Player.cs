using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Add Hits and Misses Logic
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
        public List<int[]> totalGuesses;
        public List<int[]> hits;

        // Constructor
        public Player()
        {
            playerBoard = new GameBoard();
            opponentBoard = new GameBoard();
            battleShip = new BattleShip();
            destroyer = new Destroyer();
            aircraftCarrier = new AircraftCarrier();
            submarine = new Submarine();
            totalGuesses = new List<int[]> { };

        }
        // Member Methods
        public void ShipPlacement(Ships ship, string shipOrientation, int[] startLocation)
        {
            playerBoard.gameBoard[startLocation[0], startLocation[1]] = ship.abbreviation;
            shipPlacements.Add(startLocation);
            switch (shipOrientation)
            {
                case "left":
                    for (int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[1] - i, startLocation[0] };
                        playerBoard.gameBoard[nextLocation[1], nextLocation[0]] = ship.abbreviation;
                        shipPlacements.Add(nextLocation);
                    }
                    break;
                case "right":
                    for (int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[1] + i, startLocation[0] };
                        playerBoard.gameBoard[nextLocation[1], nextLocation[0]] = ship.abbreviation;
                        shipPlacements.Add(nextLocation);
                    }
                    break;
                case "up":
                    for (int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[1], startLocation[0] - i };
                        playerBoard.gameBoard[nextLocation[1], nextLocation[0]] = ship.abbreviation;
                        shipPlacements.Add(nextLocation);
                    }
                    break;
                case "down":
                    for (int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[1], startLocation[0] + i };
                        playerBoard.gameBoard[nextLocation[1], nextLocation[0]] = ship.abbreviation;
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
            int moveX = 0;
            string[] move = guessLocation.Trim().ToLower().Split(' ');
            int moveY = int.Parse(move[1]);
            for (int i = 0; i < xAxis.Count; i++)
            {
                if (move[0] == xAxis[i])
                {
                    moveX = i + 1;
                }
            }
            int[] moves = new int[] { moveY, moveX };
            return moves;
        }

        public virtual void PlayerGuess(GameBoard playerBoard)
        {
            Console.WriteLine("Enter a valid guess");
            string guessMove = Console.ReadLine().ToLower().Trim();
            int[] MoveThing = MoveInterpritation(guessMove);
            for(int i = 0; i<totalGuesses.Count; i++)
            {
                if(totalGuesses[i] == MoveThing)
                {
                    Console.WriteLine("Please enter a valid choice");
                    PlayerGuess(playerBoard);
                }
                else
                {
                    totalGuesses.Add(MoveThing);

                }
            }
        }

        public virtual void HitChecker(int[] moveCheck)
        {
            for(int i = 0; i)
        }
    }
}
