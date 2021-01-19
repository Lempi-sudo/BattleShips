using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    abstract class AbstractGamer
    {
        protected IStrategy strategy;
        protected IMap map;
        protected ResultShot statusCurrentStep;
        public abstract СellCoordinates madeShot();
        public abstract IMap DrawMap();
        public virtual void receiveResultCurrentStep(ResultShot statuscurrentstep)
        {
            this.statusCurrentStep = statuscurrentstep;
        }

        public abstract ResultShot AnswerToShotEnemy(int horizontal, int vertical);

        public AbstractGamer(IStrategy strategykind, IMap mapkind)
        {
            this.strategy = strategykind;
            this.map = mapkind;
            this.statusCurrentStep = ResultShot.Miss;
        }
       


    }
}
