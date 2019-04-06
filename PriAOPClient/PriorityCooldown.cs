using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace PriAOPClient
{
    internal class PriorityCooldown
    {
        IPriAOPInterface iface;
        internal bool isStaff;
        string currentStatus;
        internal PriorityCooldown(IPriAOPInterface aOPInterface)
        {
            iface = aOPInterface;
            currentStatus = API.GetConvar("priority_status", "onhold").ToLower();
        }

        
        internal void Tick()
        {
            iface.LocalPlayer.IgnoredByEveryone = true;
            iface.LocalPlayer.IgnoredByPolice = true;
            iface.LocalPlayer.WantedLevel = 0;
            string pc = API.GetConvar("priority_cooldown", "Priorities are on HOLD");
            string pcstatus = API.GetConvar("priority_status", "onhold");
            if (!currentStatus.Equals(pcstatus))
            {
                currentStatus = pcstatus;
                if ((currentStatus.Equals("onhold") || currentStatus.Equals("cooldown")))
                {
                    API.NetworkSetFriendlyFireOption(false);
                }
                else if (currentStatus.Equals("finished") || currentStatus.Equals("inprogress"))
                {
                    API.NetworkSetFriendlyFireOption(true);
                }
            }
            API.SetTextFont(4);
            API.SetTextProportional(true);
            API.SetTextScale(0.0f, .45f);

            switch (pcstatus)
            {
                case "onhold":
                    string[] ohcolor = API.GetConvar("priority_onhold_color", "245,19,23,255").Split(',');
                    API.SetTextColour(int.Parse(ohcolor[0]), int.Parse(ohcolor[1]), int.Parse(ohcolor[2]), int.Parse(ohcolor[3]));
                    break;
                case "cooldown":
                    string[] cdcolor = API.GetConvar("priority_cooldown_color", "245,157,50,255").Split(',');
                    API.SetTextColour(int.Parse(cdcolor[0]), int.Parse(cdcolor[1]), int.Parse(cdcolor[2]), int.Parse(cdcolor[3]));
                    break;
                case "active":
                    string[] acolor = API.GetConvar("priority_inprogress_color", "19,23,245,255").Split(',');
                    API.SetTextColour(int.Parse(acolor[0]), int.Parse(acolor[1]), int.Parse(acolor[2]), int.Parse(acolor[3]));
                    break;
                case "finished":
                    string[] fcolor = API.GetConvar("priority_finished_color", "80,252,12,255").Split(',');
                    API.SetTextColour(int.Parse(fcolor[0]), int.Parse(fcolor[1]), int.Parse(fcolor[2]), int.Parse(fcolor[3]));
                    break;
            }
            
            API.SetTextDropShadow();
            API.SetTextEdge(2, 0, 0, 0, 255);
            API.SetTextDropShadow();
            API.SetTextOutline();
            API.SetTextEntry("STRING");
            API.AddTextComponentString(pc);
            API.DrawText(0.174f, 0.830f);
        }
    }

}
