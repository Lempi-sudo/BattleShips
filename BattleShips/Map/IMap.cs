using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    interface IMap
    {
        void GenerationMap();
        ResultShot GetResultShot(int horizontal , int vertical);

        int CountShipOnMap();
        int SizeMap();


    }
}
