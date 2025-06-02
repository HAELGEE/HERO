using HERO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Interfaces;
internal interface IUser
{
    public bool IsLoggedIn { get; set; }
    public bool IsAdmin { get; set; }
}
