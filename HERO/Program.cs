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
                await Menu.Menu.StartMenu();
                //await Attack.Attacking();

            }
        }
    }
}
