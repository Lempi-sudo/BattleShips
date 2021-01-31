using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    /// <summary>
    /// Реализация интерфейса IStrategy
    /// при попадании по кораблю флаг flagContinueShotOnShip принимает значение true и остается таковым 
    /// пока корабль не убит 
    /// при первом попадании формируется список соседних клеток относительно первой подбитой CellsForKillsShip
    /// (если такие есть среди доступных availableCells )
    /// количество клеток зависит от максимального размера корабля maxlenghtship-1
    /// ЕСЛИ после этого произошел промах отбрасываются все клетки этой сторона 
    /// ECЛИ случилось попадание то остается только одна плоскость(горизонталь или вертикаль)
    /// выстрелы продолжаются по вершинам вокруг корабля до тех пор пока корабль не будет убит 
    /// ЕСЛИ корабль убит то клетка для следующего выстрела выбирается из доступных вершин availableCells случайным образом 
    /// </summary>
    class СleverStrategy : IStrategy
    {
        public СleverStrategy(int mapsize=10 , int maxlenghtship=4)
        {
            this.maxLenghtShip = maxlenghtship;
            this.CellsForKillsShip=new List<СellCoordinates>();
            this.hitShipCells = new List<СellCoordinates>();
            this.availableCells = new List<СellCoordinates>();
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    this.availableCells.Add(new СellCoordinates(i, j));
                }
            }
        }

        private СellCoordinates randomCell()
        {
            Random rand = new Random();
            int index= rand.Next(0, availableCells.Count);
            return availableCells[index];
        }

        private void deleteAvailableCell(СellCoordinates cell)
        {
            for (int i = 0; i < availableCells.Count; i++)
            {
                if(cell==availableCells[i])
                {
                    availableCells.RemoveAt(i);
                }

            }
        }

        private void setFlagValue(ResultShot resultPastStep)
        {
            if (resultPastStep == ResultShot.Damage) flagContinueShotOnShip = true;
            if(resultPastStep == ResultShot.Kill) flagContinueShotOnShip = false;
        }

        private bool isCellAvaivalbel(int h ,int v)
        {
            СellCoordinates cell = new СellCoordinates(h, v);
            
            foreach(var available in this.availableCells)
            {
                if (cell == available) return true; 
            }
            return false;
        
        }

        private void addAvailavleCellsAroundFirstCell()
        {
            int h = this.hitShipCells[0].Horizontal;
            int v = this.hitShipCells[0].Vertical;
            bool down = true;
            bool up = true;
            bool right = true;
            bool left = true;
         
            for (int i = 1; i < this.maxLenghtShip; i++)
            {
                if (down && isCellAvaivalbel(h + i, v)) CellsForKillsShip.Add(new СellCoordinates(h + i, v));
                else down = false;
                if (left && isCellAvaivalbel(h , v - i)) CellsForKillsShip.Add(new СellCoordinates(h, v - i));
                else left = false;
                if (up && isCellAvaivalbel(h - i, v)) CellsForKillsShip.Add(new СellCoordinates(h - i, v));
                else up = false;
                if (right && isCellAvaivalbel(h, v+i)) CellsForKillsShip.Add(new СellCoordinates(h, v + i));
                else right = false;
            }
        }

        private void deleteDirectionAttack() 
        {
            int deltaH = this.lastSelectedCell.Horizontal - this.hitShipCells[0].Horizontal;
            int deltaV = this.lastSelectedCell.Vertical - this.hitShipCells[0].Vertical;
            List<СellCoordinates> newCellsForKillsShip = new List<СellCoordinates>();

            int hcenter = hitShipCells[0].Horizontal;
            int vcenter = hitShipCells[0].Vertical;
            if (deltaH>0)
            {
                for (int i = 0; i < this.CellsForKillsShip.Count; i++)
                {
                    if (hcenter>= CellsForKillsShip[i].Horizontal)
                    {
                        newCellsForKillsShip.Add(CellsForKillsShip[i]);
                    }
                }
            }
            if(deltaH < 0)
            {
                for (int i = 0; i < this.CellsForKillsShip.Count; i++)
                {
                    if (hcenter<= CellsForKillsShip[i].Horizontal  )
                    {
                        newCellsForKillsShip.Add(CellsForKillsShip[i]);
                    }
                }
            }
            if(deltaV > 0)
            {
                for (int i = 0; i < this.CellsForKillsShip.Count; i++)
                {
                    if (CellsForKillsShip[i].Vertical <= vcenter)
                    {
                        newCellsForKillsShip.Add(CellsForKillsShip[i]);
                    }
                }
            }
            if(deltaV < 0)
            {
                for (int i = 0; i < this.CellsForKillsShip.Count; i++)
                {
                    if (CellsForKillsShip[i].Vertical >= vcenter)
                    {
                        newCellsForKillsShip.Add(CellsForKillsShip[i]);
                    }
                }
            }
            CellsForKillsShip.Clear();
            CellsForKillsShip = newCellsForKillsShip;
        }

        private void chooseHorizontalOrVertical()
        {
            СellCoordinates cell1 = hitShipCells[0];
            СellCoordinates cell2 = hitShipCells[1];
            int deltaH = cell2.Horizontal - cell1.Horizontal;
            int deltaV = cell2.Vertical - cell1.Vertical;
            List<СellCoordinates> newCellsForKillsShip = new List<СellCoordinates>();
        

            int hcenter = hitShipCells[0].Horizontal;
            int vcenter = hitShipCells[0].Vertical;

            for (int i = 0; i < this.CellsForKillsShip.Count; i++)
            {

                if (deltaH == 0)//добавлем только по горизонтали 
                {
                    if (CellsForKillsShip[i].Horizontal == hcenter)
                    {
                        newCellsForKillsShip.Add(CellsForKillsShip[i]);
                    }
                }
                if (deltaV == 0)//добавлем только по вертикали
                {
                    if (CellsForKillsShip[i].Vertical == vcenter)
                    {
                        newCellsForKillsShip.Add(CellsForKillsShip[i]);
                    }
                }

            }
            CellsForKillsShip.Clear();
            CellsForKillsShip = newCellsForKillsShip;
        }

        private void CreateCellsForKillsShip(ResultShot resshot)
        {
            if (resshot == ResultShot.Damage)
            {
                if (hitShipCells.Count == 1)
                {
                    addAvailavleCellsAroundFirstCell();
                }
                else if (hitShipCells.Count == 2)
                {
                    chooseHorizontalOrVertical();
                }
            }
            else
            {
                deleteDirectionAttack();
            }
        }

        private void addCellInHitShipCells()
        {
            hitShipCells.Add(this.lastSelectedCell);
        }

        private СellCoordinates PopFront(List<СellCoordinates> list)
        {
            СellCoordinates cell = list[0];
            list.RemoveAt(0);
            return cell;
        }

        public СellCoordinates PickCell(ResultShot resultPastStep)
        {
            setFlagValue(resultPastStep);
            if (!flagContinueShotOnShip) //если корабль НЕ ПОДБИТ  или  УБИТ 
            {
                if (resultPastStep == ResultShot.Kill)
                {
                    hitShipCells.Clear();
                    CellsForKillsShip.Clear();
                }
                СellCoordinates pickcell = randomCell();
                deleteAvailableCell(pickcell);
                this.lastSelectedCell = pickcell;
                return pickcell;
            }
            else //если корабль ПОДБИТ 
            {
                if (resultPastStep == ResultShot.Damage)//если прошлый ход был попадание добавить данную вершину в список addCellInHitShipCells
                {
                    addCellInHitShipCells();
                }
                CreateCellsForKillsShip(resultPastStep);//данный метод формирует список вершин в которых может быть корабль 

                СellCoordinates pickcell = PopFront(CellsForKillsShip);
                this.lastSelectedCell = pickcell;
                deleteAvailableCell(pickcell);
                return this.lastSelectedCell;

            }
        }


        /// <summary>
        /// вершина в которую стрелили в прошлом ходу 
        /// если попали то от нее формируется список вершин где возможно 
        /// есть корабль  CellsForKillsShip
        /// </summary>
        private СellCoordinates lastSelectedCell;

        /// <summary>
        /// флаг 
        /// TRUE -КОРАБЛЬ подбит продолжаем по нему стрелять 
        /// FALSE-КОРАБЛЬ не подбит , выбираем случайную вершину 
        /// </summary>
        bool flagContinueShotOnShip = false; 


        /// <summary>
        /// клетки в которые еще не стреляли 
        /// </summary>
        private List<СellCoordinates> availableCells;

        /// <summary>
        /// максимальное количество палуб у корабля на карте
        /// </summary>
        private int maxLenghtShip;

        /// <summary>
        /// cписок клеток соседки с клекой в которой есть корабль
        /// формируется после попадания и изменяется в зависимости от попаданий/промахов  
        /// </summary>
        private List<СellCoordinates> CellsForKillsShip;



        /// <summary>
        /// список  клеток с подбитым кораблем . 
        /// список содержит клетки одного корабля 
        /// после убийства корабля список очищается 
        /// </summary>
        private List<СellCoordinates> hitShipCells;


    }
}
       
        









          
  
            
            

               
























        




