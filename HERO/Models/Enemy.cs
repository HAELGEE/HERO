using HERO.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class Enemy
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Class { get; set; }
    public string? Subclass { get; set; }
    public string? Weakness { get; set; }

    public int? Level { get; set; } = 1;
    public int? CurrentHealth { get; set; } = 100;
    public int? MaxHealth { get; set; } = 100;
    public int? Healing { get; set; } = 10;
    public int? Damage { get; set; } = 10;
    public int? Armor { get; set; } = 2;
    public int? Strength { get; set; } = 2;
    public int? Intelligence { get; set; } = 2;
    public int? Agility { get; set; } = 2;
    public int? Speed { get; set; } = 2;
    public int? Stamina { get; set; } = 2;
    public int? Charm { get; set; } = 0;
    public int? Resistance { get; set; } = 0;
    public int? Lifesteal { get; set; } = 0; // står det 13 så menas det 13% av totala skadan som görs

    
}



internal class Orc : Enemy // Klass
{
    public Orc()
    {
        Class = "Orc";
        //Weakness = 
    }
}

internal class Grunt : Orc // TANK
{
    public Grunt()
    {
        Subclass = "Grunt";
        Name = $"Grunt - {Menu.Menu.OrcName()}";
    }    
}

internal class Shaman : Orc // Healer
{
    public Shaman()
    {
        Name = $"Shaman - {Menu.Menu.OrcName()}";
    }
}
internal class Goblin : Orc // DPS
{
    public Goblin()
    {
        Name = $"Goblin - {Menu.Menu.OrcName()}";
    }
}



/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


internal class Elf : Enemy // Klass
{
    public Elf()
    {
        Class = "Elf";
        //Weakness = 
    }
}

internal class Tharion : Elf // TANK
{
    public Tharion()
    {
        Name = $"Tharion - {Menu.Menu.ElfName()}";
    }
}

internal class Elowen : Elf // Healer
{
    public Elowen()
    {
        Name = $"Elowen - {Menu.Menu.ElfName()}";
    }
}
internal class Sylvestra : Elf // DPS
{
    public Sylvestra()
    {
        Name = $"Sylvestra - {Menu.Menu.ElfName()}";
    }
}


/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


internal class Ghost : Enemy // Klass
{
    public Ghost()
    {
        Class = "Ghost";
        // Weakness =
    }
}
internal class Gravemourn : Ghost // TANK
{
    public Gravemourn()
    {
        Name = $"Gravemourn - {Menu.Menu.GhostName()}";
    }
}

internal class Hauntress : Ghost // Healer
{
    public Hauntress()
    {
        Name = $"Hauntress - {Menu.Menu.GhostName()}";
    }
}
internal class Wraithon : Ghost // DPS
{
    public Wraithon()
    {
        Name = $"Wraithon - {Menu.Menu.GhostName()}";
    }

}