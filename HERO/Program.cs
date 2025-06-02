using HERO.Models;
using HERO.Stuff;

namespace HERO
{
    internal class Program
    {
        public static string loggedInUsername = "";
        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                WelcomeMessage.StartMessage();
            }
        }
    }
}
