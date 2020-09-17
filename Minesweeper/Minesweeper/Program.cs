using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GameLogic test = new GameLogic(3, 3, 8);
            test.GenerateField();

            test.PrintTestNull();
        }
    }
}
