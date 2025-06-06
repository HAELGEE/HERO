using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Menu;
internal class Level
{   
    public static void XpGain(int enemyLevel, int heroLevel)
    {
        int baseXP = 50;
        int levelDifference = enemyLevel - heroLevel;
        float xpMultiplier = 1 + (levelDifference * 0.2f);
        xpMultiplier = Math.Clamp(xpMultiplier, 0.5f, 2.0f);

        int earnedXP = (int)(baseXP * xpMultiplier);
    }
}
