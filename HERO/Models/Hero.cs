using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class Hero
{
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

    // Hero attributs
    public string? Username { get; set; } // Username på HERO
    public int? Level { get; set; } = 1;
    public int? CurrentXP { get; set; } = 0;
    public int? MaxXP { get; set; } = 100;
    public int? CurrentHealth { get; set; } = 100;
    public int? MaxHealth { get; set; } = 100;
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
    public string? Title { get; set; }
    public int? Gold { get; set; } = 0;

    // Hero Titles
    public int? OrcSlain { get; set; }
    public int? ElfSlain { get; set; }
    public int? GhostSlain { get; set; }
}
