using System;
using System.Collections.Generic;
using System.Text;





namespace BattleShips
{
    class Game
    {
        private AbstractGamer firstGamer;
        private AbstractGamer secondGamer;

        private int countShipsFirsrGr;
        private int countShipsSecondGr;

        private IMap mapFirstGamer;
        private IMap mapSecondGamer;

        public Game(AbstractGamer firstgamer, AbstractGamer secondgamer)
        {
            this.firstGamer = firstgamer;
            this.secondGamer = secondgamer;

            this.mapFirstGamer = firstGamer.DrawMap();
            this.mapSecondGamer = secondGamer.DrawMap();

            this.countShipsFirsrGr = mapFirstGamer.CountShipOnMap();
            this.countShipsSecondGr = mapSecondGamer.CountShipOnMap();
        

           
        }

        private bool isGameOver()
        {
            if (countShipsFirsrGr == 0 && countShipsSecondGr == 0) return true;
            return false;
        }

        private bool isCountinuesStep(ResultShot resultshot)
        {
             
            if (( resultshot == ResultShot.Kill || resultshot == ResultShot.Damage ) && !isGameOver()) //заменить как в методе letsstart
            {
                return true;
            }
            return false;
        }
            




        



        public void letsStartGame()
        {
            
            do // надо изменить это плохо но работает
            {
                stepFirsGamer();

                if (isGameOver()) break;

                stepSecondGamer();

            } while (isGameOver());



        }


        private void stepFirsGamer()
        {

            ResultShot resultshot;
            СellCoordinates cell;
          
            do
            {
                cell = firstGamer.madeShot();
                resultshot = mapSecondGamer.GetResultShot(cell.Horizontal, cell.Vertical);
                firstGamer.receiveResultCurrentStep(resultshot);
                if (resultshot == ResultShot.Kill) countShipsSecondGr -= 1;
           
            } while (isCountinuesStep(resultshot));
        }

            
              
               


        private void stepSecondGamer()
        {
            ResultShot resultshot;
            СellCoordinates cell;

            do
            {
                cell = secondGamer.madeShot();
                resultshot = mapFirstGamer.GetResultShot(cell.Horizontal, cell.Vertical);
                secondGamer.receiveResultCurrentStep(resultshot);
                if (resultshot == ResultShot.Kill) countShipsFirsrGr -= 1;

            } while (isCountinuesStep(resultshot));

        }

    }

                        


                        

            
            
            
}

            
           


        

