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
        private void ShiftCellAroundShip(СellCoordinates center, int shifthorizontally, int shiftvertical)
        {
            int positionHorintal = center.Horizontal + shifthorizontally;
            int positionVertical = center.Vertical + shiftvertical;
            if (positionHorintal < 10 && positionHorintal >= 0 && positionVertical < 10 && positionVertical >= 0)
            {
                if (cellsField[positionHorintal, positionVertical].Status == CellsKind.Water)
                {
                    cellsField[positionHorintal, positionVertical].Status = CellsKind.AreaAroundShip;
                }
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
            for (int i = 0; i < ship.SizeShip; i++)
            {

                ShiftCellAroundShip(ship.ShipCoordinates[i], up, noShift);
                ShiftCellAroundShip(ship.ShipCoordinates[i], down, noShift);
                ShiftCellAroundShip(ship.ShipCoordinates[i], noShift, right);
                ShiftCellAroundShip(ship.ShipCoordinates[i], noShift, left);

                ShiftCellAroundShip(ship.ShipCoordinates[i], up, left);
                ShiftCellAroundShip(ship.ShipCoordinates[i], up, right);
                ShiftCellAroundShip(ship.ShipCoordinates[i], down, left);
                ShiftCellAroundShip(ship.ShipCoordinates[i], down, right);
            }

        }
        private СellCoordinates RandomCell(List<СellCoordinates> availableCells, int index)
        {
            return availableCells[index];
        }
        private void DrawShip(Ship ship)
        {
            for (int i = 0; i < ship.SizeShip; i++)
            {
                cellsField[ship.ShipCoordinates[i].Horizontal, ship.ShipCoordinates[i].Vertical].Status = CellsKind.Ship;
            }
        }
        private List<СellCoordinates> NeighborsCells(СellCoordinates centership, int sizeship, int shifthorizontally, int shiftvertical)
        {
            List<СellCoordinates> neighborsCells = new List<СellCoordinates>();
            int horNeighbors = 0;
            int verNeighbors = 0;

            for (int i = 1; i < sizeship; i++)
            {
                horNeighbors = centership.Horizontal + shifthorizontally * i;
                verNeighbors = centership.Vertical + shiftvertical * i;

                if (horNeighbors > 9 || horNeighbors < 0 || verNeighbors < 0 || verNeighbors > 9) break;
                if (cellsField[centership.Horizontal + shifthorizontally * i, centership.Vertical + shiftvertical * i].Status == CellsKind.Water)
                {
                    neighborsCells.Add(new СellCoordinates(centership.Horizontal + shifthorizontally * i, centership.Vertical + shiftvertical * i));
                }
                else
                {
                    break;
                }
            }

            return neighborsCells;
        }
        private int LenghtNeighbors(List<СellCoordinates> onehand, List<СellCoordinates> otherhand)
        {
            return onehand.Count + otherhand.Count;
        }
        private Ship CreateSomeDeckShipOnMap(int sizeship, СellCoordinates centership)
        {


            List<СellCoordinates> coordinatesShip = new List<СellCoordinates>();
            coordinatesShip.Add(centership);

            List<СellCoordinates> UpNeighborsCells = NeighborsCells(centership, sizeship, -1, 0);
            List<СellCoordinates> DownNeighborsCells = NeighborsCells(centership, sizeship, 1, 0);
            List<СellCoordinates> RightNeighborsCells = NeighborsCells(centership, sizeship, 0, 1);
            List<СellCoordinates> LeftNeighborsCells = NeighborsCells(centership, sizeship, -0, -1);

            int verticalNeighbors = LenghtNeighbors(UpNeighborsCells, DownNeighborsCells);
            int horizontalNeighbors = LenghtNeighbors(RightNeighborsCells, LeftNeighborsCells);
            Random rand = new Random();
            if (verticalNeighbors >= sizeship - 1 && horizontalNeighbors >= sizeship - 1)
            {

                int key = rand.Next(0, 1);
                switch (key)
                {
                    case 0: //корабль распологается по горизонтали 
                        AddNeighborsCellsToCenter(sizeship, coordinatesShip, RightNeighborsCells, LeftNeighborsCells);

                        break;
                    case 1://корабль распологается по вертикали  
                        AddNeighborsCellsToCenter(sizeship, coordinatesShip, UpNeighborsCells, DownNeighborsCells);

                        break;
                    default:
                        break;
                }
            }
            else if (verticalNeighbors >= sizeship - 1)
            {
                AddNeighborsCellsToCenter(sizeship, coordinatesShip, UpNeighborsCells, DownNeighborsCells);

            }
            else if (horizontalNeighbors >= sizeship - 1)
            {
                AddNeighborsCellsToCenter(sizeship, coordinatesShip, RightNeighborsCells, LeftNeighborsCells);
            }
            Ship ship = new Ship(coordinatesShip);
            return ship;
        }
        private void CreateShipsOnMap(int[] arraysizeships)
        {
            foreach (int i in arraysizeships)
            {
                //все доступные клетки 
                List<СellCoordinates> availableCells = AvailableСells();

                //выбор номера случайной клетки 
                int index = RandomIndex(availableCells.Count);

                //добавление корабля в флот
                //List<СellCoordinates> shipcoordinates = new List<СellCoordinates>();
                //shipcoordinates.Add(availableCells[index]);

                Ship ship = CreateSomeDeckShipOnMap(i, RandomCell(availableCells, index));

                AllShips.AddShip(ship);

                //закрасил карту кораблем 
                DrawShip(ship);

                //закрасил карту вокруг корабля
                DrawСellsAroundShip(ship);


            }

        }
        public void GenerationMap()
        {
            FillWater();
            int[] allSizeShips = new int[] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

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
                    Console.Write(i + "  ");
                    flag = false;
                }

                for (int j = 0; j < fieldSize; j++)
                {
                    switch (cellsField[i, j].Status)
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

        public void Print12()
        {
            for (int i = 0; i < fieldSize; i++)
            {

                for (int j = 0; j < fieldSize; j++)
                {
                    switch (cellsField[i, j].Status)
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

                Console.WriteLine();
            }
        }

        private void AddNeighborsCellsToCenter(int sizeship, List<СellCoordinates> coordinatesShip, List<СellCoordinates> oneHandNeighborsCells, List<СellCoordinates> otherHandNeighborsCells)
        {
            
            while (true)
            {
                if (coordinatesShip.Count == sizeship)
                {
                    break;
                }

                if (oneHandNeighborsCells.Count != 0)
                {
                    coordinatesShip.Add(oneHandNeighborsCells[0]);
                    oneHandNeighborsCells.RemoveAt(0);
                }
                if (coordinatesShip.Count == sizeship)
                {
                    break;
                }
                if (otherHandNeighborsCells.Count != 0)
                {
                    coordinatesShip.Add(otherHandNeighborsCells[0]);
                    otherHandNeighborsCells.RemoveAt(0);
                }

            }
        }

        public ResultShot GetResultShot(int horizontal, int vertical)
        {
            if (cellsField[horizontal, vertical].Status != CellsKind.Ship)
            {
                return ResultShot.Miss;
            }
            else
            {
                return AllShips.ShotOnShips(horizontal, vertical);
            }
        }
           
                

        public int CountShipOnMap()
        {
            return AllShips.CountShip();
        }

        public int SizeMap()
        {
            return fieldSize;
        }




        /// игровое поле 
        /// </summary>
        private Cell[,] cellsField;


        /// <summary>
        /// размер карты
        /// </summary>
        private int fieldSize=10;

        private FleetShips AllShips;

    }
}


        






       


       

        

         



        















            



       



        





