using HERO.Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HERO.Menu;
internal class Quit
{
    public static void QuitMessage()
    {
        Console.Clear();
        Console.WriteLine(TextCenter.CenterTexts("Tack för att du använder detta programmet, nu avslutas programmet"));
        Thread.Sleep(1000);
    }
}
