using HERO.Database_Stuff;
using HERO.Models;
using HERO.Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Menu;
internal class Load
{
    public static void LoadingHero()
    {
        while (true)
        {
            using (var db = new MyDbContext())
            {
                Console.Clear();
                Entity.GettingAllHerosForUser();
                Console.WriteLine(TextCenter.CenterTexts("B för att backa"));
                Console.WriteLine(TextCenter.CenterTexts("Vilken Hero vill du välja? [Välj genom att skriva in namnet på din Hero]"));

                var position = Console.GetCursorPosition();
                Console.SetCursorPosition((Console.WindowWidth / 2) - 3, position.Top + 1);
                string heroChoice = Console.ReadLine()!;

                if (heroChoice.ToLower() == "b")
                    break;

                if (!string.IsNullOrWhiteSpace(heroChoice))
                {
                    var currentHero = db.Hero.Where(h => h.UserId == Program.iUser.Id && h.Username == heroChoice).ToList().SingleOrDefault();

                    if (currentHero != null)
                    {
                        currentHero!.ActiveHero = true;
                        db.SaveChanges();
                        break;
                    }
                }
            }
        }
    }
}
