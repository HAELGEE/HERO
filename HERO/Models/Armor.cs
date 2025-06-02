using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class Armor
{
    public Armor()
    {
        //DropChance();
    }
    // Basic armor saker
    public int Id { get; set; }
    public string? Name { get; set; }

    // Koppling till Hero
    public int HeroId { get; set; }
    public virtual Hero? Hero { get; set; }

    public static void DropChance<T>(T calculateNumber)
    {

    }

    void GettingRarity<T>(T Rarity)
    {

    }
}
