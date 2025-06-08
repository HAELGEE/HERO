using HERO.Database_Stuff;
using HERO.Models;
using HERO.Attacks;
using HERO.Stuff;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Menu;
internal class PlayMenu
{
    public static async Task GamePlay()
    {
        string[] menuChoice = {
            "Kolla Status på din hjälte",
            "Roama runt och Attackera mobs",
            "Titlar",
            "Utrustade föremål",
            "Kolla hittade föremål",
            "Öppna Shopen",
            "Meditera (Heala din hjälte)",
            "Dungeons",
            "Bakåt"
            };
        int menuSelecter = 0;

        bool spel = true;

        while (spel)
        {
            Menu.LookingTitle(); // Till för att kolla om man dödat tillräcklig för att uppnå Titlar
            Level.LevelUpStats();
            Level.LevelStatIncrease();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(TextCenter.CenterTexts($"A game created by #Christofer Hägg"));
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < menuChoice.Length; i++)
            {
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


            if (key == ConsoleKey.DownArrow && menuSelecter < menuChoice.Length - 1)
            {
                menuSelecter++;
            }
            else if (key == ConsoleKey.UpArrow && menuSelecter >= 1)
            {
                menuSelecter--;
            }
            else if (key == ConsoleKey.Enter)
            {
                switch (menuSelecter)
                {
                    case 0:
                        Console.Clear();
                        if (Entity.LookingIfUserHaveActiveHero())
                            Menu.CurrentHeroMenu();
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(TextCenter.CenterTexts("Ingen vald Hero än"));
                            Thread.Sleep(1500);
                        }
                        break;

                    case 1:
                        Console.Clear();
                        //"Roama runt och Attackera mobs"
                        await Attack.Attacking();
                        break;

                    case 2:
                        //"Titlar"
                        Console.Clear();

                        Menu.TitleMenu();

                        break;

                    case 3:
                        Console.Clear();
                        //"Utrustade föremål"

                        break;

                    case 4:
                        Console.Clear();
                        //"Kolla hittade föremål"

                        break;

                    case 5:
                        Console.Clear();
                        //"Öppna Shopen"

                        break;

                    case 6:
                        //"Meditera (Heala din hjälte)"                        
                        Menu.HealingMenu();

                        break;

                    case 7:
                        Console.Clear();
                        //"Dungeons"   

                        break;

                    case 8:
                        Console.Clear();
                        spel = false;
                        break;
                }
            }
        }
    }
}
