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

            randomNumb = new Random();
        }
        public void GenerateField()
        {
            for (int i = 0; i < bombQuantity;) // bomb generation
            {
                int randomX = randomNumb.Next(mineField.GetLength(0));
                int randomY = randomNumb.Next(mineField.GetLength(1));
                if(mineField[randomX, randomY] == null)
                {
                    mineField[randomX, randomY] = new Square(true);
                    i++;
                }
                //mineField.SetValue(new Square(true), randomNumb.Next(mineField.GetLength(0)), randomNumb.Next(mineField.GetLength(1)));
            }
            for (int i = 0; i < mineField.GetLength(0); i++) // filling up non bomb squares
            {
                for(int j = 0; j < mineField.GetLength(1); j++)
                {
                    if(mineField[i, j] == null)
                    {
                        mineField[i, j] = new Square(false);
                    }
                }
            }  
            for (int i = 0; i < mineField.GetLength(0); i++) // filling up surrounding
            {
                for(int j = 0; j < mineField.GetLength(1); j++)
                {
                    mineField[i, j].GetSurrounding(mineField, i, j);
                }
            }
        }
        public void PrintArray()
        {
            int i = 0;
            foreach (Square square in mineField)
            {
                if (i < mineField.GetLength(1))
                {
                    ChoseColor(square);

                    Console.Write(PrintBomb(square) + "   ");
                    i++;
                }
                else
                {
                    ChoseColor(square);

                    i = 1;
                    Console.Write("\n\n" + PrintBomb(square) + "   ");
                }
            }
        }
        private string PrintBomb(Square square)
        {
            if (square.isFlaged) return "🏴";
            else if (square.isHidden) return "-";
            else if(square.isBomb) return "x";
            return Convert.ToString(square.surrounding);
        }
        private void ChoseColor(Square square)
        {
            if (square.isFlaged) Console.ForegroundColor = ConsoleColor.Blue;
            else if (square.isBomb && !square.isHidden) Console.ForegroundColor = ConsoleColor.Red;
            else if (!square.isBomb && !square.isHidden) Console.ForegroundColor = ConsoleColor.White;
            else Console.ForegroundColor = ConsoleColor.Gray;
        }
        //public bool ClickSquare(int x, int y)
        //{
        //    if(mineField[x, y].ClickSquare())
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public void PrintTestNull()
        //{
        //    foreach (Square square in mineField)
        //    {
        //        if (square == null) Console.Write("n ");
        //        else if (square.isBomb) Console.Write("b ");
        //        else if (!square.isBomb) Console.Write("- ");
        //    }
        //}
    }
}
