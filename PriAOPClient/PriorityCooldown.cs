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
            PriAOPClient.TriggerServerEvent("priaop:GetIsStaff");
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
                    API.SetTextColour(245, 19, 23, 255);
                    break;
                case "cooldown":
                    API.SetTextColour(245, 157, 50, 255);
                    break;
                case "active":
                    API.SetTextColour(19, 23, 245, 255);
                    break;
                case "finished":
                    API.SetTextColour(80, 252, 12, 255);
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
