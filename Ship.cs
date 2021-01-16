using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class Ship
    {
        private List<СellCoordinates> shipcoordinates;
        public List<СellCoordinates> ShipCoordinates 
        {
            get
            {
                return shipcoordinates;
            }
            
        }

        private int sizeship;
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
