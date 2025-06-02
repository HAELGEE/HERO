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

            Color.ChangeColorNewLine(TextCenter.CenterMenu("Ange Email:"), "DarkCyan");
            Console.SetCursorPosition((Console.WindowWidth - 12) / 2, 1);
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
                Color.ChangeColorNewLine(TextCenter.CenterMenu("Ange lösenord:"), "DarkCyan");
                Console.SetCursorPosition((Console.WindowWidth - 8) / 2, 3);
                string loginPassword = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(loginPassword) && BC.EnhancedVerify(loginPassword, user.Password))
                {
                    var person = db.User.Where(u => u.Email == loginEmail).ToList().SingleOrDefault();



                    if (person!.Email!.ToLower() == loginEmail.ToLower())
                    {
                        person.IsLoggedIn = true;
                        Program.iUser.IsLoggedIn = true;
                        db.SaveChanges();

                        Program.iUser.Id = person.Id;
                        db.SaveChanges();

                        if (person.IsAdmin)
                        {
                            Program.iUser.IsAdmin = true;
                            db.SaveChanges();
                        }
                        person.Logins++;
                        db.SaveChanges();

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
