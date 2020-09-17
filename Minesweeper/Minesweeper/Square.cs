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
            isHidden = true;
            surrounding = 0; // error killer
        }
        public void GetSurrounding()
        {
            //TODO
        }
    }
}
