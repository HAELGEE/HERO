using HERO.Models;
using HERO.Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HERO.Menu;
internal class Quit
{
    public static void QuitMessage()
    {
        using (var db = new MyDbContext())
        {
            var user = db.User.Where(u => u.Id == Program.iUser.Id).SingleOrDefault();

            if (user != null)
            {
                user!.IsLoggedIn = false;
                db.SaveChanges();
            }

            Console.Clear();
            Console.WriteLine(TextCenter.CenterTexts("Tack för att du använder detta programmet, nu avslutas programmet"));
            Thread.Sleep(1000);
        }
    }
}
