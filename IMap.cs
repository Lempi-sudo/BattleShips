using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    interface IMap
    {
        public void CreateMap();
        CellsKind getStatusCell(int horizontal , int vertical);
    }
}
