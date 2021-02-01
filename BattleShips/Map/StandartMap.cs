using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    /// <summary>
    /// Реализация интерфейса Карта 
    /// Стандартная карта - квадрат со стороной  10 клеток 
    /// на карте расположены 10 кораблей 
    /// 4-однопалубных
    /// 3-двухпалубных 
    /// 2-трехпалубных 
    /// 1-четырехпалубный
    /// корабли не могут стоять вплотную друг к другу. Между кораблями минимум одна клекта 
    /// </summary>
    class StandartMap : IMap
    {
        public StandartMap()
        {
            cellsField = new Cell[fieldSize, fieldSize];
            AllShips = new FleetShips();
        }


        /// <summary>
        /// генерация карты заполнение водой и расстановка кораблей 
        /// </summary>
        public void GenerationMap()
        {
            FillWater();//сначала заполняем все клетки водой 
            int[] allSizeShips = new int[] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };//Массив содержит размеры кораблей на карте 
            CreateShipsOnMap(allSizeShips);//расстановка кораблей на карте с заданыыми размерами кораблей. 
        }

        private void CreateShipsOnMap(int[] arraysizeships)
        {
            foreach (int sizeship in arraysizeships)
            {
                //список всех доступных клеток. Доступные клетки это такие клетки где нет корабля и нет поля рядом с поставленным кораблем. 
                //то есть все клетки куда можно поставить корабль 
                List<СellCoordinates> availableCells = AvailableСells();

                //выбор номера случайной клетки 
                int index = RandomIndex(availableCells.Count);

                //создание корабля размером sizeship и с первой клеткой availableCells[index].
                Ship ship = CreateSomeDeckShipOnMap(sizeship, availableCells[index]);
                
                //добавление корабля в флот
                AllShips.AddShip(ship);

                //рисуем корабль на карте. Имеется ввиду клетки карты с координатами созданного корабля обозначаются как CellsKind.Ship 
                DrawShip(ship);

                //обозначаем клетки вокруг корабля CellsKind.AreaAroundShip. В эти клетки нельзя ставить корабль  
                DrawСellsAroundShip(ship);

            }
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


        //изменить метод чтобы сначала создавался центр пото уже добавлялся к нему с=соседи и формировали 
        private Ship CreateSomeDeckShipOnMap(int sizeship, СellCoordinates centership)
        {

            //создаем список координат корабля и сразу добавляем первую 
            List<СellCoordinates> coordinatesShip = new List<СellCoordinates>();
            coordinatesShip.Add(centership);

            //находим все доступные соседние вершины с учетом размера корабля 
            List<СellCoordinates> UpNeighborsCells = NeighborsCells(centership, sizeship, -1, 0);
            List<СellCoordinates> DownNeighborsCells = NeighborsCells(centership, sizeship, 1, 0);
            List<СellCoordinates> RightNeighborsCells = NeighborsCells(centership, sizeship, 0, 1);
            List<СellCoordinates> LeftNeighborsCells = NeighborsCells(centership, sizeship, -0, -1);

            //необходимо знать количество соседних вершин по горизонтали и вертикали 
            int verticalNeighbors = LenghtNeighbors(UpNeighborsCells, DownNeighborsCells);
            int horizontalNeighbors = LenghtNeighbors(RightNeighborsCells, LeftNeighborsCells);
            Random rand = new Random();
            // если соседние вершины (по горизонтали>sizeship-1) или (по вертикали > sizeship-1) то в обе плоскости можно ставить корабль
            if (verticalNeighbors >= sizeship - 1 && horizontalNeighbors >= sizeship - 1)
            {
                //если ставить корабль можно и по вертикали и по горизонтали нужно случайным образом выбрать сторону 
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
            else if (verticalNeighbors >= sizeship - 1) //ставить корабль можно только по вертикали 
            {
                AddNeighborsCellsToCenter(sizeship, coordinatesShip, UpNeighborsCells, DownNeighborsCells);

            }
            else if (horizontalNeighbors >= sizeship - 1)//ставить корабль можно только по горизонтали  
            {
                AddNeighborsCellsToCenter(sizeship, coordinatesShip, RightNeighborsCells, LeftNeighborsCells);
            }
            //ВАЖНАЯ ЗАМЕТКА:ситуация при которой нельзя поставить корабль не в одну из сторон невозможна 
            //               при некотором другом наборе кораблей или другой формы или размеров ,такая ситуация будет возможна.
            //               В таком случае данный способ расстонавки кораблей на карте не подойтёт.
            Ship ship = new Ship(coordinatesShip);
            return ship;
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
            // смещение относительно центра
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

        private void DrawShip(Ship ship)
        {
            for (int i = 0; i < ship.SizeShip; i++)
            {
                cellsField[ship.ShipCoordinates[i].Horizontal, ship.ShipCoordinates[i].Vertical].Status = CellsKind.Ship;
            }
        }

        /// <summary>
        /// Данный метод находит все доступные соседние вершины отоносительно центральной centership с учетом сдвига shifthorizontally  shiftvertical
        /// например, если смещение по вертикали вправо (shiftvertical > 0 )то ищем все вершины правее относительно  центральной 
        ///           если смещение по вертикали влево (shiftvertical < 0 )то ищем все вершины левее относительно  центральной 
        /// необходимое количество соседних вершин зависит от размера корабля sizeship-1.
        /// если встретилась вершина на которую нельзя ставить корабль (например там уже есть корабль) то дальше искать бессмысленно. следует прекратить поиск
        /// </summary>
        /// <param name="centership">координаты центра коробля </param>
        /// <param name="sizeship">размер корабля</param>
        /// <param name="shifthorizontally">смещение по горизонтали </param>
        /// <param name="shiftvertical">смещение по вертикали </param>
        /// <returns>список соседних вершин на которые можно поставить корабль </returns>
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

        /// <summary>
        /// ПЛОХОЙ МЕТОД ИЗМЕНИТЬ
        /// </summary>
        /// <param name="sizeship">размер корабля </param>
        /// <param name="coordinatesShip">координат центра коробля </param>
        /// <param name="oneHandNeighborsCells"></param>
        /// <param name="otherHandNeighborsCells"></param>
        private void AddNeighborsCellsToCenter(int sizeship, List<СellCoordinates> coordinatesCenterShip, List<СellCoordinates> oneHandNeighborsCells, List<СellCoordinates> otherHandNeighborsCells)
        {
            while (true)
            {
                if (coordinatesCenterShip.Count == sizeship)
                {
                    break;
                }

                if (oneHandNeighborsCells.Count != 0)
                {
                    coordinatesCenterShip.Add(oneHandNeighborsCells[0]);
                    oneHandNeighborsCells.RemoveAt(0);
                }
                if (coordinatesCenterShip.Count == sizeship)
                {
                    break;
                }
                if (otherHandNeighborsCells.Count != 0)
                {
                    coordinatesCenterShip.Add(otherHandNeighborsCells[0]);
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

        /// <summary>
        ///  двумерный массив клеток карты 
        /// </summary>
        private Cell[,] cellsField;


        /// <summary>
        /// размер карты
        /// </summary>
        private int fieldSize=10;

        /// <summary>
        /// все корабли на карте 
        /// Данное поле содержит список кораблей с их координатами 
        /// </summary>
        private FleetShips AllShips;

    }
}






        

        





     



            

           
                






        

        






       


       

        

         



        















            



       



        





