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
    public static async Task StartMenu()
    {
        int menuSelecter1 = 0;
        bool menu = true;
        using (var db = new MyDbContext())
        {
            while (menu)
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
                    menuChoice1.Add("\x1b[3mLadda Hero\x1b[0m");
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
                                Program.iUser.IsLoggedIn = false;
                                Program.iUser.IsAdmin = false;
                                user!.IsLoggedIn = false;
                                db.SaveChanges();
                            }

                            break;

                        case 2:
                            if (Entity.LookingIfUserHaveActiveHero())
                                CurrentHeroMenu();
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine(TextCenter.CenterTexts("Ingen vald Hero än"));
                                Thread.Sleep(1500);
                            }

                            break;

                        case 3:
                            Load.LoadingHero();
                            break;

                        case 4:
                            if (Entity.LookingIfUserHaveActiveHero())
                                await PlayMenu.GamePlay();
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine(TextCenter.CenterTexts("Ingen vald Hero än"));
                                Thread.Sleep(1500);
                            }
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

                        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
                        if (titles != null && titles.Count > 0)
                        {
                            int menuSelecter = 0;
                            bool menu2 = true;

                            while (menu2)
                            {
                                Console.Clear();
                                List<Action> menuActions = new List<Action>();
                                List<string> menuChoice = new List<string>();

                                foreach (var title in titles)
                                {
                                    menuChoice.Add(title.Name!);
                                    menuActions.Add(() => Console.WriteLine(TextCenter.CenterTexts(title.Name!)));
                                }
                                menuChoice.Add("Bakåt");
                                menuActions.Add(() => menu2 = false);

                                Console.WriteLine("\n\n\n\n\n" + TextCenter.CenterTexts("Vilken titel vill du använda"));
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
                                    }
                                }
                            }
                            menu = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine(TextCenter.CenterTexts("Du har inga Titlar ännu"));
                            Console.WriteLine(TextCenter.CenterTexts("Tryck någon knapp för att gå bakåt"));
                            Console.ReadKey();
                            menu = false;
                            break;
                        }
                    }

                }
                break;
            }
        }
    }
    public static async Task LookingTitle()
    {
        using (var db = new MyDbContext())
        {
            // Kontroll så man är inne på rätt Hero            
            var user = await db.Hero.Where(u => u.UserId == Program.iUser.Id).ToListAsync();

            if (user != null)
            {
                foreach (var hero in user)
                {
                    if (hero.ActiveHero)
                    {
                        var titles = db.Title.Where(t => t.HeroId == hero.Id).ToList();

                        if (hero.OrcSlain >= 500)
                        {
                            AddingTitle("Orc");
                        }
                        if (hero.ElfSlain >= 500)
                        {
                            AddingTitle("Elf");
                        }
                        if (hero.GhostSlain >= 500)
                        {
                            AddingTitle("Ghost");
                        }
                    }
                }
            }
        }
    }
    static void AddingTitle(string input)
    {
        using (var db = new MyDbContext())
        {
            var user = db.Hero.Where(u => u.UserId == Program.iUser.Id).ToList();

            foreach (var hero in user)
            {
                if (hero.ActiveHero)
                {
                    var titles = db.Title.Where(t => t.HeroId == hero.Id && t.Name!.Contains(input)).SingleOrDefault();

                    if (titles == null)
                    {
                        db.Title.Add(new Title
                        {
                            HeroId = hero.Id,
                            Name = $"{input} Slayer"
                        });
                        db.SaveChanges();
                    }
                }
            }
        }
    }
    public static void HealingMenu()
    {
        using (var db = new MyDbContext())
        {
            Console.Clear();
            var hero = db.Hero.Where(h => h.ActiveHero == true).SingleOrDefault();

            if (hero!.CurrentHealth == hero.MaxHealth)
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine(TextCenter.CenterTexts("Din hjälte har redan fullt HP"));
                Thread.Sleep(850);
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
    public static void CurrentHeroMenu()
    {
        using (var db = new MyDbContext())
        {
            Console.Clear();

            var hero = db.Hero.Where(x => x.ActiveHero == true && x.UserId == Program.iUser.Id)
                .SingleOrDefault();

            Console.WriteLine("\n\n\n");

            Console.WriteLine(TextCenter.CenterTexts("==========================================================="));
            Console.WriteLine(TextCenter.CenterTexts($"Ditt namn på din Hero: {hero!.Username}\n"));
            Console.WriteLine(TextCenter.CenterTexts($"Titel: {hero.Title}\n"));
            Console.WriteLine(TextCenter.CenterTexts("Din Hero är på Level: " + hero.Level));
            Console.WriteLine(TextCenter.CenterTexts($"Din Hero har: {hero.CurrentXP}xp"));
            Console.WriteLine(TextCenter.CenterTexts($"Din Hero har: {hero.MaxXP - hero.CurrentXP}xp kvar till nästa level\n"));
            Console.WriteLine(TextCenter.CenterTexts($"Du har för närvarande {hero.Gold} guld\n"));
            Console.Write(TextCenter.CenterHpText($"HP: "));

            if (hero.CurrentHealth < hero.MaxHealth)
                Stuff.Color.ChangeColor(hero.CurrentHealth, "Red");
            else
                Stuff.Color.ChangeColor(hero.CurrentHealth, "Green");
            Console.ResetColor();
            Console.Write(" av ");
            Stuff.Color.ChangeColor(hero.MaxHealth, "Green");
            Console.WriteLine();
            Console.WriteLine(TextCenter.CenterTexts("Styrka: " + hero.Strength));
            Console.WriteLine(TextCenter.CenterTexts("Agility: " + hero.Agility));
            Console.WriteLine(TextCenter.CenterTexts("Stamina: " + hero.Stamina));
            Console.WriteLine(TextCenter.CenterTexts("Intelligence: " + hero.Intelligence));
            Console.WriteLine(TextCenter.CenterTexts("Charm: " + hero.Charm));
            Console.WriteLine(TextCenter.CenterTexts("Speed: " + hero.Speed));
            Console.WriteLine(TextCenter.CenterTexts("DMG: " + hero.BaseDamage));
            Console.WriteLine(TextCenter.CenterTexts("ARMOR: " + hero.Armor));
            Console.WriteLine(TextCenter.CenterTexts($"LifeSteal: {hero.Lifesteal}"));
            Console.WriteLine(TextCenter.CenterTexts("==========================================================="));
            Console.ReadKey();
            Console.Clear();
        }
    }
}
