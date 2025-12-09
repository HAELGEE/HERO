using HERO.Interfaces;
using HERO.Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace HERO.Models;
internal class Armor
{
    public Armor()
    {
        //DropChance();
    }

    public int Id { get; set; }

    // Här kommer Hero saker
    public int? HeroId { get; set; }
    public virtual Hero? Hero { get; set; }

    // Basic armor saker
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

    // Lägger till vilken del på kroppen den skall sita på
    public string? GearSlot { get; set; }


    public static void DropChance<T>(T calculateNumber)
    {
        // Här skall beräkningen av droppchancen vara för dropp av olika Rarity av Armor samt Vilken GearSlot den skall ta
        //Rank Common   Uncommon    Rare    Very Rare   Epic    Mythic
        // E   70.00    24.00       5.00    0.80        0.19    0.01
        // D   55.00    30.00       12.00   2.00        0.90    0.10
        // C   45.00    30.00       18.00   5.00        1.70    0.30
        // B   35.00    28.00       22.00   9.00        5.00    1.00
        // A   28.00    26.00       24.00   12.00       8.50    1.50
        // S   22.00    24.00       26.00   14.00       11.50   2.50
    }

    void GettingRarity<T>(T Rarity)
    {
        // Här tar man den rarityn som blev vald i DropChance
    }
}
