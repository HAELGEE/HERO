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
internal class PlayMenu
{
    public static void GamePlay()
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
            "Backa"
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
                        spel = false;
                        break;
                }
            }
        }
    }
}
