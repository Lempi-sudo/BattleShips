﻿using System;
using System.Collections.Generic;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {



          

            FleetShips flot = new FleetShips();

            List<СellCoordinates> shipcoordinates = new List<СellCoordinates>();
            shipcoordinates.Add(new СellCoordinates(1, 2));
            shipcoordinates.Add(new СellCoordinates(3, 4));
            Ship ship = new Ship(shipcoordinates);
            flot.AddShip(ship);

            shipcoordinates.Clear();
            shipcoordinates.Add(new СellCoordinates(2, 3));
            shipcoordinates.Add(new СellCoordinates(5, 4));
            Ship ship1 = new Ship(shipcoordinates);
            flot.AddShip(ship1);


            СellCoordinates shot = new СellCoordinates(2, 3);

           
            


            //shipcoordinates.Add(new СellCoordinates(3, 4));
            //Ship ship1 = new Ship(shipcoordinates);

            //flot.AddShip(ship1);
            int mapsize = 10;
            AbstractGamer g1 = null; 
                


            for (int i = 0; i < 100000; i++)
            {
                


                
                //AbstractGamer g2 = new Gamer(new FoolStrategy(10), new StandartMap());
                g1= new Gamer(new FoolStrategy(mapsize), new StandartMap()); 
                IMap m = g1.DrawMap();
              

                //((StandartMap)m).Print12();
                
                g1 = null;



            }
            Console.Write("конец");
            
            
           


            //Game game = new Game(g1, g2);





        }
    }
}
