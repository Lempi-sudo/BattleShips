using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    interface IStrategy
    {
        СellCoordinates PickCell(ResultShot resultCurrentStep);
    }
}
       
