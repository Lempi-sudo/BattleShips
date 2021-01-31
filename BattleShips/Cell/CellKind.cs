using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    /// <summary>
    /// ВИДЫ КЛЕТОК 
    /// </summary>
    enum CellsKind
    {

        Water, // ВОДА
        Ship, // КОРАБЛЬ 
        AreaAroundShip, // ЗОНА ВОКРУГ КОРАБЛЯ , КУДА НЕЛЬЗЯ  ДРУГИЕ СТАВИТЬ КОРАБЛИ 
        ShottedShip, //Подстреленные корабль 
        ShottedCell  // Простреленная клетка 
    }
}
