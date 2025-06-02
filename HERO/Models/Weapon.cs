using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class Weapon
{
    public Weapon()
    {
        //GettingRarity();
    }
        
    public int Id { get; set; }

    // Här kommer Hero saker
    public int? HeroId { get; set; }
    public virtual Hero? Hero { get; set; }

    // Basic weapon saker
    public string? Name { get; set; }
    public string? Rarity { get; set; }


    // Attributes till armor
    public int? Damage { get; set; }
    public int? ArmorToHero { get; set; }
    public int? Strength { get; set; }
    public int? Intelligence { get; set; }
    public int? Agility { get; set; }
    public int? Speed { get; set; }
    public int? Stamina { get; set; }
    public int? Charm { get; set; }
    public int? Resistance { get; set; }
    public int? Lifesteal { get; set; }


    public static void DropChance<T>(T calculateNumber)
    {
        // Här skall beräkningen av droppchancen vara för dropp av olika Rarity av Vapen
    }

    void GettingRarity<T>(T Rarity)
    {
        // Här tar man den rarityn som blev vald i DropChance
    }
}
