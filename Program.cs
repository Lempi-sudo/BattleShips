using System;
using System.Collections.Generic;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 7;

            if(x<10&&x>0)
            {
                Console.WriteLine();
            }
            //Ship s = new Ship(3);

            //FleetShips flot = new FleetShips();


            //List<СellCoordinates> shipcoordinates = new List<СellCoordinates>();
            //shipcoordinates.Add(new СellCoordinates(1, 2));
            //Ship ship = new Ship(shipcoordinates);
            //flot.AddShip(ship);

            //shipcoordinates.Add(new СellCoordinates(3, 4));
            //Ship ship1 = new Ship(shipcoordinates);
            //flot.AddShip(ship1);



            AbstractGamer g1 = new Gamer(new FoolStrategy(10), new StandartMap());
            //AbstractGamer g2 = new Gamer(new FoolStrategy(10), new StandartMap());

            IMap m = g1.DrawMap();


            ((StandartMap)m).Print();


            //Game game = new Game(g1, g2);





        }
    }
}
