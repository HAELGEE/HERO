using HERO.Models;
using HERO.Stuff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Menu;
internal class HeroStatus
{
    public static void CurrentHeroMenu()
    {
        using (var db = new MyDbContext())
        {
            var user = db.User.Where(x => x.IsLoggedIn == true && x.HeroUsing == Program.loggedInUsername).Select(x => x.HeroUsing).SingleOrDefault();
            var hero = db.Hero.Where(x => x.Username == user)  
                .ToList()
                .SingleOrDefault();

           
            Console.Clear();

            Console.WriteLine(TextCenter.CenterTexts("==========================================================="));
            Console.WriteLine(TextCenter.CenterTexts($"Ditt namn på din Hero: {hero.Username}\n"));
            Console.WriteLine(TextCenter.CenterTexts($"Titel: {hero.Title}\n"));
            Console.WriteLine(TextCenter.CenterTexts("Din hjälte är på Level: " + hero.Level));
            Console.WriteLine(TextCenter.CenterTexts($"Din hjälte har: {hero.CurrentXP}xp"));
            Console.WriteLine(TextCenter.CenterTexts($"Din hjälte har: {hero.MaxXP - hero.CurrentXP}xp kvar till nästa level\n"));
            Console.WriteLine(TextCenter.CenterTexts($"Du har för närvarande {hero.Gold} guld\n"));
            Console.Write(TextCenter.CenterHpText($"HP:"));

            if (hero.CurrentHealth < hero.MaxHealth)
                Stuff.Color.ChangeColor(hero.CurrentHealth, "Red");
            else
                Stuff.Color.ChangeColor(hero.CurrentHealth, "Green");
            Console.ResetColor();
            Console.Write(" av ");
            Stuff.Color.ChangeColor(hero.MaxHealth, "Green");

            Console.WriteLine(TextCenter.CenterTexts("Styrka: " + hero.Strength));
            Console.WriteLine(TextCenter.CenterTexts("Agility: " + hero.Agility));
            Console.WriteLine(TextCenter.CenterTexts("Stamina: " + hero.Stamina));
            Console.WriteLine(TextCenter.CenterTexts("Intelligence: " + hero.Intelligence));
            Console.WriteLine(TextCenter.CenterTexts("Charm: " + hero.Charm));
            Console.WriteLine(TextCenter.CenterTexts("Speed: " + hero.Speed));
            Console.WriteLine(TextCenter.CenterTexts("DMG: " + hero.Damage));
            Console.WriteLine(TextCenter.CenterTexts("ARMOR: " + hero.Armor));
            Console.WriteLine(TextCenter.CenterTexts($"LifeSteal: {hero.Lifesteal}"));
            Console.WriteLine(TextCenter.CenterTexts("==========================================================="));
            Console.ReadKey();
            Console.Clear();
        }
    }
}
