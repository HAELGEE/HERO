using HERO.Models;
using HERO.Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Menu;
internal class Level
{   
    public static void XpGain(int enemyLevel, int heroLevel)
    {
        int baseXP = 50;
        int levelDifference = enemyLevel - heroLevel;
        float xpMultiplier = 1 + (levelDifference * 0.2f);
        xpMultiplier = Math.Clamp(xpMultiplier, 0.5f, 2.0f);

        int earnedXP = (int)(baseXP * xpMultiplier);
        using (var db = new MyDbContext())
        {
            var hero = db.Hero.Where(h => h.UserId == Program.iUser.Id).ToList();

            foreach(var h in hero)
            {
                if(h.ActiveHero)
                {
                    h.CurrentXP += earnedXP;
                    db.SaveChanges();

                    if(h.CurrentXP >= h.MaxXP)
                    {
                        h.CurrentXP = h.CurrentXP - h.MaxXP;
                        h.Level++;
                        Hero.GetXPRequiredForLevel(h.MaxXP);
                        db.SaveChanges();
                        Console.WriteLine(TextCenter.CenterTexts("Du Gick upp i Level!"));
                        Console.WriteLine(TextCenter.CenterTexts($"Du är nu på Level: {h.Level}"));
                    }
                    break;
                }
            }
        }
    }
}
