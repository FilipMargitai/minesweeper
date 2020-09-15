using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class GameLogic
    {
        private int height { get; }
        private int width { get; }
        private int bombQuantity { get; }
        private List<Square> mineField { get; set; }
        public GameLogic(int _height = 9, int _width = 9, int _bombQuantity = 14)
        {
            height = _height;
            width = _width;
            bombQuantity = _bombQuantity;
        }

    }
}
