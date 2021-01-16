using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    abstract class AbstractGamer
    {
        protected IStrategy strategy;
        protected IMap map;
        protected int statusPastStep;
        public abstract СellCoordinates madeShot();
        public abstract IMap DrawMap();
        public virtual void receiveResultPastStep(int statusPastStep)
        {
            this.statusPastStep = statusPastStep;
        }
        

        public AbstractGamer(IStrategy strategykind, IMap mapkind)
        {
            this.strategy = strategykind;
            this.map = mapkind;
            this.statusPastStep = 0;
        }
       


    }
}
