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

            this.mapFirstGamer.
        }

        public void letsStartGame()
        {
            stepFirsGamer();
            stepSecondGamer();

        }


        private void stepFirsGamer()
        {
            CellsKind cellKind;
            bool continuationMove = false;
            do
            {
                СellCoordinates cell = firstGamer.madeShot();
                cellKind = mapSecondGamer.getStatusCell(cell.Horizontal, cell.Vertical);
                
                switch(cellKind)
                {
                    case CellsKind.Ship: 
                        continuationMove = true;
                        firstGamer.receiveResultPastStep(1);
                        break;
                    case CellsKind.Water:
                        firstGamer.receiveResultPastStep(0);
                        break;
                }

            } while (continuationMove);
        }


            
            
            


        private void stepSecondGamer()
        {

        }
    }
}

            
           


        

