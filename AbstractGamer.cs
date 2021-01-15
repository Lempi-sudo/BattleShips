using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    abstract class AbstractGamer
    {
        public IStrategy strategy;
        public IMap map;
        public abstract int madeShot();
        public abstract IMap DrawMap();

        public AbstractGamer(IStrategy strategykind, IMap mapkind)
        {
            this.strategy = strategykind;
            this.map = mapkind;
        }



    }
}
