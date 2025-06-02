using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class RangeSkill
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int HeroId { get; set; }
    public virtual Hero? Hero { get; set; }

}
