﻿using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Logic
    {
        public Logic()
        {
        }

        public static string MoveIsAllowed(GameBoard gameBoard, string location)
        {
            string o_typeMove = "";
            if (!MoveStringIsValid(location, gameBoard.BoardSize))
            {
                o_typeMove = "The location was not given in the right format";
            }
            else
            {
                int xStartingPoint = location[0] - 'A' + 1;
                int yStartingPoint = location[1] - 'a' + 1;
                int xEndingPoint = location[3] - 'A' + 1;
                int yEndingPoint = location[4] - 'a' + 1;

                // Check starting point is not empty and is the rigth color
                if (SquareIsFree(gameBoard, yStartingPoint, xStartingPoint))
                {
                    o_typeMove = "No coin at starting position";
                    // Check destination tile to be free
                }
                else if (!SquareIsFree(gameBoard, xEndingPoint, yEndingPoint))
                {
                    o_typeMove = "The destination is already occupied by a coin";
                }
                else
                {
                    o_typeMove = "The move is not legal";

                    if (IsSimpleMove('0', yStartingPoint, xStartingPoint, yEndingPoint, xEndingPoint))
                    {
                        o_typeMove = yEndingPoint + "," + xEndingPoint;
                    }
                    else if (IsJump('0', yStartingPoint, xStartingPoint, yEndingPoint, xEndingPoint))
                    {
                        int xMidllePoint = (xStartingPoint + xEndingPoint) / 2;
                        int yMidllePoint = (yStartingPoint + yEndingPoint) / 2;

                        if (CoinExistAtLocation(gameBoard, yMidllePoint, xMidllePoint, 'O'))
                        {
                            o_typeMove = yEndingPoint + "," + xEndingPoint;
                        }
                    }
                }
            }
            return o_typeMove;
        }


        public static bool MoveStringIsValid(string location, int sizeBoard)
        {
            bool moveStringIsValid = true;
            if (location.Length != 5)
            {
                moveStringIsValid = !moveStringIsValid;
            }
            else if (!char.IsUpper(location[0]) || (location[0] > ('A' + sizeBoard - 2)))
            {
                moveStringIsValid = !moveStringIsValid;
            }
            else if (!char.IsLower(location[1]) || (location[1] > ('a' + sizeBoard - 2)))
            {
                moveStringIsValid = !moveStringIsValid;
            }
            else if ('>'.CompareTo(location[2]) != 0)
            {
                moveStringIsValid = !moveStringIsValid;
            }
            else if (!char.IsUpper(location[3]) || (location[3] > 'A' + sizeBoard - 2))
            {
                moveStringIsValid = !moveStringIsValid;
            }
            else if (!char.IsLower(location[4]) || (location[4] > 'a' + sizeBoard - 2))
            {
                moveStringIsValid = !moveStringIsValid;
            }
            return moveStringIsValid;
        }



        public static bool CoinExistAtLocation(GameBoard gameBoard,
            int xStartingPoint, int yStartingPoint, char color)
        {
            bool o_coinExistAtLocation = true;

            if (gameBoard.Board[xStartingPoint, yStartingPoint] == null ||
            gameBoard.Board[xStartingPoint, yStartingPoint].CoinColor.CompareTo(color) != 0)
            {
                o_coinExistAtLocation = !o_coinExistAtLocation;
            }
            return o_coinExistAtLocation;
        }


        public static bool SquareIsFree(GameBoard gameBoard,
            int xPoint, int yPoint)
        {
            bool o_coinDestinationIsFree = true;

            if (gameBoard.Board[xPoint, yPoint] != null)
            {
                o_coinDestinationIsFree = !o_coinDestinationIsFree;
            }

            return o_coinDestinationIsFree;
        }


        public static bool IsSimpleMove(char playerColor, int xStartingPoint,
            int yStartingPoint, int xEndingPoint, int yEndingPoint)
        {
            bool isSimpleMove = true;
            if (Math.Abs(xEndingPoint - xStartingPoint) == 1 &&
                Math.Abs(yEndingPoint - yStartingPoint) == 1)
            {
                if (playerColor.CompareTo('O') == 0)
                {
                    if (yEndingPoint < yStartingPoint)
                    {
                        isSimpleMove = !isSimpleMove;
                    }
                }
                else if (playerColor.CompareTo('X') == 0)
                {
                    if (yEndingPoint > yStartingPoint)
                    {
                        isSimpleMove = !isSimpleMove;
                    }
                }
            }
            else
            {
                isSimpleMove = !isSimpleMove;
            }
            return isSimpleMove;
        }

        public static bool IsJump(char playerColor, int xStartingPoint,
            int yStartingPoint, int xEndingPoint, int yEndingPoint)
        {
            bool isJump = true;
            if (Math.Abs(xEndingPoint - xStartingPoint) == 2 &&
                Math.Abs(yEndingPoint - xStartingPoint) == 2)
            {
                if (playerColor.CompareTo('O') == 0)
                {
                    if (yEndingPoint < yStartingPoint)
                    {
                        isJump = !isJump;
                    }
                }
                else if (playerColor.CompareTo('X') == 0)
                {
                    if (yEndingPoint > yStartingPoint)
                    {
                        isJump = !isJump;
                    }
                }
            }
            else
            {
                isJump = !isJump;
            }
            return isJump;
        }

    }
}
