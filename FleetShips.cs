using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class FleetShips
    {
        private List<Ship> shipslist;

        public ResultShot ShotOnShips(int horizontal, int vertical)
        {
            ResultShot resultshot= ResultShot.Miss;
            for (int i = 0; i < shipslist.Count; i++)
            {
                resultshot = shipslist[i].ShotOnShip(horizontal, vertical);
                if (resultshot != ResultShot.Miss) break;
            }
            return resultshot;
        }



        public int CountShip()
        {
            return shipslist.Count;
        }
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
