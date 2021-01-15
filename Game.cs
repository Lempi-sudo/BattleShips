using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class Game
    {
        private AbstractGamer firstGamer;
        private AbstractGamer secondGamer;

        private IMap mapFirstGamer;
        private IMap mapSecondGamer;

        public Game(AbstractGamer firstGamer, AbstractGamer secondGamer)
        {
            this.firstGamer = firstGamer;
            this.secondGamer = secondGamer;

            this.mapFirstGamer = firstGamer.DrawMap();
            this.mapSecondGamer = secondGamer.DrawMap();
        }
    }
}
            
           


        

