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
            this.PlaceShip(player1, player1.aircraftCarrier);
            this.PlaceShip(player1, player1.submarine);
            this.PlaceShip(player1, player1.destroyer);
            Console.ReadLine();
            Console.Clear();
            this.PlaceShip(player2, player2.battleShip);
            this.PlaceShip(player2, player2.aircraftCarrier);
            this.PlaceShip(player2, player2.submarine);
            this.PlaceShip(player2, player2.destroyer);
            Console.ReadLine();
            Console.Clear();
            do
            {
                player1.PlayerGuess(player1, player2, player1.playerBoard);
                gameOver = IsGameOver(player1, player2);
                if(gameOver)
                {
                    break;
                }
                player2.PlayerGuess(player2, player1, player2.playerBoard);
                gameOver = IsGameOver(player1, player2);
                if(gameOver)
                {
                    break;
                }
            }
            while (!gameOver);
            Console.WriteLine("Game is over");
            Console.ReadLine();
        }


        public void PlaceShip(Player player, Ships ship)
        {
            bool isValid = false;
            Console.WriteLine($"{player.name} Enter Starting Location Of {ship.name}");
            string shipPlacement = Console.ReadLine();
            //TODO: Validate
            Console.WriteLine("Enter Its Orientation: \r\n('Up', 'Down', 'Left', 'Right')");
            string shipOrientation = Console.ReadLine();
            //TODO: Validate
            isValid = ValidPlacement(ship, player.MoveInterpritation(shipPlacement), shipOrientation);
            if (player.shipPlacements.Count>0 && isValid == true)
            {
                isValid = CheckOverlappingShips(player, ship, player.MoveInterpritation(shipPlacement), shipOrientation);
            }
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
        public bool CheckOverlappingShips(Player player, Ships ship, int[] startLocation, string shipOrientation)
        {
            List<int[]> currentPlacement = new List<int[]> { };
            switch (shipOrientation)
            {
                case "left":
                    for (int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[0], startLocation[1] - i };
                        currentPlacement.Add(nextLocation);
                    }
                    break;
                case "right":
                    for (
                        int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[0], startLocation[1] + i };
                        currentPlacement.Add(nextLocation);
                    }
                    break;
                case "up":
                    for (int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[0] - i, startLocation[1] };
                        currentPlacement.Add(nextLocation);
                    }
                    break;
                case "down":
                    for (int i = 0; i < ship.length; i++)
                    {
                        int[] nextLocation = new int[] { startLocation[0] + i, startLocation[1] };
                        currentPlacement.Add(nextLocation);
                    }
                    break;
            }
            for(int i= 0; i<currentPlacement.Count;i++)
            {
                for (int j = 0; j<player.shipPlacements.Count; j++)
                {
                    if (currentPlacement[i][0] == player.shipPlacements[j][0] && currentPlacement[i][1] == player.shipPlacements[j][1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool IsGameOver(Player player1, Player player2)
        {
            if(player1.sunkBools[0] == true && player1.sunkBools[1] == true && player1.sunkBools[2] == true && player1.sunkBools[3] == true )
            {
                return true;
            }
            if (player2.sunkBools[0] == true && player2.sunkBools[1] == true && player2.sunkBools[2] == true && player2.sunkBools[3] == true)
            {
                return true;
            }
            return false;
        }
    }
}
