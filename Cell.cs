using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{

    enum CellsKind
    {
        Water,
        Ship
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

        public Cell(int horizontal, int vertical)
        {
            coordinate = new СellCoordinates(horizontal, vertical);
           
            status = CellsKind.Water;
            
            
        }

    }
}

        

   
    

    
           
    
