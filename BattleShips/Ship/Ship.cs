using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class Ship
    {
        /// <summary>
        /// Список координат коробля 
        /// </summary>
        private List<СellCoordinates> shipcoordinates;
        public List<СellCoordinates> ShipCoordinates
        {
            get
            {
                return shipcoordinates;
            }

        }

        /// <summary>
        /// размер коробля = количество палуб
        /// </summary>
        private int sizeship;
        public int SizeShip
        {
            get
            {
                return this.sizeship;
            }
        }

        public Ship(List<СellCoordinates> shipcoordinates)
        {
            this.sizeship = shipcoordinates.Count;
            this.shipcoordinates = shipcoordinates;
        }

        /// <summary>
        /// метод вычеркивает клетку с данными коорданатами из списка клеток корабля 
        /// </summary>
        /// <param name="horizontal"> координата по горизондали </param>
        /// <param name="vertical">координата по вертикали  </param>
        /// <returns>  
        /// если есть корабль с данными координатами и его размер >1 вернет damage 
        /// если есть корабль с данными координатами и его размер ==1 вернет KILL
        /// если нет корабля с данными координатами вернет MISS
        /// </returns>
        public ResultShot ShotOnShip(int horizontal, int vertical)
        {
            СellCoordinates shotcell = new СellCoordinates(horizontal, vertical);
            for (int i = 0; i < shipcoordinates.Count; i++)
            {
                if(shipcoordinates[i] == shotcell)
                {
                    shipcoordinates.RemoveAt(i);
                    sizeship--;
                    if(shipcoordinates.Count==0)
                    {
                        return  ResultShot.Kill;
                    }
                    else
                    {
                        return ResultShot.Damage;
                    }
                }
            }
            return ResultShot.Miss;
        }

    }
}


                

       
       




       
      
            

        
            
            


