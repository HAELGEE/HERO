using HERO.Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HERO.Menu;
internal class WelcomeMessage
{
    public static void StartMessage()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(TextCenter.CenterTexts2("\x1b[3m-<The Game>-\x1b[0m"));
        Console.WriteLine(TextCenter.CenterTexts(@"          _____                    _____                    _____                   _______         "));
        Console.WriteLine(TextCenter.CenterTexts(@"         /\    \                  /\    \                  /\    \                 /::\    \        "));
        Console.WriteLine(TextCenter.CenterTexts(@"        /::\____\                /::\    \                /::\    \               /::::\    \       "));
        Console.WriteLine(TextCenter.CenterTexts(@"       /:::/    /               /::::\    \              /::::\    \             /::::::\    \      "));
        Console.WriteLine(TextCenter.CenterTexts(@"      /:::/    /               /::::::\    \            /::::::\    \           /::::::::\    \     "));
        Console.WriteLine(TextCenter.CenterTexts(@"     /:::/    /               /:::/\:::\    \          /:::/\:::\    \         /:::/~~\:::\    \    "));
        Console.WriteLine(TextCenter.CenterTexts(@"    /:::/____/               /:::/__\:::\    \        /:::/__\:::\    \       /:::/    \:::\    \   "));
        Console.WriteLine(TextCenter.CenterTexts(@"   /::::\    \              /::::\   \:::\    \      /::::\   \:::\    \     /:::/    / \:::\    \  "));
        Console.WriteLine(TextCenter.CenterTexts(@"  /::::::\    \   _____    /::::::\   \:::\    \    /::::::\   \:::\    \   /:::/____/   \:::\____\ "));
        Console.WriteLine(TextCenter.CenterTexts(@" /:::/\:::\    \ /\    \  /:::/\:::\   \:::\    \  /:::/\:::\   \:::\____\ |:::|    |     |:::|    |"));
        Console.WriteLine(TextCenter.CenterTexts(@"/:::/  \:::\    /::\____\/:::/__\:::\   \:::\____\/:::/  \:::\   \:::|    ||:::|____|     |:::|    |"));
        Console.WriteLine(TextCenter.CenterTexts(@"\::/    \:::\  /:::/    /\:::\   \:::\   \::/    /\::/   |::::\  /:::|____| \:::\    \   /:::/    / "));
        Console.WriteLine(TextCenter.CenterTexts(@" \/____/ \:::\/:::/    /  \:::\   \:::\   \/____/  \/____|:::::\/:::/    /   \:::\    \ /:::/    /  "));
        Console.WriteLine(TextCenter.CenterTexts(@"          \::::::/    /    \:::\   \:::\    \            |:::::::::/    /     \:::\    /:::/    /   "));
        Console.WriteLine(TextCenter.CenterTexts(@"           \::::/    /      \:::\   \:::\____\           |::|\::::/    /       \:::\__/:::/    /    "));
        Console.WriteLine(TextCenter.CenterTexts(@"           /:::/    /        \:::\   \::/    /           |::| \::/____/         \::::::::/    /     "));
        Console.WriteLine(TextCenter.CenterTexts(@"          /:::/    /          \:::\   \/____/            |::|  ~|                \::::::/    /      "));
        Console.WriteLine(TextCenter.CenterTexts(@"         /:::/    /            \:::\    \                |::|   |                 \::::/    /       "));
        Console.WriteLine(TextCenter.CenterTexts(@"        /:::/    /              \:::\____\               \::|   |                  \::/____/        "));
        Console.WriteLine(TextCenter.CenterTexts(@"        \::/    /                \::/    /                \:|   |                   ~~              "));
        Console.WriteLine(TextCenter.CenterTexts(@"         \/____/                  \/____/                  \|___|                                   "));
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }
}
