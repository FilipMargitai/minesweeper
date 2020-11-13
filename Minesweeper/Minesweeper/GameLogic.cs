using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class GameLogic
    {
        private int bombQuantity { get; }
        public Square[,] mineField { get; set; }
        private static Random randomNumb { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool gameOver { get; set; }
        public bool isWin { get; set; }
        private int flagCount { get; set; }
        private bool badFlag { get; set; }
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

                    Console.Write(PrintBomb(square));
                    if (square == mineField[x, y]) Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("  ");
                    i++;
                }
                else
                {
                    ChoseColor(square);

                    i = 1;
                    Console.Write("\n\n" + PrintBomb(square));
                    if (square == mineField[x, y]) Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("  ");
                }
            }
        }
        private string PrintBomb(Square square)
        {
            if (square.isFlaged && square.isHidden) return "F";
            else if (square.isHidden) return "-";
            else if(square.isBomb) return "x";
            return Convert.ToString(square.surrounding);
        }
        private void ChoseColor(Square square)
        {
            if (square.isFlaged && square.isHidden) Console.ForegroundColor = ConsoleColor.Cyan;
            else if (square.isBomb && !square.isHidden) Console.ForegroundColor = ConsoleColor.Red;
            else if (!square.isBomb && !square.isHidden && square.surrounding == 1) Console.ForegroundColor = ConsoleColor.White;
            else if (!square.isBomb && !square.isHidden && square.surrounding == 2) Console.ForegroundColor = ConsoleColor.Yellow;
            else if (!square.isBomb && !square.isHidden && square.surrounding > 2) Console.ForegroundColor = ConsoleColor.DarkYellow;
            else if (!square.isBomb && !square.isHidden && square.surrounding == 0) Console.ForegroundColor = ConsoleColor.DarkGray;
            else Console.ForegroundColor = ConsoleColor.White;
            if (square == mineField[x, y]) Console.BackgroundColor = ConsoleColor.DarkBlue;
            else Console.BackgroundColor = ConsoleColor.Black;
        }
        public void SetPosition(int position0, int position1)
        {
            x = position0;
            y = position1;
        }
        public void ClickSquare(int x, int y)
        {
            if(mineField[x, y].isBomb)
            {
                gameOver = true;
            }
            else
            {
                if(mineField[x, y].surrounding > 0)
                {
                    mineField[x, y].isHidden = false;
                }
                else
                {
                    mineField[x, y].has0Revealed = true;
                    mineField[x, y].isHidden = false;
                    Get0Around(x, y);
                }
            }
        }
        public void FlagSquare(int p0, int p1)
        {
            if(mineField[p0, p1].isFlaged)
            {
                mineField[p0, p1].isFlaged = false;
            }
            else if(mineField[p0, p1].isHidden)
            {
                mineField[p0, p1].isFlaged = true;
            }
        }
        public void Get0Around(int p0, int p1)
        {
            if (p0 - 1 >= 0 && p1 - 1 >= 0) TestZero(p0 - 1, p1 - 1);
            if (p1 - 1 >= 0) TestZero(p0, p1 - 1);
            if (p0 + 1 < mineField.GetLength(0) && p1 - 1 >= 0) TestZero(p0 + 1, p1 - 1);
            if (p0 - 1 >= 0) TestZero(p0 - 1, p1);
            if (p0 + 1 < mineField.GetLength(0)) TestZero(p0 + 1, p1);
            if (p0 - 1 >= 0 && p1 + 1 < mineField.GetLength(1)) TestZero(p0 - 1, p1 + 1);
            if (p1 + 1 < mineField.GetLength(1)) TestZero(p0, p1 + 1);
            if (p0 + 1 < mineField.GetLength(1) && p1 + 1 < mineField.GetLength(1)) TestZero(p0 + 1, p1 + 1);
        }
        private void TestZero(int x, int y)
        {
            if (mineField[x, y].surrounding == 0 && !mineField[x, y].has0Revealed && !mineField[x, y].isFlaged)
            {
                mineField[x, y].has0Revealed = true;
                mineField[x, y].isHidden = false;
                Get0Around(x, y);
            }
            else if(!mineField[x, y].isFlaged)
            {
                mineField[x, y].isHidden = false;
            }
        }
        public void WinCheck()
        {
            flagCount = 0;
            badFlag = false;
            foreach(Square square in mineField)
            {
                if(square.isFlaged)
                {
                    flagCount++;
                    if (!square.isBomb) badFlag = true;
                }
            }
            if (flagCount == bombQuantity && badFlag == false)
            {
                gameOver = true;
                isWin = true;
            }
        }
        public void WinFill()
        {
            foreach (Square square in mineField)
            {
                if (square.isHidden && !square.isFlaged)
                {
                    square.isHidden = false;
                }
            }
        }
    }
}
