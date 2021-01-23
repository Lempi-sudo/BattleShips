using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class Ship
    {
        private List<СellCoordinates> shipcoordinates;
        private int sizeship;
        public int SizeShip
        {
            get
            {
                return sizeship;
            }
        }

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
        public Ship(List<СellCoordinates> shipcoordinates)
        {
            this.sizeship = shipcoordinates.Count;
            this.shipcoordinates = shipcoordinates;
        }
    }
}
       
      
            

        
            
            


