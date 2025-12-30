using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.EnemyStuff;
internal class Name
{
    public static string OrcName()
    {
        Random random = new Random();
        switch (random.Next(0, 20))
        {
            case 0:
                return "Vorgak";
            case 1:
                return "Ulzari";
            case 2:
                return "Grazna";
            case 3:
                return "Morgha";
            case 4:
                return "Nagzul";
            case 5:
                return "Drakza";
            case 6:
                return "Brothar";
            case 7:
                return "Zunara";
            case 8:
                return "Urzok";
            case 9:
                return "Krasha";
            case 10:
                return "Karnog";
            case 11:
                return "Vorgai";
            case 12:
                return "Dravuk";
            case 13:
                return "Zulgok";
            case 14:
                return "Thuzra";
            case 15:
                return "Morgash";
            case 16:
                return "Brakka";
            case 17:
                return "Throgar";
            case 18:
                return "Nalzug";
            case 19:
                return "Gruknar";
            default:
                return "Morgha";
        }
    }
    public static string ElfName()
    {
        Random random = new Random();
        switch (random.Next(0, 20))
        {
            case 0:
                return "Aerendil";
            case 1:
                return "Serelith";
            case 2:
                return "Thalion";
            case 3:
                return "Anariel";
            case 4:
                return "Elravan";
            case 5:
                return "Lirae";
            case 6:
                return "Faelar";
            case 7:
                return "Vaelina";
            case 8:
                return "Sylion";
            case 9:
                return "Myrren";
            case 10:
                return "Caelir";
            case 11:
                return "Elunara";
            case 12:
                return "Lorienar";
            case 13:
                return "Sylthiel";
            case 14:
                return "Velthas";
            case 15:
                return "Naevys";
            case 16:
                return "Eryndor";
            case 17:
                return "Ilyndra";
            case 18:
                return "Nyvarin";
            case 19:
                return "Thalindra";
            default:
                return "Thalion";
        }
    }
    public static string GhostName()
    {
        Random random = new Random();
        switch (random.Next(0, 20))
        {
            case 0:
                return "Velmorr";
            case 1:
                return "Vessira";
            case 2:
                return "Tharion";
            case 3:
                return "Thalara";
            case 4:
                return "Eldrev";
            case 5:
                return "Nyssra";
            case 6:
                return "Nyxar";
            case 7:
                return "Eluneth";
            case 8:
                return "Mouren";
            case 9:
                return "Sirael";
            case 10:
                return "Silvark";
            case 11:
                return "Maerith";
            case 12:
                return "Drelthas";
            case 13:
                return "Ylvessa";
            case 14:
                return "Zorvain";
            case 15:
                return "Olyndra";
            case 16:
                return "Kaeroth";
            case 17:
                return "Zevara";
            case 18:
                return "Orridan";
            case 19:
                return "Lunethe";
            default:
                return "Vessira";
        }
    }
}
