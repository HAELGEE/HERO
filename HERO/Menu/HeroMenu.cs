using HERO.Models;
using HERO.Stuff;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Menu;
internal class HeroMenu
{
    public static void gamePlay()
    {
        

        string menu1 = "Kolla Status på din hjälte";
        string menu2 = TextCenter.CenterTexts("Roama runt och Attackera mobs");
        string menu3 = TextCenter.CenterTexts("Utrustade föremål");
        string menu4 = TextCenter.CenterTexts("Kolla hittade föremål");
        string menu5 = TextCenter.CenterTexts("Öppna Shopen");
        string menu6 = TextCenter.CenterTexts("Meditera (Heala din hjälte)");
        string menu7 = TextCenter.CenterTexts("Dungeons");
        string menu8 = TextCenter.CenterTexts("Spara din hjälte");
        string menu9 = TextCenter.CenterTexts("Ladda en hjälte");
        string menu10 = TextCenter.CenterTexts("Stänga Programmet");


        string[] menuChoice = {
            "Kolla Status på din hjälte",
            "Roama runt och Attackera mobs",
            "Titlar",
            "Utrustade föremål",
            "Kolla hittade föremål",
            "Öppna Shopen",
            "Meditera (Heala din hjälte)",
            "Dungeons",
            "Spara din hjälte",
            "Ladda en hjälte",
            "Stänga Programmet"
            };
        int menuSelecter = 0;

        bool spel = true;
        bool isFalse = true;

        while (spel)
        {

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
                    

                    case 10:
                        Console.Clear();
                        Console.WriteLine(TextCenter.CenterTexts("Tack för att du använder detta programmet, nu avslutas programmet"));
                        spel = false;
                        break;
                }
            }
        }
    }
}
