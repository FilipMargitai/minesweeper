using System;
using System.Security.Cryptography.X509Certificates;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {

            GameLogic test = new GameLogic(9, 9, 1);
            test.GenerateField();

            while (!test.gameOver)
            {
                bool validInput = false;
                Console.Clear();
                test.PrintArray();
                while (!validInput)
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    if (input.Key == ConsoleKey.RightArrow && test.y < test.mineField.GetLength(1) - 1)
                    {
                        test.SetPosition(test.x, test.y + 1);
                        validInput = true;
                    }
                    else if (input.Key == ConsoleKey.LeftArrow && test.y > 0)
                    {
                        test.SetPosition(test.x, test.y - 1);
                        validInput = true;
                    }
                    else if (input.Key == ConsoleKey.DownArrow && test.x < test.mineField.GetLength(1) - 1)
                    {
                        test.SetPosition(test.x + 1, test.y);
                        validInput = true;
                    }
                    else if (input.Key == ConsoleKey.UpArrow && test.x > 0)
                    {
                        test.SetPosition(test.x - 1, test.y);
                        validInput = true;
                    }
                    else if(input.Key == ConsoleKey.Spacebar)
                    {
                        test.ClickSquare(test.x, test.y);
                        validInput = true;
                    }
                    else if(input.Key == ConsoleKey.F)
                    {
                        test.FlagSquare(test.x, test.y);
                        validInput = true;
                    }
                    else if(input.Key == ConsoleKey.Escape)
                    {
                        validInput = true;
                        test.gameOver = true;
                    }
                }
                test.WinCheck();
                if (test.gameOver && !test.isWin)
                {
                    foreach (Square square in test.mineField)
                    {
                        if (square.isBomb && !square.isFlaged)
                        {
                            square.isHidden = false;
                        }
                    }
                    Console.Clear();
                    test.PrintArray();
                }
                else if (test.gameOver && test.isWin)
                {
                    test.WinCheck();
                    Console.Clear();
                    test.PrintArray();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nYou won!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
