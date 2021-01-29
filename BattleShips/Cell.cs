using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    /// <summary>
    /// класс КЛЕТКА игрового поля 
    /// содержит координаты ячейки и статус - содержимое .
    /// </summary>
    class Cell
    {
        /// <summary>
        ///координаты клетки в декартовой системе координат 
        /// </summary>
        private СellCoordinates coordinate;

        /// <summary>
        /// содержимое ячейки 
        /// </summary>
        public CellsKind Status { get; set; }

        public Cell(int horizontal, int vertical)
        {
            coordinate = new СellCoordinates(horizontal, vertical);
            this.Status = CellsKind.Water;
        }

        public static bool operator !=(Cell c1, Cell c2)
        {
            return c1.coordinate != c2.coordinate;
        }
        public static bool operator ==(Cell c1, Cell c2)
        {
            return c1.coordinate == c2.coordinate;
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
       
    }
}
           
            
            



        

   
    

    
           
    
