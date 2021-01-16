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
        public static bool operator ==(СellCoordinates c1, СellCoordinates c2)
        {
            if (c1.Horizontal == c2.Horizontal && c1.Vertical == c2.Vertical) return true;
            return false;
        }
        public static bool operator !=(СellCoordinates c1, СellCoordinates c2)
        {
            if (c1.Horizontal != c2.Horizontal || c1.Vertical != c2.Vertical) return true;
            return false;
        }
        public СellCoordinates(int h, int v)
        {
            horizontal = h;
            vertical = v;
        }
        

    };
}
