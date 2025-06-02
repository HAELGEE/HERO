using HERO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class User : IUser
{
    public User(string firstname, string lastname, string email, string password) : this()
    {
        RegisteryDate = DateForRegistery();
        Firstname = firstname;
        Lastname = lastname;
        Email = email;
        Password = password;
        IsAdmin = false;
        IsLoggedIn = false;
    }
    public User()
    {        
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
    public bool IsAdmin { get; set; }
    public int? Logins { get; set; }
    public bool IsLoggedIn { get; set; }
    public string? HeroUsing { get; set; } // Den som är aktiv och används för tillfället 

    // Kopplingar till sina Hero
    public virtual ICollection<Hero> Heros { get; set; } = new List<Hero>();
}
