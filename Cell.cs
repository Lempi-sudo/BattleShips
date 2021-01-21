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
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Cell p = (Cell)obj;
                return (coordinate.Horizontal == p.coordinate.Horizontal) && (coordinate.Vertical == p.coordinate.Vertical);
            }
        }
        public override int GetHashCode()
        {
            return (coordinate.Horizontal << 2) ^ coordinate.Vertical;
        }
        public Cell(int horizontal, int vertical)
        {
            coordinate = new СellCoordinates(horizontal, vertical);
           
            status = CellsKind.Water;
            
            
        }

    }
}

        

   
    

    
           
    
