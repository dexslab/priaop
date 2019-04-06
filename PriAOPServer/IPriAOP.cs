using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriAOPServer
{
    interface IPriAOP
    {
        PlayerList IPlayerList { get; }
    }
}
