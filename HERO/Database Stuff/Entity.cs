using HERO.Models;
using HERO.Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Database_Stuff;
internal class Entity
{
    public static void GettingAllUsers()
    {
        using (var db = new MyDbContext())
        {
            var allUsers = db.User.ToList();

            foreach (var user in allUsers)
            {
                Console.WriteLine($"ID: {user.Id} - Namn: {user.Firstname!.PadRight(10)} - Efternamn: {user.Lastname} - Email: {user.Email}");
            }
        }
    }

    public static bool LookingIfHeroExist(string input)
    {
        using (var db = new MyDbContext())
        {
            var allHeros = db.Hero.Where(h => h.Username == input).SingleOrDefault();

            if (allHeros == null)
                return false;
            else
                return true;
        }
    }

    public static void GettingAllHerosForUser()
    {

        using (var db = new MyDbContext())
        {
            var heros = db.Hero.Where(h => h.UserId == Program.iUser.Id).ToList();

            foreach (var hero in heros)
            {
                Console.WriteLine(TextCenter.CenterTexts($"Usernam: {hero.Username}"));
                Console.WriteLine(TextCenter.CenterTexts($"Level: {hero.Level}"));
                if (hero.Title != null)
                    Console.WriteLine(TextCenter.CenterTexts($"Titel: {hero.Title}"));
                else
                    Console.WriteLine(TextCenter.CenterTexts($"Titel: Ingen Titel än"));
                Console.WriteLine(TextCenter.CenterTexts("----------------------------------------"));
                Console.WriteLine();
            }

        }

    }
}
