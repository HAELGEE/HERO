using HERO.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Stuff;
internal class Commands
{
    public List<User> GettingAllUsers()
    {
        using (var db = new MyDbContext())
        {
            List<User> users = db.User.ToList();

            if (users != null)
                return users;
            else
                return null;
        }
    }

    public List<Hero> GettingAllHerosFromUser()
    {
        using (var db = new MyDbContext())
        {
            List<Hero> heroes = db.Hero.ToList();

            if (heroes != null)
                return heroes;
            else
                return null;
        }
    }

    public Hero GettingHeroById(int id)
    {
        using (var db = new MyDbContext())
        {
            List<Hero> heroes = db.Hero.ToList();

            foreach (var hero in heroes)
            {
                if (hero.Id == id)
                {
                    return hero;
                }
            }

            return null;
        }
    }
}
