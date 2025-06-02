﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Stuff;
internal class TextCenter
{
    public static string CenterTexts(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        int padding = (Console.WindowWidth - text.Length) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }
    public static string CenterTextss(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        int padding = (Console.WindowWidth - text.Length + 8) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }
    public static string CenterMenu(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        int padding = (Console.WindowWidth - text.Length + 6) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }
    public static string CenterMenu2(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        int padding = (Console.WindowWidth - text.Length + 14) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }
    public static string CenterTextsss(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        int padding = (Console.WindowWidth - text.Length) / 2;
        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }

    public static string CenterTexts2(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        // Här har jag + 7 då det är 14 "extra" tecken i ordet så den possitionerar sig fel
        int padding = (Console.WindowWidth - text.Length + 8) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }
    public static string CenterTexts3(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        // Här har jag + 7 då det är 14 "extra" tecken i ordet så den possitionerar sig fel
        int padding = (Console.WindowWidth - text.Length - 18) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }
    public static string CenterHpText(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        // Här har jag + 7 då det är 14 "extra" tecken i ordet så den possitionerar sig fel
        int padding = (Console.WindowWidth - text.Length - 8) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }
    public static string CenterTextsHeroName(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        // Här har jag + 7 då det är 14 "extra" tecken i ordet så den possitionerar sig fel
        int padding = (Console.WindowWidth - text.Length - 22) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }
    public static string CenterTextsEnemyName(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        // Här har jag + 7 då det är 14 "extra" tecken i ordet så den possitionerar sig fel
        int padding = (Console.WindowWidth - text.Length - 21) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }
    public static string CenterTextsWhenDead(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        // Här har jag + 7 då det är 14 "extra" tecken i ordet så den possitionerar sig fel
        int padding = (Console.WindowWidth - text.Length - 14) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }
    public static string CenterHeroTextInDungeon(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        // Här har jag + 7 då det är 14 "extra" tecken i ordet så den possitionerar sig fel
        int padding = (Console.WindowWidth - text.Length - 17) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }
    public static string CenterTextsEnemySpellCasters(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        // Här har jag + 7 då det är 14 "extra" tecken i ordet så den possitionerar sig fel
        int padding = (Console.WindowWidth - text.Length - 48) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }
    public static string CenterTextsEnemySpellCastersWhenNoHealing(string text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        // Här har jag + 7 då det är 14 "extra" tecken i ordet så den possitionerar sig fel
        int padding = (Console.WindowWidth - text.Length - 20) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText;
    }
    public static string CenterNumbers(int text)
    {
        // Räknar ut Console fönstrets bredd och tar bort tar textens längd och delar sedan den på 2
        // Här har jag + 7 då det är 14 "extra" tecken i ordet så den possitionerar sig fel
        int padding = (Console.WindowWidth - text.ToString().Length + 13) / 2;

        // Lägger till mellanslag (tom ruta) för uträkningen ovan och sedan lägger till texten i mitten av fönstret
        string centeredText = new string(' ', padding) + text;

        // Returnerar den texten som precis blivit centrerad
        return centeredText.ToString();
    }

}
