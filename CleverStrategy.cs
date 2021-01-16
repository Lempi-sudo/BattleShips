using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class СleverStrategy : IStrategy
    {
        public СellCoordinates PickCell(int resultPastStep)
        {
            setStatus(resultPastStep);
            throw new NotImplementedException();
        }

        private void setStatus(int resultPastStep)
        {
            this.resultPastStep = resultPastStep;
        }

        int resultPastStep = -1;
        
    }
}
