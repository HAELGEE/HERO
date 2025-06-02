using HERO.Interfaces;
using HERO.Models;
using HERO.Stuff;
using System;
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

                    if (Program.iUser.IsAdmin)
                        menuChoice1.Add("\x1b[3mAdmin\x1b[0m");
                    menuChoice1.Add("\x1b[3mAvsluta\x1b[0m");
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
                            User user = new User();
                            user.IsLoggedIn = false;
                            Program.iUser.IsLoggedIn = false;
                            Program.iUser.IsAdmin = false;
                            db.SaveChanges();
                            break;

                        case 2:
                            HeroStatus.CurrentHeroMenu();
                            break;

                        case 3:

                            break;

                        case 4:
                            Admin.AdminMenu();
                            break;

                        case 5:
                            menu = false;
                            Quit.QuitMessage();
                            break;
                    }
                }
            }
        }
    }
}
