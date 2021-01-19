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
            return strategy.PickCell(this.statusCurrentStep);

        }

        public int CountShips()
        {
            return this.map.CountShipOnMap();
        }

        public override IMap DrawMap()
        {
            map.GenerationMap();
            return map;
        }

        public override ResultShot AnswerToShotEnemy(int horizontal, int vertical)
        {
            throw new NotImplementedException();
        }

       


    }
}
        

        
