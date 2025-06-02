using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class User
{
    public User()
    {
        RegisteryDate = DateForRegistery();
    }

    private string DateForRegistery()
    {
        DateTime date = DateTime.Now;
        return date.ToString();
    }

    // Här skapas ett konto för en User
    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? RegisteryDate { get; set; }
    public bool? IsAdmin { get; set; }
    public int Logins { get; set; }

    // Kopplingar till sina Hero
    public virtual ICollection<Hero> Heros { get; set; } = new List<Hero>();
}
