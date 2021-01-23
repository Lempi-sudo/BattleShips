using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BattleShips
{
    class Program
    {

        static void FoolVsClever()
        {
            AbstractGamer g1;
            AbstractGamer g2;
            Game game;
            int countwinfirstgamer = 0;
            int countwinsecondgamer = 0;
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("игра номер {0} сыграна ", i);
                g1 = new Gamer(new FoolStrategy(), new StandartMap());
                g2 = new Gamer(new СleverStrategy(), new StandartMap());
                game = new Game(g1, g2, "FoolVSClever.txt");
                game.letsStartGame();
                if (game.numberWhoIsWin() == 1) countwinfirstgamer++;
                if (game.numberWhoIsWin() == 2) countwinsecondgamer++;
            }
            using (var sw = new StreamWriter("FoolVSClever.txt", true, Encoding.UTF8))
            {
                sw.Write("первый(Fool) игрок  побед: {0}", countwinfirstgamer);
                sw.WriteLine();
                sw.Write("второй(Clever) игрок  побед: {0}", countwinsecondgamer);
            }
        }
        static void FoolVsFool()
        {
            AbstractGamer g1;
            AbstractGamer g2;
            Game game;
            int countwinfirstgamer = 0;
            int countwinsecondgamer = 0;
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("игра номер {0} сыграна ", i);
                g1 = new Gamer(new FoolStrategy(), new StandartMap());
                g2 = new Gamer(new FoolStrategy(), new StandartMap());
                game = new Game(g1, g2, "FoolVSFool.txt");
                game.letsStartGame();
                if (game.numberWhoIsWin() == 1) countwinfirstgamer++;
                if (game.numberWhoIsWin() == 2) countwinsecondgamer++;
            }
            using (var sw = new StreamWriter("FoolVSFool.txt", true, Encoding.UTF8))
            {
                sw.Write("первый(Fool) игрок  побед: {0}", countwinfirstgamer);
                sw.WriteLine();
                sw.Write("второй(Fool) игрок  побед: {0}", countwinsecondgamer);
            }
        }

        static void СleverVsСlever()
        {
            AbstractGamer g1;
            AbstractGamer g2;
            Game game;
            int countwinfirstgamer = 0;
            int countwinsecondgamer = 0;
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("игра номер {0} сыграна ", i);
                g1 = new Gamer(new СleverStrategy(), new StandartMap());
                g2 = new Gamer(new СleverStrategy(), new StandartMap());
                game = new Game(g1, g2, "СleverVsСlever.txt");
                game.letsStartGame();
                if (game.numberWhoIsWin() == 1) countwinfirstgamer++;
                if (game.numberWhoIsWin() == 2) countwinsecondgamer++;
            }
            using (var sw = new StreamWriter("СleverVsСlever.txt", true, Encoding.UTF8))
            {
                sw.Write("первый(Сlever) игрок  побед: {0}", countwinfirstgamer);
                sw.WriteLine();
                sw.Write("второй(Сlever) игрок  побед: {0}", countwinsecondgamer);
            }
        }
        static void Main(string[] args)
        {

            СleverVsСlever();
            FoolVsFool();
            FoolVsClever();


            //BattleShipsCup cup = new BattleShipsCup("FoolVsClever.txt");

            //cup.startCup(new Game(new Gamer(new FoolStrategy(10), new StandartMap()), new Gamer(new СleverStrategy(10, 4), new StandartMap()), "FoolVsClever.txt"));












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
