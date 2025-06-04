using HERO.Menu;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class Enemy
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Race { get; set; }
    public string? Class { get; set; }
    public string? Weakness { get; set; }

    public int? Level { get; set; }
    public int? CurrentHealth { get; set; }
    public int? MaxHealth { get; set; }
    public int? Healing { get; set; }
    public int? BaseDamage { get; set; } = 10;
    public int? Damage { get; set; }
    public int? Armor { get; set; }
    public int? Strength { get; set; }
    public int? Intelligence { get; set; }
    public int? Agility { get; set; }
    public int? Speed { get; set; }

    // ----------------------------------------------------------------------------------------------------------------------------------
    // Denna Hjälper till i Turn rundorna, Tex om Hero har speed 8 och Fiende har speed 5 då Börjar Hero eftersom den har högst speed
    // Efter attacken skall skall 3 Speed vara kvar då den är 3 speed snabbare än Fienden. Alltså 8-5 = 3
    // Nästa gång det är Hero tur så får den + sin Original Speed vilket är 8 + 3 Från förra rundan vilket blir 11
    // Sedan börjar Kontrollen av vem som har snabbast speed igen och i denna omgången så kör Hero 2 gången innan Fiende
    // Fiende speed = 5, Hero speed = 11: 11-5 = 6. 
    // Fiende speed = 5, Hero speed = 6: 6-5 = 1.
    // Fiende speed = 5, Hero speed = 1: FIENDE börjar.

    // Skall alltid börja på 0!! Byggs på med vanlig Speed
    public int TotalSpeed { get; set; } = 0;

    // lägger till en bool "Turn" som i sin tur håller ordning på om denne har slagits eller inte för att veta när speed skall resetas
    public bool Turn { get; set; } = false; // Blir true efter man slagits, och om Både HERO och Fiende har True så blir Speed = 0 igen.
    // ----------------------------------------------------------------------------------------------------------------------------------


    public int? Stamina { get; set; }
    public int? Charm { get; set; }
    public int? Resistance { get; set; }
    public int? Lifesteal { get; set; } // står det 13 så menas det 13% av totala skadan som görs

    public void TankBaseStats()
    {
        Strength = 1;
        Stamina = 1;
        Agility = 1;
        Intelligence = 1;
        Armor = 4;
        Speed = 5;
        MaxHealth = 50;
        BaseDamage = 7;
    }
    public void TankStats()
    {
        Speed = Speed + (Agility * 2);
        MaxHealth = 50 + (Strength * 5) + (Stamina * 3);
        CurrentHealth = MaxHealth;
        BaseDamage = BaseDamage + (int)(Strength * 1.5) + (int)(Agility * 1);
    }
    public void HealerBaseStats()
    {
        Strength = 1;
        Agility = 1;
        Intelligence = 1;
        Stamina = 1;
        Armor = 2;
        Speed = 5;
        MaxHealth = 45;
        BaseDamage = 7;
        Healing = 2;        
    }
    public void HealerStats()
    {
        Speed = Speed + (Agility * 2);
        MaxHealth = 50 + (Strength * 5) + (Stamina * 3);
        CurrentHealth = MaxHealth;
        BaseDamage = BaseDamage + (int)(Intelligence * 1.5) + (int)(Agility);
        Healing = Healing + (int)(Intelligence * 1);
    }
    public void DpsBaseStats()
    {
        Strength = 1;
        Agility = 1;
        Intelligence = 1;
        Stamina = 1;
        Armor = 1;
        Speed = 7;
        MaxHealth = 40;
        BaseDamage = 10;
    }
    public void DpsStats()
    {
        Speed = Speed + (Agility * 2);
        MaxHealth = 50 + (Strength * 5) + (Stamina * 3);
        CurrentHealth = MaxHealth;
        BaseDamage = BaseDamage + (int)(Agility * 1.5) + (int)(Strength * 1.5);
    }
}


internal class Orc : Enemy // Klass
{
    public Orc()
    {
        Race = "Orc";

        //Weakness = 
    }
    public void RaceStatIncrease()
    {
        Strength++;
        Stamina++;
    }
}

internal class Grunt : Orc // TANK
{
    public Grunt()
    {
        Class = "Tank";
        Name = $"Grunt - {Menu.Menu.OrcName()}";

        TankBaseStats();
        RaceStatIncrease();
        TankStats();
    }
}

internal class Shaman : Orc // Healer
{
    public Shaman()
    {
        Class = "Healer";
        Name = $"Shaman - {Menu.Menu.OrcName()}";

        HealerBaseStats();
        RaceStatIncrease();
        HealerStats();
    }
}
internal class Goblin : Orc // DPS
{
    public Goblin()
    {
        Class = "Dps";
        Name = $"Goblin - {Menu.Menu.OrcName()}";

        DpsBaseStats();
        RaceStatIncrease();
        DpsStats();
    }
}



/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


internal class Elf : Enemy // Klass
{
    public Elf()
    {
        Race = "Elf";

        //Weakness = 
    }
    public void RaceStatIncrease()
    {
        Intelligence++;
        Agility++;
    }
}

internal class Tharion : Elf // TANK
{
    public Tharion()
    {
        Class = "Tank";
        Name = $"Tharion - {Menu.Menu.ElfName()}";

        TankBaseStats();
        RaceStatIncrease();
        TankStats();
    }
}

internal class Elowen : Elf // Healer
{
    public Elowen()
    {
        Class = "Healer";
        Name = $"Elowen - {Menu.Menu.ElfName()}";

        HealerBaseStats();
        RaceStatIncrease();
        HealerStats();
    }
}
internal class Sylvestra : Elf // DPS
{
    public Sylvestra()
    {
        Class = "Dps";
        Name = $"Sylvestra - {Menu.Menu.ElfName()}";

        DpsBaseStats();
        RaceStatIncrease();
        DpsStats();
    }
}


/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


internal class Ghost : Enemy // Klass
{
    public Ghost()
    {
        Race = "Ghost";

        // Weakness =
    }
    public void RaceStatIncrease()
    {
        Charm++;
        Armor++;
    }
}
internal class Gravemourn : Ghost // TANK
{
    public Gravemourn()
    {
        Class = "Tank";
        Name = $"Gravemourn - {Menu.Menu.GhostName()}";

        TankBaseStats();
        RaceStatIncrease();
        TankStats();
    }
}

internal class Hauntress : Ghost // Healer
{
    public Hauntress()
    {
        Class = "Healer";
        Name = $"Hauntress - {Menu.Menu.GhostName()}";

        HealerBaseStats();
        RaceStatIncrease();
        HealerStats();
    }
}
internal class Wraithon : Ghost // DPS
{
    public Wraithon()
    {
        Class = "Dps";
        Name = $"Wraithon - {Menu.Menu.GhostName()}";

        DpsBaseStats();
        RaceStatIncrease();
        DpsStats();
    }

}


