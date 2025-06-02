using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Stuff;
internal class Color
{    public static void ChangeColor<T>(T input, string color)
    {
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        Console.Write(input);
        Console.ResetColor();
    }
}
