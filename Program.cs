using System;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {

            AbstractGamer g = new Gamer(new FoolStrategy(), new StandartMap());

            int x = g.madeShot();

            IMap map= g.DrawMap();

            CellsKind w= map.getStatusCell(1, 2);







        }
    }
}
