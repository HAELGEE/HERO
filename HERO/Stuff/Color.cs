using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HERO.Stuff;
internal class Color
{    
    public static void ChangeColor<T>(T input, string color)
    {
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        Console.Write(input);
        Console.ResetColor();
    }
    public static void ChangeColorTextCenter<T>(T input, string color)
    {
        int padding = (Console.WindowWidth - input!.ToString()!.Length) / 2;
        string centeredText = new string(' ', padding) + input;
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        Console.Write(centeredText);
        Console.ResetColor();
    }

    public static void ChangeColorNewLine<T>(T input, string color)
    {
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        Console.WriteLine(input);
        Console.ResetColor();
    }
    public static void ChangeColorNewLineTextCenter<T>(T input, string color, T input2, T input3, string color2, T input4, T input5, string color3 , T input6)
    {
        string text = input!.ToString() + input2 + input3 + input4 + input5 + input6;

        int padding = (Console.WindowWidth - text.Length) / 2;
        string centeredText = new string(' ', padding);

        Console.Write(centeredText);
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        Console.Write(input);        
        Console.ResetColor();
        
        Console.Write(input2);
        
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color2);
        Console.Write(input3);
        Console.ResetColor();

        Console.Write(input4);

        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color3);
        Console.Write(input5);
        Console.ResetColor();

        Console.WriteLine(input6);        
    }
    public static void ChangeColorNewLineTextCenter2<T>(T input, T input2, string color, T input3, T input4, string color2)
    {
        string text = input!.ToString() + input2 + input3 + input4;

        int padding = (Console.WindowWidth - text.Length) / 2;
        string centeredText = new string(' ', padding);

        Console.SetCursorPosition(centeredText.Length, 1);

        //Console.Write(centeredText);
        Console.Write(input);

        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        Console.Write(input2);
        Console.ResetColor();

        Console.Write(input3);

        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color2);
        Console.Write(input4 + "\n");
        Console.ResetColor();
    }
}
