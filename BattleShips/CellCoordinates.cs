using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class СellCoordinates
    {
        public int Horizontal { get; }
        public int Vertical { get; }
        public СellCoordinates(int horizontal, int vertical)
        {
            this.Horizontal = horizontal;
            this.Vertical = vertical;
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
    }
}

      

      

        

