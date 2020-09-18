using System;
using System.Security.Cryptography.X509Certificates;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {

            GameLogic test = new GameLogic(9, 9, 15);
            test.GenerateField();

            test.PrintArray();

            //for(int i = 0; i < 15; i++)
            //{
            //    Console.WriteLine();
            //    int x = int.Parse(Console.ReadLine());
            //    int y = int.Parse(Console.ReadLine());

            //    Console.Clear();
            //    if (test.ClickSquare(x, y)) test.PrintArray();
            //    else break;
            //}
        }
    }
}
