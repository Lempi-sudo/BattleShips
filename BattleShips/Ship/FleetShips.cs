using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    /// <summary>
    /// Флот кораблей - все корабли которые есть на карте 
    /// </summary>
    class FleetShips
    {

        private List<Ship> shipslist;

        /// <summary>
        /// проверка выстрела по всем кораблям 
        /// для каждого кораблся из списка shipslist вызывается метод ShotOnShip
        /// который возвращает результат выстрела по заданным координатам 
        /// </summary>
        /// <param name="horizontal"> координата по горизонтали </param>
        /// <param name="vertical">координата по вертикали </param>
        /// <returns>возвращает резульат выстрела </returns>
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
