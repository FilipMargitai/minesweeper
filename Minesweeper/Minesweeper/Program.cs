﻿using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[,] array2D = new int[3, 3];

            array2D.SetValue(1, 0, 0);
            array2D.SetValue(2, 0, 1);
            array2D.SetValue(3, 0, 2);
            array2D.SetValue(4, 1, 0);
            array2D.SetValue(5, 1, 1);
            array2D.SetValue(6, 1, 2);
            array2D.SetValue(7, 2, 0);
            array2D.SetValue(8, 2, 1);
            array2D.SetValue(9, 2, 2);

            int i = 0;


            foreach (int numb in array2D)
            {
                if(i < array2D.GetLength(1))
                {
                    Console.Write(numb + " ");
                    i++;
                }
                else
                {
                    i = 1;
                    Console.Write("\n" + numb + " ");
                }
            }
        }
    }
}
