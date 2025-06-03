using HERO.Database_Stuff;
using HERO.Models;
using HERO.Stuff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Attacks;
internal class Attack
{
    static Enemy ReturningRandomEnemy()
    {
        switch (Random.Shared.Next(0, 9))
        {
            // Orcs
            case 0:
                return new Grunt();
            case 1:
                return new Shaman();
            case 2:
                return new Goblin();

            //Elfs
            case 3:
                return new Tharion();
            case 4:
                return new Elowen();
            case 5:
                return new Sylvestra();

            //Ghosts
            case 6:
                return new Gravemourn();
            case 7:
                return new Hauntress();
            case 8:
                return new Wraithon();

            // Utifall något händer (vilket det inte skall)
            default:
                return new Goblin();

        }
    }

    public static void Attacking()
    {
        var Enemy = ReturningRandomEnemy();

        Console.WriteLine($"{Enemy.Name} - {Enemy.Class} - {Enemy.Subclass} ");
    }
}
