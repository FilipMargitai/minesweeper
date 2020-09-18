using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GameLogic test = new GameLogic(9, 9, 12);
            test.GenerateField();

            test.PrintArray();
        }
    }
}
