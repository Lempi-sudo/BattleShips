using System;
using System.Collections.Generic;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            List<СellCoordinates> allCells = new List<СellCoordinates>();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    allCells.Add(new СellCoordinates(i, j));
                }
            }

            Queue<СellCoordinates> randomСells=new Queue<СellCoordinates>();

            Random rand = new Random();
            int index;
            while (allCells.Count!=0)
            {
                index = rand.Next(0, allCells.Count);

                randomСells.Enqueue(allCells[index]);
                allCells.RemoveAt(index);
            }

           

            for (int i = 0; i < 100; i++)
            {
                allCells.Add(randomСells.Dequeue());
            }
            
            for (int i = 0; i < 100; i++)
            {
                if (allCells[i].Vertical == 9) Console.WriteLine("v{0}   g{1}",allCells[i].Vertical , allCells[i].Horizontal);
                
            }

            //Dequeue: извлекает и возвращает первый элемент очереди

            //Enqueue: добавляет элемент в конец очереди


            //AbstractGamer g1 = new Gamer(new FoolStrategy(10), new StandartMap());
            //AbstractGamer g2 = new Gamer(new FoolStrategy(10), new StandartMap());

            //IMap m = g1.DrawMap();


            //((StandartMap)m).PrintMap();


            //Game game = new Game(g1, g2);





        }
    }
}
