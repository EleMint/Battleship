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

            //check input validity
            //pass ship into ShipPlacement()
            //
        }
        
        public void PlaceBattleShip(Player player, GameBoard playerBoard)
        {
            Console.WriteLine("Enter Starting Location Of BattleShip: ");
            string battleShip = Console.ReadLine();
            Console.WriteLine("Enter Its Orientation: \r\n('Up', 'Down', 'Left', 'Right')");
            string battleShipOrientation = Console.ReadLine();
            bool isValid = ValidPlacement(player.battleShip, player.MoveInterpritation(battleShip), battleShipOrientation);
            if(isValid)
            {
                playerBoard.UpdateBoard(player.MoveInterpritation(battleShip));
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
                playerBoard.UpdateBoard(player.MoveInterpritation(aircraftShip));
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
                playerBoard.UpdateBoard(player.MoveInterpritation(submarine));
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
            bool isValid = ValidPlacement(player.submarine, player.MoveInterpritation(destroyerShip), destroyerOrientation);
            if (isValid)
            {
                playerBoard.UpdateBoard(player.MoveInterpritation(destroyerShip));
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
            if (shipOrientation == "left" || shipOrientation == "right")
            {
                if (startLocation[0] - ship.length <= 0 || startLocation[0] + ship.length >= 21)
                {
                    return false;
                }
                else return true;
            }
            else if (shipOrientation == "up" || shipOrientation == "down")
            {
                if (startLocation[1] <= 0 - ship.length || startLocation[1] + ship.length >= 21)
                {
                    return false;
                }
                else return true;
            }
            else return false;
        }

    }
}
