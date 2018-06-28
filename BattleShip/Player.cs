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
        public List<int[]> shipPlacements;
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
            shipPlacements = new List<int[]> { };
            hits = new List<int[]> { };

        }
        // Member Methods
        public void ShipPlacement(Player guesser, Ships ship, string shipOrientation, int[] startLocation)
        {
            playerBoard.gameBoard[startLocation[0], startLocation[1]] = ship.abbreviation;
            guesser.shipPlacements.Add(startLocation);
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
                        guesser.shipPlacements.Add(nextLocation);
                        Console.WriteLine(shipPlacements);
                        Console.WriteLine(nextLocation[0] + " "+ nextLocation[1]);
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
            opponentBoard.DisplayBoard();


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

        public virtual void PlayerGuess(Player guesser, Player opponent, GameBoard playerBoard)
        {
            Console.WriteLine($"{guesser.name} Enter A Guess Location:");
            string guessMove = Console.ReadLine().ToLower().Trim();
            int[] MoveThing = MoveInterpritation(guessMove);
            for(int i = 0; i<totalGuesses.Count; i++)
            {
                if(totalGuesses[i] == MoveThing)
                {
                    Console.WriteLine("Please enter a valid choice");
                    PlayerGuess(guesser, opponent, playerBoard);
                }
                else
                {
                    totalGuesses.Add(MoveThing);

                }
            }
            guesser.HitChecker(MoveThing, guesser, opponent);
            guesser.opponentBoard.DisplayBoard();
        }

        public virtual void HitChecker(int[] moveCheck, Player guesser, Player opponent)
        {
            for(int i = 0; i < opponent.shipPlacements.Count; i++)
            {
                if (moveCheck[0] == opponent.shipPlacements[i][0] && moveCheck[1] == opponent.shipPlacements[i][1])
                {
                    guesser.hits.Add(moveCheck);
                    guesser.opponentBoard.gameBoard[moveCheck[0], moveCheck[1]] = "[X]";
                    opponent.playerBoard.gameBoard[moveCheck[0], moveCheck[1]] = "[X]";
                    UI.DisplayHit();
                    break;
                }
                else
                {
                    guesser.opponentBoard.gameBoard[moveCheck[0], moveCheck[1]] = "[O]";
                    opponent.playerBoard.gameBoard[moveCheck[0], moveCheck[1]] = "[O]";
                    UI.DisplayMiss();
                }
            }
        }
    }
}
