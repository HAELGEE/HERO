using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class Title
{
    public int Id { get; set; }

    public int? HeroId { get; set; }
    public virtual Hero? Hero { get; set; }

    public string? Name { get; set; }

    public static void AddingTitle(string input)
    {
        using (var db = new MyDbContext())
        {
            Enemy enemies = new Enemy();

            
        }
    }
}
