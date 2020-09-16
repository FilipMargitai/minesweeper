using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class GameLogic
    {
        private int bombQuantity { get; }
        //private List<Square> mineField { get; set; }
        private Square[,] mineField { get; set; } 
        public GameLogic(int _height = 9, int _width = 9, int _bombQuantity = 14)
        {
            bombQuantity = _bombQuantity;

            mineField = new Square[_height, _width];
        }

    }
}
