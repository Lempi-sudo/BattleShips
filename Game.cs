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

        private Logger logger;

        public Game(AbstractGamer firstgamer, AbstractGamer secondgamer,string filename)
        {
            this.firstGamer = firstgamer;
            this.secondGamer = secondgamer;

            this.mapFirstGamer = firstGamer.DrawMap();
            this.mapSecondGamer = secondGamer.DrawMap();

            this.countShipsFirsrGr = mapFirstGamer.CountShipOnMap();
            this.countShipsSecondGr = mapSecondGamer.CountShipOnMap();

            this.logger = new Logger(filename);
        

           
        }

        private bool isGameOver()
        {
            if (countShipsFirsrGr == 0 || countShipsSecondGr == 0) return true;
            return false;
        }

        private bool isCountinuesStep(ResultShot resultshot)
        {
             
            if (( resultshot == ResultShot.Kill || resultshot == ResultShot.Damage ) && !isGameOver()) 
            {
                return true;
            }
            return false;
        }
            

        private string WhoIsWin()
        {
            if(countShipsFirsrGr==0)
            {
                return "Second Gamer";
            }
            if (countShipsSecondGr == 0)
            {
                return "First Gamer";
            }
            return "";
        }


        



        public void letsStartGame()
        {
            
            do 
            {
                stepFirsGamer();

                if (isGameOver()) break;

                stepSecondGamer();

            } while (!isGameOver());
            logger.WriteWinner(WhoIsWin());


        }


        private void stepFirsGamer()
        {

            ResultShot resultshot;
            СellCoordinates cell;
            logger.WriteGamer("First Gamer");
            do
            {
                cell = firstGamer.madeShot();
                resultshot = mapSecondGamer.GetResultShot(cell.Horizontal, cell.Vertical);
                logger.WriteShot(cell, resultshot);
                firstGamer.receiveResultCurrentStep(resultshot);

                if (resultshot == ResultShot.Kill)
                {
                    countShipsSecondGr--;
                    if (isGameOver()) break;
                }
            } while (isCountinuesStep(resultshot));
        }

            
              
               


        private void stepSecondGamer()
        {
            ResultShot resultshot;
            СellCoordinates cell;
            logger.WriteGamer("Second Gamer");
            do
            {
                cell = secondGamer.madeShot();
                resultshot = mapFirstGamer.GetResultShot(cell.Horizontal, cell.Vertical);
                logger.WriteShot(cell, resultshot);
                secondGamer.receiveResultCurrentStep(resultshot);
                if (resultshot == ResultShot.Kill)
                {
                    countShipsFirsrGr--;
                    if (isGameOver()) break;
                }

            } while (isCountinuesStep(resultshot));

        }

    }

                        


                        

            
            
            
}

            
           


        

