using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class FoolStrategy : IStrategy
    {
        /// <summary>
        /// Формируем список всех клеток allCells
        /// из него случайным образом берем клетку и добавлеем в очередь
        /// удалеем клетку из allCells
        /// по завершению работы конструктора
        /// создастся очередь клеток в случаном порядке 
        /// </summary>
        /// <param name="sizemap">  размер карты  </param>
        public FoolStrategy(int sizemap=10)
        {
            List<СellCoordinates> allCells = new List<СellCoordinates>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    allCells.Add(new СellCoordinates(i, j));
                }
            }

            this.randomСells = new Queue<СellCoordinates>();

            Random rand = new Random();
            int index;
            while (allCells.Count != 0)
            {
                index = rand.Next(0, allCells.Count);

                this.randomСells.Enqueue(allCells[index]);
                allCells.RemoveAt(index);
            }
        }

        /// <summary>
        /// метод выбора клеток 
        /// </summary>
        /// <returns> возвращает очередную случайную клетку </returns>
        public СellCoordinates PickCell(ResultShot resultcurrentStep)
        { 
            return randomСells.Dequeue();
        }

        /// <summary>
        /// очередь случайных клеток
        /// </summary>        
        private Queue<СellCoordinates> randomСells;
    }
}




