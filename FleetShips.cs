using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class FleetShips
    {
        public List<Ship> shipslist;
        public FleetShips()
        {
            shipslist = new List<Ship>();
        }
        public void AddShip(Ship ship)
        {
            shipslist.Add(ship);
        }
    }
}
