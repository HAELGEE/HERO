using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class Hero
{
    public Hero()
    {
        StatIncrease();
    }


    // Basic saker för hero konto
    public int Id { get; set; }
    public bool ActiveHero { get; set; }


    // Kopplingar till andra klasser
    public int? UserId { get; set; }
    public virtual User? User { get; set; }
    public virtual ICollection<Armor>? ArmorToEquip { get; set; } = new List<Armor>();
    public virtual ICollection<EquipedArmor>? EquipedArmor { get; set; } = new List<EquipedArmor>();
    public virtual ICollection<Weapon>? WeaponToEquip { get; set; } = new List<Weapon>();
    public virtual ICollection<EquipedWeapon>? EquipedWeapon { get; set; } = new List<EquipedWeapon>();
    public virtual ICollection<MageSkill>? MageSkill { get; set; } = new List<MageSkill>();
    public virtual ICollection<MeleeSkill>? MeleeSkill { get; set; } = new List<MeleeSkill>();
    public virtual ICollection<RangeSkill>? RangeSkill { get; set; } = new List<RangeSkill>();
    public virtual ICollection<Title>? Titles { get; set; } = new List<Title>();

    // Hero attributs
    public string? Username { get; set; } // Username på HERO
    public int Level { get; set; } = 1;
    public int CurrentXP { get; set; } = 0;
    public int MaxXP { get; set; } = 100;
    public int? CurrentHealth { get; set; }
    public int? MaxHealth { get; set; }
    public double? BaseDamage { get; set; } = 10;
    public int? Damage { get; set; } = 0;
    public int? Armor { get; set; } = 2;
    public int? Strength { get; set; } = 2;
    public int? Intelligence { get; set; } = 2;
    public int? Agility { get; set; } = 2;
    public int? Speed { get; set; }

    // ----------------------------------------------------------------------------------------------------------------------------------
    // Denna Hjälper till i Turn rundorna, Tex om Hero har speed 8 och Fiende har speed 5 då Börjar Hero eftersom den har högst speed
    // Efter attacken skall skall 3 Speed vara kvar då den är 3 speed snabbare än Fienden. Alltså 8-5 = 3
    // Nästa gång det är Hero tur så får den + sin Original Speed vilket är 8 + 3 Från förra rundan vilket blir 12
    // Sedan börjar Kontrollen av vem som har snabbast speed igen och i denna omgången så kör Hero 2 gången innan Fiende
    // Fiende speed = 5, Hero speed = 12: 12-5 = 7. 
    // Fiende speed = 5, Hero speed = 7: 7-5 = 2.
    // Fiende speed = 5, Hero speed = 2: FIENDE börjar.

    // Skall alltid börja på 0!! Byggs på med vanliga Speed
    public int? TotalSpeed { get; set; } = 0;

    // lägger till en bool "Turn" som i sin tur håller ordning på om denne har slagits eller inte för att veta när speed skall resetas
    public bool Turn { get; set; } = false; // Blir true efter man slagits, och om Både HERO och Fiende har True så blir Speed = 0 igen.
    // ----------------------------------------------------------------------------------------------------------------------------------

    public int? Stamina { get; set; } = 2;
    public int? Charm { get; set; } = 2;
    public int? Resistance { get; set; } = 0;
    public int? Lifesteal { get; set; } = 0;  // står det 13 så menas det 13% av totala skadan som görs
    public string? Title { get; set; }
    public int? Gold { get; set; } = 0;

    // Hero Titles
    public int? OrcSlain { get; set; } = 0;
    public int? ElfSlain { get; set; } = 0;
    public int? GhostSlain { get; set; } = 0;

    public void StatIncrease()
    {
        MaxHealth = 50 + (Strength * 5) + (Stamina * 3);
        Speed = 5 + (Agility * 2);
        CurrentHealth = MaxHealth;
        BaseDamage = Convert.ToInt32(BaseDamage + (Strength * 1.5) + (Agility * 1.5));
    }
}
