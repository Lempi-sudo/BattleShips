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
            bool flag = true;
            for (int i = 0; i < fieldSize; i++)
            {
                Console.Write("    "+i+"      ");
                
            }
            Console.WriteLine();
            for (int i = 0; i < fieldSize; i++)
            {
                Console.Write("-----------");

            }
            Console.WriteLine();
            for (int i = 0; i < fieldSize; i++)
            {
                if (flag)
                {
                    Console.Write(i);
                    flag = false;
                }

                for (int j = 0; j < fieldSize; j++)
                {
                  
                    Console.Write(" | "+cellsField[i, j].Status+" | ");
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




    }
}


