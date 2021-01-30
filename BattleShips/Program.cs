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
                Console.WriteLine("CleverVsFool игра номер {0} сыграна ", i+1);
                g1 = new Gamer(new СleverStrategy(), new StandartMap());
                g2 = new Gamer(new FoolStrategy(), new StandartMap());
                game = new Game(g1, g2, "CleverVsFool.txt");
                game.letsStartGame();
                if (game.numberWhoIsWin() == 1) countwinfirstgamer++;
                if (game.numberWhoIsWin() == 2) countwinsecondgamer++;
            }
            using (var sw = new StreamWriter("CleverVsFool.txt", true, Encoding.UTF8))
            {
                sw.Write("первый(Clever) игрок  побед: {0}", countwinfirstgamer);
                sw.WriteLine();
                sw.Write("второй(Fool) игрок  побед: {0}", countwinsecondgamer);
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
                Console.WriteLine("FoolVSFool игра номер {0} сыграна ", i+1);
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
                Console.WriteLine("СleverVsСlever игра номер {0} сыграна ", i+1);
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

        }
    }
}


           



