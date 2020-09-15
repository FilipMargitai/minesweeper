using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Square
    {
        public int x { get; }
        public int y { get; }
        public int surrounding { get; set; }
        public bool isBomb { get; }
    }
}
