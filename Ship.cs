using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class Ship
    {
        public List<СellCoordinates> shipcoordinates;
        public int sizeship;
        
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


                

        public List<СellCoordinates> ShipCoordinates 
        {
            get
            {
                return shipcoordinates;
            }
            
        }
        public int SizeShip
        {
            get
            {
                return sizeship;
            }
        }
        public Ship(int sizeship)
        {
            this.sizeship = sizeship;
            shipcoordinates = new List<СellCoordinates>();
        }
        public Ship(List<СellCoordinates> shipcoordinates)
        {
            this.sizeship = shipcoordinates.Count;
            this.shipcoordinates = shipcoordinates;
        }
            
    }
}

        
            
            


