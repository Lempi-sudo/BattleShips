using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    /// <summary>
    /// Класс Gamer реализует все методы класса AbstractGamer
    /// </summary>
    class Gamer :AbstractGamer
    {
        public Gamer(IStrategy strategykind, IMap mapkind) : base(strategykind, mapkind) { }
        public override СellCoordinates madeShot()
        {
            return strategy.PickCell(this.statusCurrentStep);
        }
        public override IMap DrawMap()
        {
            map.GenerationMap();
            return map;
        }

    }
}
        
        

        
            

        

        


        

        
