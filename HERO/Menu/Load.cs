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
        bool menu = true;
        while (menu)
        {
            using (var db = new MyDbContext())
            {
                Console.Clear();
                //Entity.GettingAllHerosForUser();
                var heros = db.Hero.Where(h => h.UserId == Program.iUser.Id).ToList();

                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
                if (heros != null && heros.Count > 0)
                {
                    int menuSelecter = 0;
                    bool menu2 = true;

                    while (menu2)
                    {
                        Console.Clear();
                        List<Action> menuActions = new List<Action>();
                        List<string> menuChoice = new List<string>();
                        List<string> heroSelected = new List<string>();

                        foreach (var hero in heros)
                        {
                            var text = $"{hero.Username!} Level:{hero.Level}";
                            // Denna är till så att pilen i CMD hamnar på rätt ställe hela tiden (inte skiftar nära till långt bort)
                            if (text.Length < 10)
                                text = "   " + text + "   ";
                            else if (text.Length < 12)
                                text = "  " + text + "  ";
                            else if (text.Length < 14)
                                text = " " + text + " ";

                            menuChoice.Add(text);
                            heroSelected.Add(hero.Username!);
                            menuActions.Add(() => Console.WriteLine(TextCenter.CenterTexts(hero.Username!)));
                        }
                        menuChoice.Add("      Bakåt      ");
                        menuActions.Add(() => menu2 = false);

                        Console.WriteLine("\n\n\n\n\n" + TextCenter.CenterTexts("Vilken Hero vill du välja?"));
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
                                if (!string.IsNullOrWhiteSpace(menuChoice[menuSelecter]))
                                {
                                    var currentHero = db.Hero.Where(h => h.UserId == Program.iUser.Id && h.Username == heroSelected[menuSelecter]).ToList().SingleOrDefault();

                                    if (currentHero != null)
                                    {
                                        var resetActiveHero = db.Hero.Where(h => h.ActiveHero).ToList();

                                        if (resetActiveHero != null)
                                        {
                                            foreach (var hero in resetActiveHero)
                                            {
                                                hero.ActiveHero = false;
                                            }
                                            db.SaveChanges();
                                        }

                                        currentHero!.ActiveHero = true;
                                        db.SaveChanges();
                                        break;
                                    }
                                }
                                menuActions[menuSelecter].Invoke();  // Kör rätt funktion baserat på menyval
                            }
                        }
                    }
                    menu = false;
                    break;
                }
                else
                {
                    Console.WriteLine(TextCenter.CenterTexts("Du har inga Heros ännu"));
                    Console.WriteLine(TextCenter.CenterTexts("Tryck någon knapp för att gå bakåt"));
                    Console.ReadKey();
                    menu = false;
                    break;
                }



                //Console.WriteLine(TextCenter.CenterTexts("B för att bakåt"));
                //Console.WriteLine(TextCenter.CenterTexts("Vilken Hero vill du välja? [Välj genom att skriva in namnet på din Hero]"));

                //var position = Console.GetCursorPosition();
                //Console.SetCursorPosition((Console.WindowWidth / 2) - 3, position.Top + 1);
                //string heroChoice = Console.ReadLine()!;

                //if (heroChoice.ToLower() == "b")
                //    break;

                //if (!string.IsNullOrWhiteSpace(heroChoice))
                //{
                //    var resetActiveHero = db.Hero.Where(h => h.ActiveHero).ToList();

                //    if (resetActiveHero != null)
                //    {
                //        foreach (var hero in resetActiveHero)
                //        {
                //            hero.ActiveHero = false;
                //        }
                //        db.SaveChanges();
                //    }

                //    var currentHero = db.Hero.Where(h => h.UserId == Program.iUser.Id && h.Username == heroChoice).ToList().SingleOrDefault();

                //    if (currentHero != null)
                //    {
                //        currentHero!.ActiveHero = true;
                //        db.SaveChanges();
                //        break;
                //    }
                //}
            }
        }
    }
}
