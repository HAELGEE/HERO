using HERO.Models;
using HERO.Stuff;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
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
    public static void LevelUpStats()
    {
        Console.Clear();
        int levelIncrease = 0;

        bool menu = true;
        while (menu)
        {
            using (var db = new MyDbContext())
            {
                var hero = db.Hero.Where(h => h.UserId == Program.iUser.Id).ToList();

                foreach (var h in hero)
                {
                    if (h.ActiveHero == true)
                    {
                        var titles = db.Title.Where(t => t.HeroId == h.Id).ToList();

                        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                        if (titles != null)
                        {
                            int menuSelecter = 0;
                            int counter = 4;
                            while (counter <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine(TextCenter.CenterTexts($"Du har {counter} stats kvar att öka"));
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
                                    menuActions.Add(() => StatIncrease(stat));
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
                                        counter--;
                                    }
                                }
                            }
                            menu = false;
                            break;
                        }

                    }

                }
                break;
            }
        }


    }
    static void StatIncrease(string input)
    {
        using (var db = new MyDbContext())
        {
            var hero = db.Hero.Where(h => h.UserId == Program.iUser.Id).ToList();

            foreach (var h in hero)
            {
                if (h.ActiveHero)
                {
                    if (input.ToLower() == "styrka")
                    {
                        Console.WriteLine("Du ökade din Styrka med 1");
                        h.Strength++;
                        db.SaveChanges();
                        break;
                    }
                    else if (input.ToLower() == "agility")
                    {
                        Console.WriteLine("Du ökade din Agility med 1");
                        h.Agility++;
                        db.SaveChanges();
                        break;
                    }
                    else if (input.ToLower() == "intelligence")
                    {
                        Console.WriteLine("Du ökade din Intelligence med 1");
                        h.Intelligence++;
                        db.SaveChanges();
                        break;
                    }
                    else if (input.ToLower() == "charm")
                    {
                        Console.WriteLine("Du ökade din Charm med 1");
                        h.Charm++;
                        db.SaveChanges();
                        break;
                    }
                }
            }
        }
    }
}
