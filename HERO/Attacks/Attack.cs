using HERO.Database_Stuff;
using HERO.Menu;
using HERO.Models;
using HERO.Attacks;
using HERO.Stuff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Attacks;
internal class Attack
{
    static Enemy ReturningRandomEnemy()
    {
        switch (Random.Shared.Next(0, 9))
        {
            // Orcs
            case 0:
                return new Grunt(); // Tank
            case 1:
                return new Shaman(); //Healer
            case 2:
                return new Goblin(); //Dps

            //Elfs
            case 3:
                return new Tharion(); // Tank
            case 4:
                return new Elowen(); //Healer
            case 5:
                return new Sylvestra(); //Dps

            //Ghosts
            case 6:
                return new Gravemourn(); // Tank
            case 7:
                return new Hauntress(); //Healer
            case 8:
                return new Wraithon(); //Dps

            // Utifall något händer (vilket det inte skall)
            default:
                return new Goblin();

        }
    }

    public static async Task Attacking()
    {
        using (var db = new MyDbContext())
        {
            var enemy = ReturningRandomEnemy();
            var hero = await db.Hero.Where(h => h.UserId == Program.iUser.Id && h.ActiveHero == true).SingleOrDefaultAsync();
            //var hero = await db.Hero.Where(h => h.Id == 2).SingleOrDefaultAsync(); // tillfälligt lagt in denna för att se så det fungerar

            enemy.Turn = false;
            hero!.Turn = false;
            db.SaveChanges();

            enemy.TotalSpeed = enemy.Speed;
            hero!.TotalSpeed = hero!.Speed;
            db.SaveChanges();

            if (hero!.CurrentHealth <= 0)
                Console.WriteLine("\n\n\n\n\n\n\n\n\n" + TextCenter.CenterTexts("Du kan inte attackera med 0hp") + "\n\n\n\n\n\n\n");
            else
            {
                int height = 4;
                while (true)
                {
                    Color.ChangeColorNewLineTextCenter2($"    Hero: ", $"{hero!.CurrentHealth}", "Green", " - Fiende: ", $"{enemy.CurrentHealth}    ", "Red");

                    Console.SetCursorPosition(0, height);

                    hero!.Damage = (int?)(hero.BaseDamage * (100 / (100 + (double?)enemy.Armor)));
                    enemy.Damage = (int?)(enemy.BaseDamage * (100 / (100 + (double?)hero.Armor)));
                    db.SaveChanges();                                        
                    

                    // om båda har samma speed, lottning om vem som börjar
                    if (hero!.TotalSpeed == enemy.TotalSpeed)
                    {
                        if (Random.Shared.Next(0, 2) == 0)
                            hero!.TotalSpeed++;
                        else
                            enemy.TotalSpeed++;
                    }


                    // Hero attackerar (högre speed)
                    if (hero!.TotalSpeed > enemy.TotalSpeed)
                    {
                        hero!.Turn = true;
                        hero!.TotalSpeed = hero!.TotalSpeed - enemy.Speed;
                        db.SaveChanges();

                        Color.ChangeColorNewLineTextCenter($"{hero.Username}", "Green", " skadar ", $"{enemy.Name}", "Red", " med ", $"{hero.Damage}", "DarkCyan", " i skada");

                        enemy.CurrentHealth -= hero.Damage;
                        Thread.Sleep(800);
                    }
                    // Fiende attackerar (högre speed)
                    else if (enemy.TotalSpeed > hero.TotalSpeed)
                    {
                        enemy.Turn = true;
                        enemy.TotalSpeed = enemy!.TotalSpeed - hero!.Speed;
                        db.SaveChanges();

                        Color.ChangeColorNewLineTextCenter($"{enemy.Name}", "Red", " skadar ", $"{hero.Username}", "Green", " med ", $"{enemy.Damage}", "DarkCyan", " i skada");


                        hero.CurrentHealth -= enemy.Damage;
                        Thread.Sleep(800);
                    }
                    db.SaveChanges();

                    if (enemy.Turn && hero!.Turn)
                    {
                        hero!.TotalSpeed = hero!.Speed; // Reset på speed
                        enemy.TotalSpeed = enemy.Speed; // Reset på speed
                        enemy.Turn = false;
                        hero!.Turn = false;
                        db.SaveChanges();
                    }

                    if (hero.CurrentHealth <= 0 || enemy.CurrentHealth <= 0)
                    {
                        
                        hero!.TotalSpeed = 0;
                        db.SaveChanges();

                        if (hero.CurrentHealth <= 0)
                        {
                            Console.WriteLine("\n" + TextCenter.CenterTexts("Din Hero dog!"));
                            Thread.Sleep(800);

                            Menu.Menu.HealingMenu();                           

                            db.SaveChanges();
                        }
                        if (enemy.CurrentHealth <= 0)
                        {
                            Console.WriteLine("\n" + TextCenter.CenterTexts($"Du besegrade {enemy.Name}"));
                            if (enemy.Race == "Orc")
                                hero.OrcSlain++;
                            else if(enemy.Race == "Elf")
                                hero.ElfSlain++;
                            else if(enemy.Race == "Ghost")
                                hero.GhostSlain++;


                            Thread.Sleep(800);
                            db.SaveChanges();
                        }
                        break;
                    }
                    height++;
                }
            }
        }
    }
}
