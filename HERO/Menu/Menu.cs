using HERO.Database_Stuff;
using HERO.Interfaces;
using HERO.Models;
using HERO.Stuff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Menu;
public class Menu
{
    public static void StartMenu()
    {
        int menuSelecter1 = 0;
        bool menu = true;
        while (menu)
        {
            using (var db = new MyDbContext())
            {
                List<string> menuChoice1 = new List<string>();

                if (!Program.iUser.IsLoggedIn)
                {
                    menuChoice1.Add("\u001b[3mSkapa Konto\u001b[0m");
                    menuChoice1.Add("\x1b[3mLogga in\x1b[0m");
                    menuChoice1.Add("\x1b[3mAvsluta\x1b[0m");

                }
                else
                {
                    menuChoice1.Add("\u001b[3mSkapa Hero\u001b[0m");
                    menuChoice1.Add("\x1b[3mLogga ut\x1b[0m");
                    menuChoice1.Add("\x1b[3mHero Information\x1b[0m");
                    menuChoice1.Add("\x1b[3mSpara/Ladda Hero\x1b[0m");
                    menuChoice1.Add("\x1b[3mSpela\x1b[0m");
                    menuChoice1.Add("\x1b[3mAvsluta\x1b[0m");

                    if (Program.iUser.IsAdmin)
                        menuChoice1.Add("\x1b[3mAdmin\x1b[0m");
                }


                Console.Clear();

                WelcomeMessage.StartMessage();

                for (int i = 0; i < menuChoice1.Count; i++)
                {
                    if (i == menuSelecter1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(TextCenter.CenterMenu2($"{menuChoice1[i]}\t <---"));
                        Console.ResetColor();
                        Console.CursorVisible = false;
                    }
                    else
                        Console.WriteLine(TextCenter.CenterTextss(menuChoice1[i]));
                }

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.DownArrow && menuSelecter1 < menuChoice1.Count - 1)
                {
                    menuSelecter1++;
                }
                else if (key == ConsoleKey.UpArrow && menuSelecter1 >= 1)
                {
                    menuSelecter1--;
                }
                else if (key == ConsoleKey.Enter && !Program.iUser.IsLoggedIn)
                {
                    switch (menuSelecter1)
                    {
                        case 0:
                            Create.CreateUser();

                            break;

                        case 1:
                            Login.AccountLogin();
                            break;

                        case 2:
                            menu = false;
                            Quit.QuitMessage();
                            break;
                    }
                }
                else if (key == ConsoleKey.Enter && Program.iUser.IsLoggedIn)
                {
                    switch (menuSelecter1)
                    {
                        case 0:
                            Create.CreateHero();
                            break;

                        case 1:

                            var user = db.User.Where(u => u.Id == Program.iUser.Id).SingleOrDefault();

                            if (user != null)
                            {
                                user!.IsLoggedIn = false;
                                Program.iUser.IsLoggedIn = false;
                                Program.iUser.IsAdmin = false;
                                db.SaveChanges();
                            }

                            break;

                        case 2:
                            if (Entity.LookingIfUserHaveActiveHero())
                                HeroStatus.CurrentHeroMenu();
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine(TextCenter.CenterTexts("Ingen vald Hero än"));
                                Thread.Sleep(1500);
                            }

                            break;

                        case 3:

                            int menuSelecter2 = 0;
                            bool menu2 = true;
                            while (menu2)
                            {
                                Console.Clear();
                                List<string> menuChoice2 = new List<string>();

                                menuChoice2.Add("Spara nuvarande Hero");
                                menuChoice2.Add("Ladda Hero");
                                menuChoice2.Add("Backa");

                                for (int i = 0; i < menuChoice2.Count; i++)
                                {
                                    if (i == 0)
                                        Console.WriteLine($"\n\n\n\n\n\n\n\n");
                                    if (i == menuSelecter2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine(TextCenter.CenterMenu($"{menuChoice2[i]}\t <---"));
                                        Console.ResetColor();
                                        Console.CursorVisible = false;
                                    }
                                    else
                                        Console.WriteLine(TextCenter.CenterTexts(menuChoice2[i]));
                                }

                                var key2 = Console.ReadKey(true).Key;

                                if (key2 == ConsoleKey.DownArrow && menuSelecter2 < menuChoice2.Count - 1)
                                {
                                    menuSelecter2++;
                                }
                                else if (key2 == ConsoleKey.UpArrow && menuSelecter2 >= 1)
                                {
                                    menuSelecter2--;
                                }
                                else if (key2 == ConsoleKey.Enter)
                                {
                                    switch (menuSelecter2)
                                    {
                                        case 0:
                                            Save.SavingHero();
                                            break;

                                        case 1:
                                            Load.LoadingHero();
                                            break;

                                        case 2:
                                            menu2 = false;
                                            break;
                                    }
                                }

                            }
                            break;

                        case 4:
                            PlayMenu.GamePlay();
                            break;

                        case 5:
                            menu = false;
                            Quit.QuitMessage();
                            break;

                        case 6:
                            Admin.AdminMenu();
                            break;

                    }
                }
            }
        }
    }
    public static void TitleMenu()
    {
        while (true)
        {
            using (var db = new MyDbContext())
            {
                var hero = db.Hero.Where(h => h.UserId == Program.iUser.Id).SingleOrDefault();
                var titles = db.Title.Where(h => h.HeroId == hero.Id).ToList();


                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
                if (titles.Count == 0)
                {
                    Console.WriteLine(TextCenter.CenterTexts("Du har inga Titlar ännu"));
                    Console.WriteLine(TextCenter.CenterTexts("Tryck någon knapp för att gå bakåt"));
                    Console.ReadKey();
                    break;
                }
                else
                {
                    foreach (var title in titles)
                    {
                        Console.WriteLine(TextCenter.CenterTexts($"{title.Name}"));
                    }
                    Console.WriteLine("hej");
                }
            }
        }
    }
    public static void HealingMenu()
    {
        using (var db = new MyDbContext())
        {
            var hero = db.Hero.Where(h => h.ActiveHero == true).SingleOrDefault();

            if (hero.CurrentHealth == hero.MaxHealth)
            {
                Console.WriteLine(TextCenter.CenterTexts("Din hjälte har redan fullt HP"));
            }
            else
            {
                Console.WriteLine(TextCenter.CenterTexts("Din hjälte börjar Meditera för att återställa HP"));
                while (hero.CurrentHealth < hero.MaxHealth)
                {
                    if (hero.CurrentHealth < hero.MaxHealth * 0.25)    // När hjälten har mindre än 25% av maxHP
                    {
                        hero.CurrentHealth += 10;
                        Console.WriteLine(TextCenter.CenterTexts($"Nuvarande hp: {hero.CurrentHealth}"));
                        Thread.Sleep(300);
                    }
                    else if (hero.CurrentHealth < hero.MaxHealth * 0.50)      // När hjälten har mindre än 50% av maxHP
                    {
                        hero.CurrentHealth += 10;
                        Console.WriteLine(TextCenter.CenterTexts($"Nuvarande hp: {hero.CurrentHealth}"));
                        Thread.Sleep(450);
                    }
                    else if (hero.CurrentHealth < hero.MaxHealth * 0.75)      // När hjälten har mindre än 75% av maxHP
                    {
                        hero.CurrentHealth += 10;
                        Console.WriteLine(TextCenter.CenterTexts($"Nuvarande hp: {hero.CurrentHealth}"));
                        Thread.Sleep(700);
                    }
                    else    // När hjälten har mindre än 100% av maxHP
                    {
                        hero.CurrentHealth += 10;
                        if (hero.CurrentHealth > hero.MaxHealth)
                            hero.CurrentHealth = hero.MaxHealth;

                        Console.WriteLine(TextCenter.CenterTexts($"Nuvarande hp: {hero.CurrentHealth}"));
                        Thread.Sleep(850);
                    }
                }

                hero.CurrentHealth = hero.MaxHealth;
                db.SaveChanges();

                Console.WriteLine(TextCenter.CenterTexts($"Din hjälte har {hero.CurrentHealth}hp av {hero.CurrentHealth}hp"));
                Thread.Sleep(850);
            }
        }
    }
    public static string OrcName()
    {
        Random random = new Random();
        switch (random.Next(0, 20))
        {
            case 0:
                return "Vorgak";
            case 1:
                return "Ulzari";
            case 2:
                return "Grazna";
            case 3:
                return "Morgha";
            case 4:
                return "Nagzul";
            case 5:
                return "Drakza";
            case 6:
                return "Brothar";
            case 7:
                return "Zunara";
            case 8:
                return "Urzok";
            case 9:
                return "Krasha";
            case 10:
                return "Karnog";
            case 11:
                return "Vorgai";
            case 12:
                return "Dravuk";
            case 13:
                return "Zulgok";
            case 14:
                return "Thuzra";
            case 15:
                return "Morgash";
            case 16:
                return "Brakka";
            case 17:
                return "Throgar";
            case 18:
                return "Nalzug";
            case 19:
                return "Gruknar";
            default:
                return "Morgha";
        }
    }
    public static string ElfName()
    {
        Random random = new Random();
        switch (random.Next(0, 20))
        {
            case 0:
                return "Aerendil";
            case 1:
                return "Serelith";
            case 2:
                return "Thalion";
            case 3:
                return "Anariel";
            case 4:
                return "Elravan";
            case 5:
                return "Lirae";
            case 6:
                return "Faelar";
            case 7:
                return "Vaelina";
            case 8:
                return "Sylion";
            case 9:
                return "Myrren";
            case 10:
                return "Caelir";
            case 11:
                return "Elunara";
            case 12:
                return "Lorienar";
            case 13:
                return "Sylthiel";
            case 14:
                return "Velthas";
            case 15:
                return "Naevys";
            case 16:
                return "Eryndor";
            case 17:
                return "Ilyndra";
            case 18:
                return "Nyvarin";
            case 19:
                return "Thalindra";
            default:
                return "Thalion";
        }
    }
    public static string GhostName()
    {
        Random random = new Random();
        switch (random.Next(0, 20))
        {
            case 0:
                return "Velmorr";
            case 1:
                return "Vessira";
            case 2:
                return "Tharion";
            case 3:
                return "Thalara";
            case 4:
                return "Eldrev";
            case 5:
                return "Nyssra";
            case 6:
                return "Nyxar";
            case 7:
                return "Eluneth";
            case 8:
                return "Mouren";
            case 9:
                return "Sirael";
            case 10:
                return "Silvark";
            case 11:
                return "Maerith";
            case 12:
                return "Drelthas";
            case 13:
                return "Ylvessa";
            case 14:
                return "Zorvain";
            case 15:
                return "Olyndra";
            case 16:
                return "Kaeroth";
            case 17:
                return "Zevara";
            case 18:
                return "Orridan";
            case 19:
                return "Lunethe";
            default:
                return "Vessira";
        }
    }
}
