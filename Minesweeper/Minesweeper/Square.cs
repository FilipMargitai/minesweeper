using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Square
    {
        public int surrounding { get; set; }
        public bool isBomb { get; }
        public bool isHidden { get; set; }
        public Square(bool _isBomb)
        {
            isBomb = _isBomb;
            isHidden = false;
            surrounding = 0; // error killer
        }
        public void GetSurrounding(Square[,] squareArray, int p0, int p1) // position0, position1
        {
            if (p0 - 1 >= 0 && p1 - 1 >= 0) TestBomb(squareArray, p0 - 1, p1 - 1);
            if (p1 - 1 >= 0) TestBomb(squareArray, p0, p1 - 1);
            if (p0 + 1 < squareArray.GetLength(0) && p1 - 1 >= 0) TestBomb(squareArray, p0 + 1, p1 - 1);
            if (p0 - 1 >= 0) TestBomb(squareArray, p0 - 1 , p1);
            if (p0 + 1 < squareArray.GetLength(0)) TestBomb(squareArray, p0 + 1, p1);
            if (p0 - 1 >= 0 && p1 + 1 < squareArray.GetLength(1)) TestBomb(squareArray, p0 - 1, p1 + 1);
            if (p1 + 1 < squareArray.GetLength(1)) TestBomb(squareArray, p0, p1 + 1);
            if (p0 + 1 < squareArray.GetLength(1) && p1 + 1 < squareArray.GetLength(1)) TestBomb(squareArray, p0 + 1, p1 + 1);
        }
        private void TestBomb(Square[,] squareArray, int surroundin0, int surroundin1)
        {
            if(squareArray[surroundin0, surroundin1].isBomb)
            {
                surrounding++;
            }
        }
        public void ClickSquare()
        {
            // TODO
        }
        public void ClickFlag()
        {
            // TODO
        }
    }
}
