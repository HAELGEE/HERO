using HERO.Database_Stuff;
using HERO.Models;
using HERO.Stuff;
using Microsoft.EntityFrameworkCore;
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
        string one = "";
        string two = "";
        string three = "";
        string four = "";
        string back = "B för att backa";
        string errorMessage = "";

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
                //int height = 0;

                //Console.WriteLine("\n\n\n\n\n\n\n");

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\n");
                    Console.WriteLine(TextCenter.CenterTexts(back));
                    Console.WriteLine();
                    Color.ChangeColorNewLine(TextCenter.CenterTexts(errorMessage), "Red");
                    Console.WriteLine();

                    //height += 2;
                    Console.Write(TextCenter.CenterTexts("Förnamn: "));
                    //Console.SetCursorPosition((Console.WindowWidth - 3) / 2, height);
                    firstName = Console.ReadLine()!;
                    if (!string.IsNullOrWhiteSpace(firstName) || firstName.ToLower() == "b")
                    {
                        one = "Förnamn: " + firstName;
                        errorMessage = "";
                        break;
                    }
                    else
                    {
                        errorMessage = "Kan inte vara tomt";
                        //height += 1;
                    }
                }
                if (firstName.ToLower() == "b")
                    break;

                while (true)
                {
                    if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        Console.WriteLine("\n\n\n\n\n\n\n");
                        Console.WriteLine(TextCenter.CenterTexts(back));
                        Console.WriteLine();
                        Color.ChangeColorNewLine(TextCenter.CenterTexts(errorMessage), "Red");
                        Console.WriteLine();
                        Console.WriteLine(TextCenter.CenterTexts(one));
                    }

                    //height += 2;
                    Console.Write(TextCenter.CenterTexts("Efternamn: "));
                    //Console.SetCursorPosition((Console.WindowWidth - 2) / 2, height);
                    lastName = Console.ReadLine()!;
                    if (!string.IsNullOrWhiteSpace(lastName) || lastName.ToLower() == "b")
                    {
                        two = "Efternamn: " + lastName;
                        errorMessage = "";
                        break;
                    }
                    else
                    {
                        //height += 1;
                        errorMessage = "Kan inte vara tomt";
                        Console.Clear();
                    }
                }
                if (lastName.ToLower() == "b")
                    break;

                while (true)
                {
                    if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        Console.WriteLine("\n\n\n\n\n\n\n");
                        Console.WriteLine(TextCenter.CenterTexts(back));
                        Console.WriteLine();
                        Color.ChangeColorNewLine(TextCenter.CenterTexts(errorMessage), "Red");
                        Console.WriteLine();
                        Console.WriteLine(TextCenter.CenterTexts(one));
                        Console.WriteLine(TextCenter.CenterTexts(two));
                    }
                    //height += 2;
                    Console.Write(TextCenter.CenterTexts("Email: "));
                    //Console.SetCursorPosition((Console.WindowWidth - 12) / 2, height);
                    email = Console.ReadLine()!;                    

                    var user = Entity.GettingUserWithEmail(email);

                    if (email.ToLower() == "b")                    
                       break;                    

                    if (user != null)
                    {
                        errorMessage = "Finns redan en användare med det Email";
                        Console.Clear();
                    }
                    else if (!string.IsNullOrWhiteSpace(email))
                    {
                        three = "Email: " + email;
                        errorMessage = "";
                        break;
                    }
                    else
                    {
                        //height += 1;
                        errorMessage = "Kan inte vara tomt";
                        Console.Clear();
                    }

                }
                if (email.ToLower() == "b")
                    break;

                while (true)
                {
                    if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        Console.WriteLine("\n\n\n\n\n\n\n");
                        Console.WriteLine(TextCenter.CenterTexts(back));
                        Console.WriteLine();
                        Color.ChangeColorNewLine(TextCenter.CenterTexts(errorMessage), "Red");
                        Console.WriteLine();
                        Console.WriteLine(TextCenter.CenterTexts(one));
                        Console.WriteLine(TextCenter.CenterTexts(two));
                        Console.WriteLine(TextCenter.CenterTexts(three));
                    }
                    //height += 2;
                    Console.Write(TextCenter.CenterTexts("Lösenord: "));
                    //Console.SetCursorPosition((Console.WindowWidth - 8) / 2, height);
                    password = ReadHiddenInput();

                    if (!string.IsNullOrWhiteSpace(password) || password.ToLower() == "b")
                    {
                        four = "Lösenord: " + password;
                        errorMessage = "";
                        break;
                    }
                    else
                    {
                        //height += 1;
                        errorMessage = "Kan inte vara tomt";
                        Console.Clear();
                    }
                }
                Console.WriteLine();
                if (password.ToLower() == "b")
                    break;

                while (true)
                {
                    if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        Console.WriteLine("\n\n\n\n\n\n\n");
                        Console.WriteLine(TextCenter.CenterTexts(back));
                        Console.WriteLine();
                        Color.ChangeColorNewLine(TextCenter.CenterTexts(errorMessage), "Red");
                        Console.WriteLine();
                        Console.WriteLine(TextCenter.CenterTexts(one));
                        Console.WriteLine(TextCenter.CenterTexts(two));
                        Console.WriteLine(TextCenter.CenterTexts(three));
                        var hiddenPassword = "Lösenord: ";
                        for (int i = 0; i < password.Length; i++)
                        {
                            hiddenPassword += "*";
                        }
                        Console.WriteLine(TextCenter.CenterTexts(hiddenPassword));
                    }
                    //height += 2;
                    Console.Write(TextCenter.CenterTexts("Lösenord igen: "));
                    //Console.SetCursorPosition((Console.WindowWidth - 8) / 2, height);
                    password2 = ReadHiddenInput();

                    if (password == password2 || password2.ToLower() == "b")
                    {

                        if (!string.IsNullOrWhiteSpace(password) || password2.ToLower() == "b")
                            break;
                        else
                            errorMessage = "Kan inte vara tomt";
                    }
                    else
                    {
                        //height += 1;
                        errorMessage = "Du angav inte samma lösenord, fösök igen!";
                        Console.Clear();
                    }
                }
                if (password2.ToLower() == "b")
                    break;

                string hashedPassword = BC.EnhancedHashPassword(password, 14);


                db.User.Add(new User(firstName, lastName, email, hashedPassword));
                db.SaveChanges();
                break;
            }
        }
    }
    static string ReadHiddenInput()
    {
        string input = "";
        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(intercept: true);
            if (keyInfo.Key != ConsoleKey.Enter)
            {
                input += keyInfo.KeyChar;
            }
        }
        while (keyInfo.Key != ConsoleKey.Enter);

        return input;
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
                            UserId = Program.iUser.Id
                        });
                        db.SaveChanges();

                        Color.ChangeColor(TextCenter.CenterTexts("Din Hero skapades framgångsrikt"), "Green");
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


    //public static void CreateEnemyClass()
    //{
    //    using (var db = new MyDbContext())
    //    {

    //    }
    //}
    //public static void CreateEnemies()
    //{
    //    using(var db = new MyDbContext())
    //    {
    //        //klasser
    //        db.Enemy.Add(new Orc()
    //        {
    //            Class = "Orc",
    //            ClassId = 1
    //        });

    //        db.Enemy.Add(new Elf()
    //        {
    //            Class = "Elf",
    //            ClassId = 2
    //        });

    //        db.Enemy.Add(new Ghost()
    //        {
    //            Class = "Ghost",
    //            ClassId = 3
    //        });
    //        db.SaveChanges();

    //        // Orc
    //        db.Enemy.Add(new Grunt()
    //        {
    //            Id = 1,
    //            Subclass = "Grunt"
    //        });
    //        db.Enemy.Add(new Shaman()
    //        {
    //            Id = 1,
    //            Subclass = "Shaman"
    //        });
    //        db.Enemy.Add(new Goblin()
    //        {
    //            Id = 1,
    //            Subclass = "Goblin"
    //        });

    //        // Elf
    //        db.Enemy.Add(new Tharion()
    //        {
    //            Id = 2,
    //            Subclass = "Tharion"
    //        });
    //        db.Enemy.Add(new Tharion()
    //        {
    //            Id = 2,
    //            Subclass = "Tharion"
    //        });
    //        db.Enemy.Add(new Sylvestra()
    //        {
    //            Id = 2,
    //            Subclass = "Sylvestra"
    //        });

    //        // Ghost
    //        db.Enemy.Add(new Gravemourn()
    //        {
    //            Id = 3,
    //            Subclass = "Gravemourn"
    //        });
    //        db.Enemy.Add(new Hauntress()
    //        {
    //            Id = 3,
    //            Subclass = "Hauntress"
    //        });
    //        db.Enemy.Add(new Wraithon()
    //        {
    //            Id = 3,
    //            Subclass = "Wraithon"
    //        });
    //        db.SaveChanges();
    //    }
    //}
}
