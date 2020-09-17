using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class GameLogic
    {
        private int bombQuantity { get; }
        //private List<Square> mineField { get; set; }
        private Square[,] mineField { get; set; }
        private static Random randomNumb { get; set; }
        public GameLogic(int _height = 9, int _width = 9, int _bombQuantity = 14)
        {
            bombQuantity = _bombQuantity;

            mineField = new Square[_height, _width];
        }
        public void GenerateField()
        {
            for (int i = 0; i < bombQuantity; i++)
            {
                //mineField[randomNumb.Next(mineField.GetLength(0)), randomNumb.Next(mineField.GetLength(1))] = new Square(true);
                //mineField.SetValue(new Square(true), randomNumb.Next(mineField.GetLength(0)), randomNumb.Next(mineField.GetLength(1)));
            }
        }
        public void PrintArray()
        {
            int i = 0;
            foreach (Square square in mineField)
            {
                if (i < mineField.GetLength(1))
                {
                    Console.Write(PrintBomb(square));
                    i++;
                }
                else
                {
                    i = 1;
                    Console.Write("\n" + PrintBomb(square) + " ");
                }
            }
        }
        private string PrintBomb(Square square)
        {
            if (square.isHidden) return "-";
            else if (square.isBomb) return "x";
            return square.surrounding.ToString();
        }
        public void PrintTestNull()
        {
            foreach(Square square in mineField)
            {
                if (square == null) Console.Write("null ");
                else Console.Write("gut ");
            }
        }
    }
}
