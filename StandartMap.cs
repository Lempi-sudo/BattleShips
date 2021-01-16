using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class StandartMap : IMap
    {

        public StandartMap()
        {
            cellsField = new Cell[fieldSize, fieldSize];
            AllShips = new FleetShips();

        }

        private void FillWater()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    cellsField[i, j] = new Cell(i, j);
                }
            }
        }
        private List<СellCoordinates> AvailableСells()
        {
            List<СellCoordinates> allCells = new List<СellCoordinates>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (cellsField[i, j].Status == CellsKind.Water)
                    {
                        allCells.Add(new СellCoordinates(i, j));
                    }
                }
            }
            return allCells;
        }
        private int RandomIndex(int maxindex)
        {
            Random rand = new Random();
            return rand.Next(0, maxindex);
        }

        private void CreateSomeDeckShipOnMap(int sizeship)
        {

        }

        

        private void ShiftCellAroundShip(СellCoordinates center,int shifthorizontally , int shiftvertical)
        {
            int positionHorintal = center.Horizontal + shifthorizontally;
            int positionVertical = center.Vertical + shiftvertical;
            if (positionHorintal < 10 && positionHorintal >= 0 && positionVertical < 10 && positionVertical >= 0)
            {
                cellsField[center.Horizontal + shifthorizontally, center.Vertical + shiftvertical].Status = CellsKind.AreaAroundShip;
            }
        }

        private void DrawСellsAroundShip(Ship ship)
        {
            /// смещение относительно центра
            int up = -1;
            int down = 1;
            int right = 1;
            int left = -1;
            int noShift = 0;
            for (int i = 0; i <ship.SizeShip; i++)
            {
                ShiftCellAroundShip(ship.ShipCoordinates[0], up, noShift);
                ShiftCellAroundShip(ship.ShipCoordinates[0], down, noShift);
                ShiftCellAroundShip(ship.ShipCoordinates[0], noShift, right);
                ShiftCellAroundShip(ship.ShipCoordinates[0], noShift, left);

                ShiftCellAroundShip(ship.ShipCoordinates[0], up, left);
                ShiftCellAroundShip(ship.ShipCoordinates[0], up, right);
                ShiftCellAroundShip(ship.ShipCoordinates[0], down, left);
                ShiftCellAroundShip(ship.ShipCoordinates[0], down, right);
            }

        }

        private void DrawShip(Ship ship)
        {
            for (int i = 0; i < ship.SizeShip; i++)
            {
                cellsField[ship.ShipCoordinates[i].Horizontal, ship.ShipCoordinates[i].Vertical].Status = CellsKind.Ship;
            }
        }
        
        
        private void CreateShipsOnMap(int [] arraysizeships)
        {
            //все доступные клетки 
            List<СellCoordinates> availableCells =AvailableСells() ;
            
            //выбор номера случайной клетки 
            int index = RandomIndex(availableCells.Count);

            //добавление корабля в флот
            List<СellCoordinates> shipcoordinates = new List<СellCoordinates>();
            shipcoordinates.Add(availableCells[index]);
            Ship ship = new Ship(shipcoordinates);
            AllShips.AddShip(ship);

            //закрасил карту кораблем 
            DrawShip(ship);

            //закрасил карту вокруг корабля
            DrawСellsAroundShip(ship);
        }


            



        public void generationMap()
        {
            FillWater();
            int[] allSizeShips = new int[]{ 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

            CreateShipsOnMap(allSizeShips);
            

        }

       
        public void Print()
        {
            bool flag = true;
            Console.Write("  ");
            for (int i = 0; i < fieldSize; i++)
            {
                Console.Write(" " + i + " ");

            }
            Console.WriteLine();
            Console.WriteLine();
       
            for (int i = 0; i < fieldSize; i++)
            {
                if (flag)
                {
                    Console.Write(i+"  ");
                    flag = false;
                }

                for (int j = 0; j < fieldSize; j++)
                {
                    switch(cellsField[i,j].Status)
                    {
                        case CellsKind.Water:
                            Console.Write(" 0 ");
                            break;
                        case CellsKind.Ship:
                            Console.Write(" A ");
                            break;
                        case CellsKind.AreaAroundShip:
                            Console.Write(" X ");
                            break;
                    }
                  
                }
                flag = true;
                Console.WriteLine();
            }

        }

        public CellsKind getStatusCell(int horizontal, int vertical)
        {
            return cellsField[horizontal, vertical].Status;
        }


        



        /// <summary>
        /// игровое поле 
        /// </summary>
        private Cell[,] cellsField;


        /// <summary>
        /// размер карты
        /// </summary>
        private int fieldSize=10;

        FleetShips AllShips;




    }
}


