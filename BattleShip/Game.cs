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
            this.PlaceBattleShip(player1, player1.playerBoard);
            this.PlaceAircraftCarrier(player1, player1.playerBoard);
            this.PlaceSubmarine(player1, player1.playerBoard);
            this.PlaceDestroyer(player1, player1.playerBoard);
            Console.Clear();
            player2.playerBoard.DisplayBoard();
            this.PlaceBattleShip(player2, player2.playerBoard);
            this.PlaceAircraftCarrier(player2, player2.playerBoard);
            this.PlaceSubmarine(player2, player2.playerBoard);
            this.PlaceDestroyer(player2, player2.playerBoard);
            Console.Clear();

            //check input validity
            //pass ship into ShipPlacement()
            //
        }
        
        public void PlaceBattleShip(Player player, GameBoard playerBoard)
        {
            Console.WriteLine(player.name + ", Please Enter Starting Location Of BattleShip: ");
            string battleShip = Console.ReadLine();
            Console.WriteLine("Enter Its Orientation: \r\n('Up', 'Down', 'Left', 'Right')");
            string battleShipOrientation = Console.ReadLine();
            bool isValid = ValidPlacement(player.battleShip, player.MoveInterpritation(battleShip), battleShipOrientation);
            if(isValid)
            {
                player.ShipPlacement(player.battleShip, battleShipOrientation, player.MoveInterpritation(battleShip));
                playerBoard.DisplayBoard();
            }
            else
            {
                this.PlaceBattleShip(player, playerBoard);
            }
        }
        public void PlaceAircraftCarrier(Player player, GameBoard playerBoard)
        {
            Console.WriteLine("Enter Starting Location Of Aircraft Carrier: ");
            string aircraftShip = Console.ReadLine();
            Console.WriteLine("Enter Its Orientation: \r\n('Up', 'Down', 'Left', 'Right')");
            string aircraftOrientation = Console.ReadLine();
            bool isValid = ValidPlacement(player.aircraftCarrier, player.MoveInterpritation(aircraftShip), aircraftOrientation);
            if (isValid)
            {
                player.ShipPlacement(player.aircraftCarrier, aircraftOrientation, player.MoveInterpritation(aircraftShip));
                playerBoard.DisplayBoard();
            }
            else
            {
                this.PlaceAircraftCarrier(player, playerBoard);
            }
        }
        public void PlaceSubmarine(Player player, GameBoard playerBoard)
        {
            Console.WriteLine("Enter Starting Location Of Submarine: ");
            string submarine = Console.ReadLine();
            Console.WriteLine("Enter Its Orientation: \r\n('Up', 'Down', 'Left', 'Right')");
            string submarineOrientation = Console.ReadLine();
            bool isValid = ValidPlacement(player.submarine, player.MoveInterpritation(submarine), submarineOrientation);
            if (isValid)
            {
                player.ShipPlacement(player.submarine, submarineOrientation, player.MoveInterpritation(submarine));
                playerBoard.DisplayBoard();
            }
            else
            {
                this.PlaceSubmarine(player, playerBoard);
            }
        }
        public void PlaceDestroyer(Player player, GameBoard playerBoard)
        {
            Console.WriteLine("Enter Starting Location Of Destroyer: ");
            string destroyerShip = Console.ReadLine();
            Console.WriteLine("Enter Its Orientation: \r\n('Up', 'Down', 'Left', 'Right')");
            string destroyerOrientation = Console.ReadLine();
            bool isValid = ValidPlacement(player.destroyer, player.MoveInterpritation(destroyerShip), destroyerOrientation);
            if (isValid)
            {
                player.ShipPlacement(player.destroyer, destroyerOrientation, player.MoveInterpritation(destroyerShip));
                playerBoard.DisplayBoard();
            }
            else
            {
                this.PlaceDestroyer(player, playerBoard);
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

            switch(shipOrientation)
            {
                case "left":
                    if(startLocation[0] - ship.length <= 0)
                    {
                        return false;
                    }
                    else return true;
                case "right":
                    if (startLocation[0] + ship.length >= 21)
                    {
                        return false;
                    }
                    else return true;
                case "up":
                    if (startLocation[1] - ship.length <= 0)
                    {
                        return false;
                    }
                    else return true;
                case "down":
                    if (startLocation[1] + ship.length >= 21)
                    {
                        return false;
                    }
                    else return true;
                default:
                    return false;
            }
        }

    }
}
