using HERO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HERO.Menu;
internal class Login
{
    public static void AccountLogin()
    {
        using (var db = new MyDbContext())
        {
            Console.Clear();

            Console.Write("Ange Email: ");
            string loginEmail = Console.ReadLine()!;

            var user = db.User.Where(u => u.Email == loginEmail)
                .Select(u => new
                {
                    u.Email,
                    u.Password
                })
                .SingleOrDefault();

            if (!string.IsNullOrWhiteSpace(loginEmail) && user != null)
            {
                Console.Write("Ange lösenord: ");
                string loginPassword = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(loginPassword) && BC.EnhancedVerify(loginPassword, user.Password))
                {
                    var person = db.User.Where(u => u.Email == loginEmail).ToList().SingleOrDefault();



                    if (person!.Email!.ToLower() == loginEmail.ToLower())
                    {
                        person.IsLoggedIn = true;
                        Program.iUser.IsLoggedIn = true;
                        db.SaveChanges();

                        if (person.IsAdmin)
                        {
                            Program.iUser.IsAdmin = true;
                            db.SaveChanges();
                        }
                        person.Logins++;
                        db.SaveChanges();

                        Console.WriteLine("Du är nu inloggad");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("Fel lösenord, försök igen");
                    Thread.Sleep(1500);
                }
            }

            else
            {
                Console.WriteLine("Inget konto hittades med den mailadressen");
                Thread.Sleep(1500);
            }
        }
    }
}
