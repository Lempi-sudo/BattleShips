using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    /// <summary>
    /// Интерфейс Карта 
    /// Карта может генерировать саму себе GenerationMap() , под генерацией понимается создание различных объектов на карте , вода , корабли и тд .
    /// Предпологается что у карты квадратная и у неё есть размер. метод SizeMap()
    /// Предпологается что на карте будут корабли и их количество необходимо знать CountShipOnMap()
    /// Карта должна возвращать ответ на выстрел по ней. Например игрок: попал Damage, Промазал Miss, Убил Kill. GetResultShot(int horizontal , int vertical)
    /// </summary>
    interface IMap
    {
        void GenerationMap();
        ResultShot GetResultShot(int horizontal , int vertical);
        int CountShipOnMap();
        int SizeMap();
    }
}



