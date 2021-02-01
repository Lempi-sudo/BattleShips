namespace BattleShips
{
    /// <summary>
    /// Данный класс реализует логику игры между двумя игроками.
    /// Можно сравнить данный класс с независымым судьёй, который следить за поряком проведения игры, чтобы никто не нарушал правила.  
    /// </summary>
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
        
        /// <summary>
        /// проверка на конец игры 
        /// </summary>
        /// <returns>true - конец игры   false- партия продолжается </returns>
        private bool isGameOver()
        {
            if (countShipsFirsrGr == 0 || countShipsSecondGr == 0) return true;
            return false;
        }

        /// <summary>
        /// проверка на продолжение хода игрока 
        /// </summary>
        /// <param name="resultshot"></param>
        /// <returns>
        /// true - если ход продолжается
        /// false- право хода переходит к следующему игроку 
        /// </returns>
        private bool isCountinuesStep(ResultShot resultshot)
        {
            if (( resultshot == ResultShot.Kill || resultshot == ResultShot.Damage ) && !isGameOver()) 
            {
                return true;
            }
            return false;
        }
             
        /// <summary>
        /// метод для записи в файл победителя в партии
        /// </summary>
        /// <returns>возвращает имя игрока победившего в партии</returns>
        private string stringWhoIsWin()
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
           
        /// <summary>
        /// метод для подсчета количества побед в турнире 
        /// </summary>
        /// <returns>возвращает номер победившего игрока </returns>
        public int numberWhoIsWin()
        {
            if (countShipsFirsrGr == 0)
            {
                return 2;
            }
            if (countShipsSecondGr == 0)
            {
                return 1;
            }
            return 0;
        }

        public void letsStartGame()
        {
            //главный цикл игры. условие выхода из цикла - конец игры, метод isGameOver() должен вернуть true
            do
            {
                stepFirsGamer();
                if (isGameOver()) break;
                stepSecondGamer();
            } while (!isGameOver());
            logger.WriteWinner(stringWhoIsWin());
            logger.WriteInFile();
        }

        private void stepFirsGamer()
        {

            ResultShot resultshot;
            СellCoordinates cell;
            logger.WriteGamer("First Gamer");
            do
            {
                //игрок делает выстрел cell- хранит координаты клетки 
                cell = firstGamer.madeShot();
                // результат выстрела 
                resultshot = mapSecondGamer.GetResultShot(cell.Horizontal, cell.Vertical);
                logger.WriteShot(cell, resultshot);
                ///игрок получает ответ на свой ход и запоминает его 
                firstGamer.receiveResultCurrentStep(resultshot);

                if (resultshot == ResultShot.Kill) // если результат выстрела убитый корабль то счетчик кораблей противника уменьшается на единицу 
                {
                    countShipsSecondGr--;
                }
                 
            } while (isCountinuesStep(resultshot));//проверка на продолжение хода игроком
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
                }
            } while (isCountinuesStep(resultshot));
        }

    }
}
                




                   



            
              
               



                        


                        

            
            
            

            





        

            



            
           


        

