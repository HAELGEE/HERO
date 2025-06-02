using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class EquipedWeapon
{
    public int Id { get; set; }

    public int? HeroId { get; set; }
    public virtual Hero? Hero { get; set; }

    public int? WeaponId { get; set; }
    public virtual Weapon? Weapon { get; set; }
}
