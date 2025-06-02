using HERO.Interfaces;
using HERO.Menu;
using HERO.Models;

namespace HERO
{
    internal class Program
    {
        public static string loggedInUsername = "";
        public static IUser iUser = new User();

        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                Menu.Menu.StartMenu();
            }
        }
    }
}
