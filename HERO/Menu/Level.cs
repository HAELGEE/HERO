using HERO.Models;
using HERO.Stuff;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.IdentityModel.Tokens;
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

            foreach (var h in hero)
            {
                if (h.ActiveHero)
                {
                    h.CurrentXP += earnedXP;
                    db.SaveChanges();

                    if (h.CurrentXP >= h.MaxXP)
                    {
                        h.CurrentXP = h.CurrentXP - h.MaxXP;
                        h.Level++;
                        h.StatsIncrease = 4;
                        db.SaveChanges();
                        Hero.GetXPRequiredForLevel(h.MaxXP);
                        db.SaveChanges();
                        Console.WriteLine(TextCenter.CenterTexts("Du Gick upp i Level!"));
                        Console.WriteLine(TextCenter.CenterTexts($"Du är nu på Level: {h.Level}"));
                        Thread.Sleep(1000);

                        LevelUpStats();
                    }
                    break;
                }
            }
        }
    }
    public static void LevelUpStats()
    {
        Console.Clear();
        using (var db = new MyDbContext())
        {
            var hero = db.Hero.Where(h => h.UserId == Program.iUser.Id).ToList();
            
            bool found = false;
            foreach (var h in hero)
            {
                if (h.ActiveHero && h.StatsIncrease > 0)
                    found = true;
            }

            if (found)
            {
                bool menu = true;
                int menuSelecter = 0;
                while (menu)
                {
                    foreach (var h in hero!)
                    {
                        if (h.ActiveHero)
                        {
                            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");

                            while (h.StatsIncrease > 0)
                            {
                                Console.Clear();
                                Console.WriteLine(TextCenter.CenterTexts($"Du har {h.StatsIncrease} stats kvar att öka"));
                                Console.WriteLine(TextCenter.CenterTexts("Vilken stat vill du öka?") + "\n");
                                List<string> menuChoice = new List<string>()
                                {
                                    "Styrka",
                                    "Agility",
                                    "Intelligence",
                                    "Charm"
                                };
                                List<Action> menuActions = new List<Action>();

                                foreach (var stat in menuChoice)
                                {
                                    var whichStat = stat;
                                    menuActions.Add(() => StatIncrease(whichStat, h));
                                }

                                for (int i = 0; i < menuChoice.Count; i++)
                                {
                                    if (i == 0)
                                        Console.WriteLine($"\n\n\n");
                                    if (i == menuSelecter)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine(TextCenter.CenterMenu($"{menuChoice[i]}\t <---"));
                                        Console.ResetColor();
                                        Console.CursorVisible = false;
                                    }
                                    else
                                        Console.WriteLine(TextCenter.CenterTexts(menuChoice[i]));
                                }

                                var key = Console.ReadKey(true).Key;

                                if (key == ConsoleKey.DownArrow && menuSelecter < menuChoice.Count - 1)
                                {
                                    menuSelecter++;
                                }
                                else if (key == ConsoleKey.UpArrow && menuSelecter >= 1)
                                {
                                    menuSelecter--;
                                }
                                else if (key == ConsoleKey.Enter)
                                {
                                    if (menuSelecter >= 0 && menuSelecter < menuActions.Count)
                                    {
                                        Console.Clear();
                                        menuActions[menuSelecter].Invoke();  // Kör rätt funktion baserat på menyval
                                        h.StatsIncrease--;
                                        db.SaveChanges();
                                    }
                                }
                            }
                            LevelStatIncrease();
                            db.SaveChanges();
                            menu = false;
                            break;
                        }
                    }
                    break;
                }
            }

        }
    }
    static void StatIncrease(string input, Hero h)
    {
        if (h.ActiveHero)
        {
            if (input.ToLower() == "styrka")
            {
                Console.WriteLine(TextCenter.CenterTexts("Du ökade din Styrka med 1"));
                h.Strength++;
                Thread.Sleep(1000);
            }
            else if (input.ToLower() == "agility")
            {
                Console.WriteLine(TextCenter.CenterTexts("Du ökade din Agility med 1"));
                h.Agility++;
                Thread.Sleep(1000);
            }
            else if (input.ToLower() == "intelligence")
            {
                Console.WriteLine(TextCenter.CenterTexts("Du ökade din Intelligence med 1"));
                h.Intelligence++;
                Thread.Sleep(1000);
            }
            else if (input.ToLower() == "charm")
            {
                Console.WriteLine(TextCenter.CenterTexts("Du ökade din Charm med 1"));
                h.Charm++;
                Thread.Sleep(1000);
            }
        }
    }

    public static void LevelStatIncrease()
    {
        using (var db = new MyDbContext())
        {
            var hero = db.Hero.Where(h => h.UserId == Program.iUser.Id && h.ActiveHero == true).FirstOrDefault();

            hero!.MaxHealth = 50 + (hero.Strength * 5) + (hero.Stamina * 3);
            hero.Speed = 5 + (hero.Agility * 1);
            hero.CurrentHealth = hero.MaxHealth;
            hero.BaseDamage = Convert.ToInt32(hero.StartDamage + (hero.Strength * 1.5) + (hero.Agility * 1.5));
            db.SaveChanges();
        }
    }
}
