using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class Dungeon
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int LevelRequirement { get; set; }

    public Dungeon()
    {
        GettingLevelRequirement();
    }

    void GettingLevelRequirement()
    {
        if (Name == "E")
            LevelRequirement = 6;
        else if (Name == "D")
            LevelRequirement = 10;
        else if (Name == "C")
            LevelRequirement = 16;
        else if (Name == "B")
            LevelRequirement = 22;
        else if (Name == "A")
            LevelRequirement = 28;
        else if (Name == "S")
            LevelRequirement = 34;
    }
}
