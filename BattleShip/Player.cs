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
        public bool[] sunkBools; 
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
            sunkBools = new bool[4] { false, false, false, false };

        }
        // Member Methods
        public void ShipPlacement(Player guesser, Ships ship, string shipOrientation, int[] startLocation)
        {
            playerBoard.gameBoard[startLocation[0], startLocation[1]] = ship.abbreviation;
            switch (shipOrientation)
            {
                case "left":
                    for (int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] {startLocation[0], startLocation[1]-i};
                        playerBoard.gameBoard[nextLocation[0], nextLocation[1]] = ship.abbreviation;
                        guesser.shipPlacements.Add(nextLocation);
                    }
                    break;
                case "right":
                    for (
                        int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[0], startLocation[1]+i};
                        playerBoard.gameBoard[nextLocation[0], nextLocation[1]] = ship.abbreviation;
                        guesser.shipPlacements.Add(nextLocation);
                    }
                    break;
                case "up":
                    for (int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[0]-i, startLocation[1]};
                        playerBoard.gameBoard[nextLocation[0], nextLocation[1]] = ship.abbreviation;
                        guesser.shipPlacements.Add(nextLocation);
                    }
                    break;
                case "down":
                    for (int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[0] + i, startLocation[1]};
                        playerBoard.gameBoard[nextLocation[0], nextLocation[1]] = ship.abbreviation;
                        guesser.shipPlacements.Add(nextLocation);
                    }
                    break;
                default:
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
            guesser.CheckShipSunk(opponent);
            guesser.opponentBoard.DisplayBoard();
        }

        public virtual void HitChecker(int[] moveCheck, Player guesser, Player opponent)
        {
            bool ishit = false;
            for(int i = 0; i < opponent.shipPlacements.Count; i++)
            {
                if (moveCheck[0] == opponent.shipPlacements[i][0] && moveCheck[1] == opponent.shipPlacements[i][1])
                {
                    Console.WriteLine($"opponent ship placement 0: {opponent.shipPlacements[0][0]},{opponent.shipPlacements[0][1]} opponent ship placement 1: {opponent.shipPlacements[1][0]},{opponent.shipPlacements[1][1]} opponent ship placement 2: {opponent.shipPlacements[2][0]},{opponent.shipPlacements[2][1]} opponent ship placement 3: {opponent.shipPlacements[3][0]}{opponent.shipPlacements[3][1]}");
                    guesser.hits.Add(moveCheck);
                    guesser.opponentBoard.gameBoard[moveCheck[0], moveCheck[1]] = "[X]";
                    opponent.playerBoard.gameBoard[moveCheck[0], moveCheck[1]] = "[X]";
                    int shipPosition = i;
                    if (0<=shipPosition && shipPosition<=3)
                    {
                        opponent.battleShip.hitsOnShip++;
                    }
                    else if (4<=shipPosition && shipPosition<=8)
                    {
                        opponent.aircraftCarrier.hitsOnShip++;
                    }
                    else if (9<= shipPosition && shipPosition<=11)
                    {
                        opponent.submarine.hitsOnShip++;
                    }
                    else
                    {
                        opponent.destroyer.hitsOnShip++;
                    }
                    
                    UI.DisplayHit();
                    ishit = true;
                    break;
                }
                else
                {
                    guesser.opponentBoard.gameBoard[moveCheck[0], moveCheck[1]] = "[O]";
                    opponent.playerBoard.gameBoard[moveCheck[0], moveCheck[1]] = "[O]";
                }

            }
            if (!ishit)
            {
                UI.DisplayMiss();
            }
        }
        public void CheckShipSunk(Player opponent)
        {
            if (opponent.battleShip.hitsOnShip==4 && sunkBools[0]==false)
            {
                Console.WriteLine("You sunk your opponents battleship!");
                sunkBools[0] = !sunkBools[0];
            }
            else if (opponent.aircraftCarrier.hitsOnShip==5 && sunkBools[1]==false)
            {
                Console.WriteLine("You sunk your opponents aircraft carrier!");
                sunkBools[1] = !sunkBools[1];
            }
            else if (opponent.submarine.hitsOnShip==3 && sunkBools[2]==false)
            {
                Console.WriteLine("You sunk your opponents submarine");
                sunkBools[2] = !sunkBools[2];
            }
            else if (opponent.destroyer.hitsOnShip==2 && sunkBools[3]==false)
            {
                Console.WriteLine("You sunk your opponents destroyer!");
                sunkBools[3] = !sunkBools[3];
            }


        }
    }
}
