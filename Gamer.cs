using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class Gamer:AbstractGamer
    {
        public Gamer(IStrategy strategykind, IMap mapkind) : base(strategykind, mapkind) {}
        public override СellCoordinates madeShot()
        {
            return strategy.PickCell();
        }

        public override IMap DrawMap()
        {
            map.CreateMap();
            return map;
        }

       
    }
}
        

        
