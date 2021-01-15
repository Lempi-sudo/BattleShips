using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    class FoolStrategy : IStrategy
    {
       

        public int PickCell()
        {
            //Создание объекта для генерации чисел
            Random rnd = new Random();

            //Получить случайное число (в диапазоне от 0 до 10)
            return  rnd.Next(0, 10);

                       
        }
    }
}
