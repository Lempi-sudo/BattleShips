using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class FoolStrategy : IStrategy
    {
        /// <summary>
        /// Формируем список всех клеток allCells
        /// из него случайным образом берем клеток и добавлеем в очередь
        /// удалеем клеток из allCells
        /// по завершению работы конструктора
        /// создастся очередь клеток в случаном порядке 
        /// </summary>
        /// <param name="sizemap">  размер карты  </param>
        public FoolStrategy(int sizemap)
        {
            List<СellCoordinates> allCells = new List<СellCoordinates>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    allCells.Add(new СellCoordinates(i, j));
                }
            }

            Queue<СellCoordinates> randomСells = new Queue<СellCoordinates>();

            Random rand = new Random();
            int index;
            while (allCells.Count != 0)
            {
                index = rand.Next(0, allCells.Count);

                randomСells.Enqueue(allCells[index]);
                allCells.RemoveAt(index);
            }
        }

        /// <summary>
        /// метод выбора клеток 
        /// </summary>
        /// <returns> возвращает очереднею случайную клеток </returns>
        public СellCoordinates PickCell(int resultPastStep)
        { 
            return randomСells.Dequeue();
        }
        /// <summary>
        /// очередь случайных клеток
        /// </summary>        
        private Queue<СellCoordinates> randomСells;
    }
}




