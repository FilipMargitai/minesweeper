using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {

            GameLogic test = new GameLogic(9, 9, 15);
            test.GenerateField();

            test.PrintArray();

            Console.ReadKey();
        }
    }
}
