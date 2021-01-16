using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{

    enum CellsKind
    {
        Water,
        Ship,
        AreaAroundShip,
        ShottedShip,
        ShottedCell
    }

     

    class Cell
    {
        private CellsKind status;
        private СellCoordinates coordinate;
        public CellsKind Status 
        { 
        get
            {
                return status;
            }
                
        set
            {
                status = value;
            }
        }

        public static bool operator ==(Cell c1, Cell c2)
        {
            return c1.coordinate == c2.coordinate;
        }
        public static bool operator !=(Cell c1, Cell c2)
        {
            return c1.coordinate != c2.coordinate;
        }

        public Cell(int horizontal, int vertical)
        {
            coordinate = new СellCoordinates(horizontal, vertical);
           
            status = CellsKind.Water;
            
            
        }

    }
}

        

   
    

    
           
    
