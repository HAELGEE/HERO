using HERO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HERO.Menu;
internal class Dungeon
{
    // Här skrivs logiken för dungeons ut
    // Skall vara 6 rum där rum 1, 2, 4, 5, skall vara mot Icke boss monster
    // 3 och 6 är mot Bossmonster

    bool dungeonLoop = true;
    static int roomNumber = 0;
    public int RandomGoldWon = 0;

    public void EnterDungeonArea(Hero hero)
    {

    }

    public void EnterRoom()
    {
        if (roomNumber == 1 || roomNumber == 2 || roomNumber == 4 || roomNumber == 5)
            RandomGoldWon = Random.Shared.Next(1, 5);
        else
            RandomGoldWon = Random.Shared.Next(2, 7);

        Console.Clear();

    }
}
