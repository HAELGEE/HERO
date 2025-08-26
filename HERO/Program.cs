using HERO.Attacks;
using HERO.Interfaces;
using HERO.Menu;
using HERO.Models;

namespace HERO
{
    internal class Program
    {
        public static string loggedInUsername = "";
        public static IUser iUser = new User();

        static async Task Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                // Lägga till Admin om det inte finns någon admin
                List<User> users = db.User.ToList();
                bool foundAdmin = false;
                foreach (var user in users)
                {
                    if(user.Firstname == "Admin")
                        foundAdmin = true;
                }

                if(!foundAdmin)
                {
                    string hashedPassword = BC.EnhancedHashPassword("123Admin321", 14);

                    db.User.Add(new User
                    {
                        Firstname = "Admin",
                        Lastname = "Admin",
                        Email = "admin@admin.admin",
                        Password = hashedPassword,
                        IsAdmin = true
                    });
                    db.SaveChanges();                    
                }


                await Menu.Menu.StartMenu();
                //await Attack.Attacking();
                //Level.LevelUpStats();
            }
        }
    }
}
