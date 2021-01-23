using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    /// <summary>
    /// Интерфейс стратегия 
    /// содежит единственный метод PickCell 
    /// входной параметр - результат предыдущего выстрела 
    /// возвращает координаты клетки для выстрела 
    /// </summary>
    interface IStrategy
    {
        СellCoordinates PickCell(ResultShot resultCurrentStep);
    }
}
       
