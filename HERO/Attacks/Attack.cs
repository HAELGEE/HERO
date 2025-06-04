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
                return new Grunt(); // Tank
            case 1:
                return new Shaman(); //Healer
            case 2:
                return new Goblin(); //Dps

            //Elfs
            case 3:
                return new Tharion(); // Tank
            case 4:
                return new Elowen(); //Healer
            case 5:
                return new Sylvestra(); //Dps

            //Ghosts
            case 6:
                return new Gravemourn(); // Tank
            case 7:
                return new Hauntress(); //Healer
            case 8:
                return new Wraithon(); //Dps

            // Utifall något händer (vilket det inte skall)
            default:
                return new Goblin();

        }
    }

    public static void Attacking()
    {
        var Enemy = ReturningRandomEnemy();

        Console.WriteLine($"{Enemy.Name} - {Enemy.Race} - {Enemy.Class} ");

        Console.WriteLine($"Agi: {Enemy.Agility} - Int: {Enemy.Intelligence} - Str: {Enemy.Strength} - Armor: {Enemy.Armor}");
    }
}
