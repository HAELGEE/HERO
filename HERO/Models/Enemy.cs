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
    public int? Charm { get; set; } = 2;
    public int? Resistance { get; set; } = 0;
    public int? Lifesteal { get; set; } = 0;

    
}



internal class Orc : Enemy // Klass
{
    public string? Class = "Orc";
    public string? Weakness { get; set; }
}

internal class Grunt : Orc // TANK
{
    public string? Name = $"Grunt - {Menu.Menu.OrcName()}";
}

internal class Shaman : Orc // Healer
{
    public string? Name = $"Shaman - {Menu.Menu.OrcName()}";
}
internal class Goblin : Orc // DPS
{
    public string? Name = $"Goblin - {Menu.Menu.OrcName()}";
}



/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


internal class Elf : Enemy // Klass
{
    public string? Class = "Elf";
    public string? Weakness { get; set; }
}

internal class Tharion : Elf // TANK
{
    public string? Name = $"Tharion - {Menu.Menu.ElfName()}";
}

internal class Elowen : Elf // Healer
{
    public string? Name = $"Elowen - {Menu.Menu.ElfName()}";
}
internal class Sylvestra : Elf // DPS
{
    public string? Name = $"Sylvestra - {Menu.Menu.ElfName()}";
}


/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


internal class Ghost : Enemy // Klass
{
    public string? Class = "Ghost";
    public string? Weakness { get; set; }
}
internal class Gravemourn : Ghost // TANK
{
    public string? Name = $"Gravemourn - {Menu.Menu.GhostName()}";
}

internal class Hauntress : Ghost // Healer
{
    public string? Name = $"Hauntress - {Menu.Menu.GhostName()}";
}
internal class Wraithon : Ghost // DPS
{
    public string? Name = $"Wraithon - {Menu.Menu.GhostName()}";

}