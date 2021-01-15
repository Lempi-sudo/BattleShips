using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    abstract class AbstractGamer
    {
        protected IStrategy strategy;
        protected IMap map;
        public abstract СellCoordinates madeShot();
        public abstract IMap DrawMap();

        public AbstractGamer(IStrategy strategykind, IMap mapkind)
        {
            this.strategy = strategykind;
            this.map = mapkind;
        }



    }
}
