using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class СellCoordinates
    {
        private int horizontal;
        private int vertical;
        public int Horizontal
        {
            get
            {
                return horizontal;
            }

        }
        public int Vertical
        {
            get
            {
                return vertical;
            }

        }
        public СellCoordinates(int h, int v)
        {
            horizontal = h;
            vertical = v;
        }

    };
}
