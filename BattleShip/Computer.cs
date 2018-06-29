﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BattleShip
{
    class Computer : Player
    {
        // Member Variables
        bool LastGuessHit = false;
        int[] lastHit;
        bool CurrentGuessSequence = false;
        List<int[]> CurrentGuessSequenceHits;
        int CurrentGuessSequenceCounter;
        int[] MoveThing;
        int linearGuesses = 2;
        // Constructor
        public Computer(string name)
        {
            this.name = name;
        }
        
        public override void PlayerGuess(Player guesser, Player opponent, GameBoard playerBoard)
        {
            int[] place =new int[] {0 };
            CurrentGuessSequenceHits.Add(place);
            if (CurrentGuessSequence==false)
            {
                
                int xAxis = Game.rng.Next(1, 21);
                int yAxis = Game.rng.Next(1, 21);
                MoveThing = new int[2]{ xAxis, yAxis };
                for (int i = 0; i < totalGuesses.Count; i++)
                {
                    if (totalGuesses[i] == MoveThing)
                    {
                        PlayerGuess(guesser, opponent, playerBoard);
                    }
                    else
                    {
                        totalGuesses.Add(MoveThing);

                    }
                }
                guesser.HitChecker(MoveThing, guesser, opponent);
                guesser.CheckShipSunk(opponent);
            }
            if (CurrentGuessSequence==true && CurrentGuessSequenceHits.Count==1)
            {
               
                switch(CurrentGuessSequenceCounter)
                {
                    case 0:
                        MoveThing = new int[2]{ lastHit[0]-1, lastHit[1] };
                        break;
                    case 1:
                        MoveThing = new int[2]{ lastHit[0], lastHit[1] - 1 };
                        break;
                    case 2:
                        MoveThing = new int[2]{ lastHit[0] + 1, lastHit[1] };
                        break;
                    case 3:
                        MoveThing = new int[2] { lastHit[0], lastHit[1] + 1 };
                        break;
                    default:
                        break;

                }
                CurrentGuessSequenceCounter++;
                guesser.HitChecker(MoveThing, guesser, opponent);
                guesser.CheckShipSunk(opponent);
            }
            if (CurrentGuessSequenceHits.Count>1 && CurrentGuessSequenceCounter==0 && LastGuessHit)
            {
                MoveThing = new int[] { lastHit[0] - linearGuesses, lastHit[1] };
                linearGuesses++;
                guesser.HitChecker(MoveThing, guesser, opponent);
                guesser.CheckShipSunk(opponent);
            }
            else if (CurrentGuessSequenceHits.Count > 1 && CurrentGuessSequenceCounter == 1 && LastGuessHit)
            {
                MoveThing = new int[] { lastHit[0], lastHit[1]-linearGuesses };
                linearGuesses++;
                guesser.HitChecker(MoveThing, guesser, opponent);
                guesser.CheckShipSunk(opponent);
            }
            else if (CurrentGuessSequenceHits.Count > 1 && CurrentGuessSequenceCounter == 2 && LastGuessHit)
            {
                MoveThing = new int[] { lastHit[0] + linearGuesses, lastHit[1] };
                linearGuesses++;
                guesser.HitChecker(MoveThing, guesser, opponent);
                guesser.CheckShipSunk(opponent);
            }
            else if (CurrentGuessSequenceHits.Count > 1 && CurrentGuessSequenceCounter == 3 && LastGuessHit)
            {
                MoveThing = new int[] { lastHit[0], lastHit[1] + linearGuesses };
                linearGuesses++;
                guesser.HitChecker(MoveThing, guesser, opponent);
                guesser.CheckShipSunk(opponent);
            }
            else
            {
                LastGuessHit = false;
                CurrentGuessSequence = false;
                CurrentGuessSequenceHits.Clear();
                CurrentGuessSequenceCounter = 0;
                linearGuesses = 0;

            }





            guesser.opponentBoard.DisplayBoard();

        }
        public override void PlaceShip(Player player, Ships ship)
        {
            int randomX = Game.rng.Next(1, 21);
            System.Threading.Thread.Sleep(20);
            int randomY = Game.rng.Next(1, 21);
            int[] randomStartLocation = { randomX, randomY };
            System.Threading.Thread.Sleep(20);
            int randomOri = Game.rng.Next(0, 4);
            string randomOrientation;
            bool isValid = false;
            switch (randomOri)
            {
                case 0:
                    randomOrientation = "right";
                    break;
                case 1:
                    randomOrientation = "down";
                    break;
                case 2:
                    randomOrientation = "left";
                    break;
                case 3:
                    randomOrientation = "up";
                    break;
                default:
                    randomOrientation = "right";
                    break;
            }
            
            string shipOrientation = randomOrientation;
            isValid = Game.ValidPlacement(ship, randomStartLocation, shipOrientation);
            if (player.shipPlacements.Count > 0 && isValid == true)
            {
                isValid = Game.CheckOverlappingShips(player, ship, randomStartLocation, shipOrientation);
            }
            if (isValid)
            {
                player.ShipPlacement(player, ship, shipOrientation, randomStartLocation);
                player.playerBoard.DisplayBoard();
            }
            else
            {
                this.PlaceShip(player, ship);
            }

        }
        public override void HitChecker(int[] moveCheck, Player guesser, Player opponent)
        {
            bool ishit = false;
            for (int i = 0; i < opponent.shipPlacements.Count; i++)
            {
                if (moveCheck[0] == opponent.shipPlacements[i][0] && moveCheck[1] == opponent.shipPlacements[i][1])
                {
                    lastHit = moveCheck;
                    LastGuessHit = true;
                    CurrentGuessSequence = true;
                    CurrentGuessSequenceHits.Add(moveCheck);
                    guesser.hits.Add(moveCheck);
                    guesser.opponentBoard.gameBoard[moveCheck[0], moveCheck[1]] = "[X]";
                    opponent.playerBoard.gameBoard[moveCheck[0], moveCheck[1]] = "[X]";
                    int shipPosition = i;
                    if (0 <= shipPosition && shipPosition <= 3)
                    {
                        opponent.battleShip.hitsOnShip++;
                    }
                    else if (4 <= shipPosition && shipPosition <= 8)
                    {
                        opponent.aircraftCarrier.hitsOnShip++;
                    }
                    else if (9 <= shipPosition && shipPosition <= 11)
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
                    LastGuessHit = false;
                }

            }
            if (!ishit)
            {
                UI.DisplayMiss();
            }
        }
        // Member Methods
        //public override void PickShipsLocation(string shipName, int shipLength)
        //{

        //}
        
    }
}
