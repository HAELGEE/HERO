using HERO.Models;
using HERO.Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Menu;
internal class Create
{
    public static void CreateUser()
    {
        while (true)
        {
            using (var db = new MyDbContext())
            {
                Console.Clear();
                string firstName = "";
                string lastName = "";
                string email = "";
                string password = "";
                string password2 = "";
                int height = 0;

                Console.WriteLine(TextCenter.CenterTexts("B för att backa"));

                while (true)
                {
                    height += 2;
                    Console.WriteLine(TextCenter.CenterTexts("Förnamn: "));
                    Console.SetCursorPosition((Console.WindowWidth - 3) / 2, height);
                    firstName = Console.ReadLine()!;
                    if (!string.IsNullOrWhiteSpace(firstName) || firstName.ToLower() == "b")
                        break;
                    else
                    {
                        Console.WriteLine(TextCenter.CenterTexts("Kan inte vara tomt"));
                        height += 1;
                    }
                }
                if (firstName.ToLower() == "b")
                    break;

                while (true)
                {
                    height += 2;
                    Console.WriteLine(TextCenter.CenterTexts("Efternamn: "));
                    Console.SetCursorPosition((Console.WindowWidth - 2) / 2, height);
                    lastName = Console.ReadLine()!;
                    if (!string.IsNullOrWhiteSpace(lastName) || lastName.ToLower() == "b")
                        break;
                    else
                    {
                        height += 1;
                        Console.WriteLine(TextCenter.CenterTexts("Kan inte vara tomt"));
                    }
                }
                if (lastName.ToLower() == "b")
                    break;

                while (true)
                {
                    height += 2;
                    Console.WriteLine(TextCenter.CenterTexts("Email: "));
                    Console.SetCursorPosition((Console.WindowWidth - 12) / 2, height);
                    email = Console.ReadLine()!;
                    if (!string.IsNullOrWhiteSpace(email) || email.ToLower() == "b")
                        break;
                    else
                    {
                        height += 1;
                        Console.WriteLine(TextCenter.CenterTexts("Kan inte vara tomt"));
                    }
                }
                if (email.ToLower() == "b")
                    break;

                while (true)
                {
                    height += 2;
                    Console.WriteLine(TextCenter.CenterTexts("Lösenord: "));
                    Console.SetCursorPosition((Console.WindowWidth - 8) / 2, height);
                    password = Console.ReadLine()!;

                    if (!string.IsNullOrWhiteSpace(password) || password.ToLower() == "b")
                        break;
                    else
                    {
                        height += 1;
                        Console.WriteLine(TextCenter.CenterTexts("Kan inte vara tomt"));
                    }
                }
                if (password.ToLower() == "b")
                    break;

                while (true)
                {
                    height += 2;
                    Console.WriteLine(TextCenter.CenterTexts("Lösenord igen: "));
                    Console.SetCursorPosition((Console.WindowWidth - 8) / 2, height);
                    password2 = Console.ReadLine()!;

                    if (password == password2 || password2.ToLower() == "b")
                    {

                        if (!string.IsNullOrWhiteSpace(password) || password2.ToLower() == "b")
                            break;
                        else
                            Console.WriteLine(TextCenter.CenterTexts("Kan inte vara tomt"));
                    }
                    else
                    {
                        height += 1;
                        Console.WriteLine(TextCenter.CenterTexts("Du angav inte samma lösenord, fösök igen!"));
                    }
                }
                if (password2.ToLower() == "b")
                    break;

                string hashedPassword = BC.EnhancedHashPassword(password, 14);


                db.User.Add(new User(firstName, lastName, email, hashedPassword));
                db.SaveChanges();


            }
        }
    }

    public static void CreateHero()
    {
        while (true)
        {
            using (var db = new MyDbContext())
            {
                Console.Clear();
                Console.WriteLine(TextCenter.CenterTexts("Ange namn på din HERO"));
                Console.SetCursorPosition((Console.WindowWidth - 6) / 2, 2);
                string heroName = Console.ReadLine()!;

                if (!Database_Stuff.Entity.LookingIfHeroExist(heroName))
                {
                    if (!string.IsNullOrWhiteSpace(heroName))
                    {
                        db.Hero.Add(new Hero()
                        {
                            Username = heroName,
                        });

                        Color.ChangeColor(TextCenter.CenterTexts("Din Hero skapades framgångsrikt"), "Green");

                        db.SaveChanges();
                        Thread.Sleep(1500);
                        break;
                    }
                }
                else
                {
                    Color.ChangeColor(TextCenter.CenterTexts("Hero Username är redan taget av någon annan"), "Red");
                    Thread.Sleep(1500);
                }

            }
        }
    }
}
