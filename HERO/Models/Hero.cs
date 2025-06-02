using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class Hero
{
    // Basic saker för ett konto
    public int Id { get; set; }
  

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
    public int? Level { get; set; }
    public int? CurrentXP { get; set; }
    public int? MaxXP { get; set; }
    public int? CurrentHealth { get; set; }
    public int? MaxHealth { get; set; }
    public int? Damage { get; set; }
    public int? Armor { get; set; }
    public int? Strength { get; set; }
    public int? Intelligence { get; set; }
    public int? Agility { get; set; }
    public int? Speed { get; set; }
    public int? Stamina { get; set; }
    public int? Charm { get; set; }
    public int? Resistance { get; set; }
    public int? Lifesteal { get; set; }
    public string? Title { get; set; }
    public int? Gold { get; set; }

    // Hero Titles
    public int? OrcSlain { get; set; }
    public int? ElfSlain { get; set; }
    public int? GhostSlain { get; set; }
}
