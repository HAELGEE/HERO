using HERO.Models;
using HERO.Stuff;
using Microsoft.IdentityModel.Tokens;
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
        string errorMessage = "";
        bool isLoggedIn = false;
        using (var db = new MyDbContext())
        {
            do
            {
                Console.Clear();

                Console.WriteLine("\n\n\n\n\n\n\n\n\n");
                if (!string.IsNullOrWhiteSpace(errorMessage))
                    Color.ChangeColorNewLine(TextCenter.CenterMenu(errorMessage), "Red");

                Color.ChangeColor(TextCenter.CenterMenu("Type 'B' to back"), "Red");
                Console.WriteLine("\n");

                Color.ChangeColor(TextCenter.CenterLoginMenu("Ange Email: "), "DarkCyan");
                string loginEmail = TextCenter.CenterLoginMenu(Console.ReadLine()!);

                if (loginEmail.ToLower() == "b")
                    break;

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
                    
                    Color.ChangeColor(TextCenter.CenterLoginMenu("Ange lösenord: "), "DarkCyan");
                    string loginPassword = TextCenter.CenterLoginMenu(Console.ReadLine()!);

                    if (loginPassword.ToLower() == "b")
                        break;

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

                            //Verifiering för att komma ut
                            isLoggedIn = true;
                            errorMessage = "";

                            Console.WriteLine();
                            Color.ChangeColorNewLine(TextCenter.CenterMenu("Du är nu inloggad"), "Green");
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        errorMessage = "Fel lösenord, försök igen";
                    }
                }

                else
                {
                    errorMessage = "Inget konto hittades med den mailadressen";
                }
            } while (!string.IsNullOrWhiteSpace(errorMessage) && !isLoggedIn);
        }
    }
}
