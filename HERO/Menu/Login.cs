using HERO.Models;
using HERO.Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HERO.Menu;
internal class Login
{
    public static void AccountLogin()
    {
        using (var db = new MyDbContext())
        {
            Console.Clear();

            Console.WriteLine("\n\n\n\n\n\n\n\n\n");


            Color.ChangeColor(TextCenter.CenterMenu("Ange Email: "), "DarkCyan");
            string loginEmail = Console.ReadLine()!;

            var user = db.User.Where(u => u.Email == loginEmail)
                .Select(u => new
                {
                    u.Email,
                    u.Password,
                    u.Id
                })
                .SingleOrDefault();

            if (!string.IsNullOrWhiteSpace(loginEmail) && user != null)
            {
                Color.ChangeColor(TextCenter.CenterMenu("Ange lösenord: "), "DarkCyan");                
                string loginPassword = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(loginPassword) && BC.EnhancedVerify(loginPassword, user.Password))
                {
                    var person = db.User.Where(u => u.Email == loginEmail).ToList().SingleOrDefault();



                    if (person!.Email!.ToLower() == loginEmail.ToLower())
                    {
                        var users = db.User.ToList();

                        foreach (var user1 in users)
                        {
                            if (user1.Email != loginEmail)
                                user1.IsLoggedIn = false;
                        }
                        db.SaveChanges();


                        person.IsLoggedIn = true;
                        Program.iUser.IsLoggedIn = true;
                        db.SaveChanges();

                        Program.iUser.Id = person.Id;
                        db.SaveChanges();

                        var resetActiveHero = db.Hero.Where(h => h.UserId == user.Id).ToList();

                        foreach (var hero in resetActiveHero)
                        {
                            hero.ActiveHero = false;
                        }

                        if (person.IsAdmin)
                        {
                            Program.iUser.IsAdmin = true;
                            db.SaveChanges();
                        }
                        person.Logins++;
                        db.SaveChanges();


                        Console.WriteLine();
                        Color.ChangeColorNewLine(TextCenter.CenterMenu("Du är nu inloggad"), "Green");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Color.ChangeColorNewLine(TextCenter.CenterMenu("Fel lösenord, försök igen"), "Red");
                    Thread.Sleep(1500);
                }
            }

            else
            {
                Color.ChangeColorNewLine(TextCenter.CenterMenu("Inget konto hittades med den mailadressen"), "Red");
                Thread.Sleep(1500);
            }
        }
    }
}
