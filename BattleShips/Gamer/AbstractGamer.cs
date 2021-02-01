using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    /// <summary>
    /// класс Абстрактный Игрок для описание взаимодействия ЛЮБОГО игрока с игрой(класс Game)
    /// у  Игрока есть базовые возможности для ведения игры 
    /// 1)Нарисовать карту и передать  её игре DrawMap()
    /// 2)Сделать выстрел по карте противника madeShot()
    /// 3)получить и запомнить результат прошлого хода receiveResultCurrentStep(ResultShot statuscurrentstep) 
    /// поле statusCurrentStep хранит этот результат 
    /// </summary>
    abstract class AbstractGamer
    {
        /// <summary>
        /// за выбор клетки для выстрела отвечает Поле strategy     
        /// </summary>
        protected IStrategy strategy;
        protected IMap map;
        protected ResultShot statusCurrentStep;
        public AbstractGamer(IStrategy strategykind, IMap mapkind)
        {

            this.strategy = strategykind;
            this.map = mapkind;
            this.statusCurrentStep = ResultShot.Miss;
        }
        public abstract СellCoordinates madeShot();
        public abstract IMap DrawMap();
        public virtual void receiveResultCurrentStep(ResultShot statuscurrentstep)
        {
            this.statusCurrentStep = statuscurrentstep;
        }
        
    }
}



        


       
