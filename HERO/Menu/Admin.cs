using HERO.Database_Stuff;
using HERO.Models;
using HERO.Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Menu;
internal class Admin
{
    public static void AdminMenu()
    {
        while (true)
        {
            using(var db = new MyDbContext())
            {
                Console.Clear();

                Console.WriteLine(TextCenter.CenterMenu("1. Kolla alla användare"));
                Console.WriteLine(TextCenter.CenterMenu("B för att backa"));

                string menuChoice = Console.ReadLine()!;
                int intMenuChoice = 0;

                if (menuChoice.ToLower() == "b")
                    break;

                if (int.TryParse(menuChoice, out intMenuChoice) && intMenuChoice > 0)
                {
                    switch (intMenuChoice)
                    {
                        case 1:
                            Entity.GettingAllUsers();
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Okänd input, försök igen");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
