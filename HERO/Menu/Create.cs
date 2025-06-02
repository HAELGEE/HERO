using HERO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Menu;
internal class Create
{
    public static void CreateUser()
    {
        using (var db = new MyDbContext())
        {
            Console.Clear(); 

            Console.Write("Förnamn: ");
            string firstName = Console.ReadLine()!;

            Console.Write("Efternamn: ");
            string lastName = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Lösenord: ");
            string password = Console.ReadLine()!;

            string hashedPassword = BC.EnhancedHashPassword(password, 14);

            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(hashedPassword))
            {
                db.User.Add(new User(firstName, lastName, email, hashedPassword));
                db.SaveChanges();
            }

        }
    }

    public static void CreateHero()
    {
        using (var db = new MyDbContext())
        {
        }
    }
}
