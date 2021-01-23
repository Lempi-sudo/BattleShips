using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{


    /// <summary>
    /// ВИДЫ КЛЕТОК ИЛИ МОЖНО СКАЗАТЬ СОДЕРЖИМОЕ ЯЧЕЙКИ 
    /// </summary>
    enum CellsKind
    { 

        Water, // ВОДА
        Ship, // КОРАБЛЬ 
        AreaAroundShip, // ЗОНА ВОКРУГ КОРАБЛЯ , КУДА НЕЛЬЗЯ  ДРУГИЕ СТАВИТЬ КОРАБЛИ 
        ShottedShip, //Подстреленные корабль 
        ShottedCell  // Простреленная клетка 
    }

     
    /// <summary>
    /// класс КЛЕТКА игрового поля 
    /// содержит координаты ячейки и статус - содержимое .
    /// </summary>
    class Cell
    {
        /// <summary>
        /// содержимое ячейки 
        /// </summary>
        private CellsKind status;

        
        /// <summary>
        ///координаты клетки в декартовой системе координат 
        /// </summary>
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

        

   
    

    
           
    
