using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    interface IMap
    {
        public void generationMap();
        ResultShot getResultShot(int horizontal , int vertical);
    }
}
