using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Game
    {
        // Member Variables
        public Player player1;
        public Player player2;
        public GameBoard player1GameBoard;
        public GameBoard player2GameBoard;
        public bool gameOver;
        // Constructor
        public Game()
        {

        }

        // Member Methods

        public void RunGame()
        {
            int numberOfComputers;
            bool correctMode;
            this.PickGameType();

            Console.WriteLine("\r\nWelcome To: BattleShip");

            do
            {
                Console.WriteLine("\r\n" + "Press '1' for Single-Player, '2' for Multi-Player, or '3' for A Show Down Between Computers.");
                string userInput = Console.ReadLine();
                correctMode = (userInput == "1" || userInput == "2" || userInput == "3");
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("\r\n" + "Please Enter Your Name:");
                        player1 = new Human(Console.ReadLine());
                        player2 = new Computer("Computer");
                        numberOfComputers = 1;
                        this.MainGame();
                        break;
                    case "2":
                        Console.WriteLine("\r\n" + "Player 1, Please Enter Your Name:");
                        player1 = new Human(Console.ReadLine());
                        Console.WriteLine("\r\n" + "Player 2, Please Enter Your Name:");
                        player2 = new Human(Console.ReadLine());
                        numberOfComputers = 0;
                        this.MainGame();
                        break;
                    case "3":
                        player1 = new Computer("Computer1");
                        player2 = new Computer("Computer2");
                        numberOfComputers = 2;
                        this.MainGame();
                        break;
                    default:
                        Console.WriteLine("\r\n" + "Please Try Again With The Described Game Modes");
                        break;
                }
            }
            while (correctMode == false);
        }

        public void MainGame()
        {

            this.PlaceShip(player1, player1.battleShip);
            //this.PlaceShip(player1, player1.aircraftCarrier);
            //this.PlaceShip(player1, player1.submarine);
            //this.PlaceShip(player1, player1.destroyer);
            Console.WriteLine(player1.shipPlacements[0] + " " + player1.shipPlacements[1]);
            Console.ReadLine();
            Console.Clear();
            this.PlaceShip(player2, player2.battleShip);
            //this.PlaceShip(player2, player2.aircraftCarrier);
            //this.PlaceShip(player2, player2.submarine);
            //this.PlaceShip(player2, player2.destroyer);
            Console.WriteLine(player2.shipPlacements[0] + " " + player2.shipPlacements[1]);
            Console.ReadLine();
            Console.Clear();
            do
            {
                player1.PlayerGuess(player1, player2, player1.playerBoard);
                player2.PlayerGuess(player2, player1, player2.playerBoard);
                gameOver = IsGameOver(player1, player2);
            }
            while (!gameOver);
            Console.WriteLine("Game is over");
            Console.ReadLine();
            //check input validity
            //pass ship into ShipPlacement()
            //
        }


        public void PlaceShip(Player player, Ships ship)
        {
            bool isValid = false;
            Console.WriteLine($"{player.name} Enter Starting Location Of {ship.name}");
            string shipPlacement = Console.ReadLine();
            Console.WriteLine("Enter Its Orientation: \r\n('Up', 'Down', 'Left', 'Right')");
            string shipOrientation = Console.ReadLine();
            isValid = ValidPlacement(ship, player.MoveInterpritation(shipPlacement), shipOrientation);
            if (isValid)
            {
                player.ShipPlacement(player, ship, shipOrientation, player.MoveInterpritation(shipPlacement));
                player.playerBoard.DisplayBoard();
            }
            else
            {
                this.PlaceShip(player, ship);
            }
        }


        public void PickGameType()
        {
            GameBoard gameBoard1 = new GameBoard();
            gameBoard1.DisplayBoard();
        }

        public bool ValidPlacement(Ships ship, int[] startLocation, string shipOrientation)
        {
            Console.Write(startLocation[1]);
            Console.Write(startLocation[0]);
            Console.WriteLine();

            switch (shipOrientation)
            {
                case "left":
                    if (startLocation[1] - ship.length <= 1)
                    {
                        return false;
                    }
                    else return true;
                case "right":
                    if (startLocation[1] + ship.length >= 21)
                    {
                        return false;
                    }
                    else return true;
                case "up":
                    if (startLocation[0] - ship.length <= 1)
                    {
                        return false;
                    }
                    else return true;
                case "down":
                    if (startLocation[0] + ship.length >= 21)
                    {
                        return false;
                    }
                    else return true;
                default:
                    return false;
            }
        }
        public bool IsGameOver(Player player1, Player player2)
        {
            if (player1.hits.Count == 14 || player2.hits.Count == 14)
            {
                return true;
            }
            return false;
        }
    }
}
