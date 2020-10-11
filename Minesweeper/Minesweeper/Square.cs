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
        public bool isFlaged { get; set; }
        public bool has0Revealed { get; set; }
        public Square(bool _isBomb)
        {
            isBomb = _isBomb;
            isHidden = true;
            surrounding = 0; // error killer
        }
        public void GetSurrounding(Square[,] squareArray, int p0, int p1) // position0, position1
        {
            if (p0 - 1 >= 0 && p1 - 1 >= 0) TestMine(squareArray, p0 - 1, p1 - 1);
            if (p1 - 1 >= 0) TestMine(squareArray, p0, p1 - 1);
            if (p0 + 1 < squareArray.GetLength(0) && p1 - 1 >= 0) TestMine(squareArray, p0 + 1, p1 - 1);
            if (p0 - 1 >= 0) TestMine(squareArray, p0 - 1 , p1);
            if (p0 + 1 < squareArray.GetLength(0)) TestMine(squareArray, p0 + 1, p1);
            if (p0 - 1 >= 0 && p1 + 1 < squareArray.GetLength(1)) TestMine(squareArray, p0 - 1, p1 + 1);
            if (p1 + 1 < squareArray.GetLength(1)) TestMine(squareArray, p0, p1 + 1);
            if (p0 + 1 < squareArray.GetLength(1) && p1 + 1 < squareArray.GetLength(1)) TestMine(squareArray, p0 + 1, p1 + 1);
        }
        private void TestMine(Square[,] squareArray, int surrounding0, int surrounding1)
        {
            if(squareArray[surrounding0, surrounding1].isBomb)
            {
                surrounding++;
            }
        }
        public void ClickFlag()
        {
            isFlaged = true;
        }
    }
}
