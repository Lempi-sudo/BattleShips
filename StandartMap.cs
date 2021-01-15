using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class StandartMap : IMap
    {
       
        public StandartMap()
        {
            cellsField = new Cell[fieldSize,fieldSize];
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    cellsField[i, j] = new Cell(i,j);
                }
            }

        }
         public void CreateMap()
        {
            FillWater();
            
        }

        private void FillWater()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    cellsField[i, j].Status=CellsKind.Water;
                }
            }
        }

        public void PrintMap()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    Console.WriteLine(cellsField[i, j].Status);
                }
            }
          
            foreach(Cell cell in cellsField)
            {
                Console.WriteLine(cell.Status);
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




    }
}


