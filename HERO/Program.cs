using HERO.Models;
using HERO.Stuff;

namespace HERO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                WelcomeMessage.StartMessage();
            }
        }
    }
}
