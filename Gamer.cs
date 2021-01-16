using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class Gamer:AbstractGamer
    {
        public Gamer(IStrategy strategykind, IMap mapkind) : base(strategykind, mapkind) 
        { 
            
        }
        public override СellCoordinates madeShot()
        {
            return strategy.PickCell(this.statusPastStep);

        }

       

        public override IMap DrawMap()
        {
            map.generationMap();
            return map;
        }

        //public override void receiveResultPastStep(int statusPastStep)
        //{
        //    base.statusPastStep = statusPastStep;
        //}

        /// <summary>
        /// статус прошлого шага
        /// </summary>
        

       
    }
}
        

        
