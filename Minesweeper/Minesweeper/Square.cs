using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Square
    {
        public int surrounding { get; set; }
        public bool isBomb { get; }
        public Square(bool _isBomb)
        {
            isBomb = _isBomb;
        }
        public void GetSurrounding()
        {
            //TODO
        }
    }
}
