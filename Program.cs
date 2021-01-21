using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sw = new StreamWriter("1.txt", true, Encoding.UTF8)) 
            {
                sw.Write("1");
                sw.Write("2");
                sw.Write("3");
                sw.WriteLine();


            }
            using (var sr=new StreamReader("1.txt"))
            {
                var text = sr.ReadToEnd();
                Console.Write(text);
            }

            //AbstractGamer g1 = new Gamer(new СleverStrategy(10,4), new StandartMap());
            //AbstractGamer g2 = new Gamer(new СleverStrategy(10, 4), new StandartMap());

            //Game game = new Game(g1, g2);

            //game.letsStartGame();





            //FleetShips flot = new FleetShips();

            //List<СellCoordinates> shipcoordinates = new List<СellCoordinates>();
            //shipcoordinates.Add(new СellCoordinates(1, 2));
            //shipcoordinates.Add(new СellCoordinates(3, 4));
            //Ship ship = new Ship(shipcoordinates);
            //flot.AddShip(ship);

            //shipcoordinates.Clear();
            //shipcoordinates.Add(new СellCoordinates(2, 3));
            //shipcoordinates.Add(new СellCoordinates(5, 4));
            //Ship ship1 = new Ship(shipcoordinates);
            //flot.AddShip(ship1);


            //СellCoordinates shot = new СellCoordinates(2, 3);


            //ResultShot s = ResultShot.Damage;
            //int x = (int)(s);


            ////shipcoordinates.Add(new СellCoordinates(3, 4));
            ////Ship ship1 = new Ship(shipcoordinates);

            ////flot.AddShip(ship1);
            //int mapsize = 10;
            //AbstractGamer g1 = null; 





            ////AbstractGamer g2 = new Gamer(new FoolStrategy(10), new StandartMap());
            //g1= new Gamer(new FoolStrategy(mapsize), new StandartMap()); 
            //IMap m = g1.DrawMap();


            ////((StandartMap)m).Print12();

            //g1 = null;




            //Console.Write("конец");






        }
    }
}
