using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriAOPServer
{
    internal class AreaOfPatrol
    {
        IPriAOP iPriAOP;
        internal AreaOfPatrol(IPriAOP priAOP)
        {
            iPriAOP = priAOP;
            API.SetConvarReplicated("current_aop", "Los Santos");
        }
        internal void RegisterCommands()
        {
            API.RegisterCommand("aop", new Action<int, List<object>, string>(SetAOP), false);
            API.RegisterCommand("aops", new Action<int, List<object>, string>(SetAOPSandy), false);
            API.RegisterCommand("aopc", new Action<int, List<object>, string>(SetAOPCity), false);
            API.RegisterCommand("aopb", new Action<int, List<object>, string>(SetAOPBlaine), false);
            API.RegisterCommand("aopl", new Action<int, List<object>, string>(SetAOPLosSantosCounty), false);
            API.RegisterCommand("aopp", new Action<int, List<object>, string>(SetAOPPaleto), false);
            API.RegisterCommand("aopsw", new Action<int, List<object>, string>(SetAOPState), false);
        }

        private async void SendAOPMessage(string aop)
        {
            for (int i = 1; i <= API.GetConvarInt("aop_chat_spam_count", 3); i++) {
                PriAOPServer.SendChatMessage(API.GetConvar("aop_chat_sender_name", "^1AOP"), String.Format(API.GetConvar("aop_chat_message", $"Area of Patrol has moved to ^1^_%s^r^7 please finish your RP and move to new AOP location"),aop));
            }
        }
        private async void SendPermissionErrorMessage(Player player)
        {
            PriAOPServer.SendPlayerChatMessage(player, API.GetConvar("aop_chat_sender_name", "^1AOP"), API.GetConvar("priaop_permission_denied", $"Nice try, you dont have permission to use this command"));
        }

        private async void SetAOP(int source, List<object> args, string raw)
        {
            if (await iPriAOP.CheckPerms(source))
            {
                if (args.Count < 1)
                {
                    PriAOPServer.SendPlayerChatMessage(iPriAOP.IPlayerList[source], API.GetConvar("aop_chat_sender_name", "^1AOP"), API.GetConvar("aop_location_missing", $"You must specify a location when using this command"));
                    return;
                }
                StringBuilder sb = new StringBuilder();
                foreach (string s in args)
                {
                    sb.Append($"{s} ");
                }
                SendAOPMessage(sb.ToString().ToTitleCase());
                API.SetConvarReplicated("current_aop", sb.ToString().ToTitleCase());
            }
            else
            {
                SendPermissionErrorMessage(iPriAOP.IPlayerList[source]);
            }
        }

        private async void SetAOPCity(int source, List<object> args, string raw)
        {
            
            if (await iPriAOP.CheckPerms(source))
            {
                string aop = API.GetConvar("aop_city","Los Santos");
                SendAOPMessage(aop);
                API.SetConvarReplicated("current_aop", aop);
            }
            else
            {
                SendPermissionErrorMessage(iPriAOP.IPlayerList[source]);
            }
        }

        private async void SetAOPSandy(int source, List<object> args, string raw)
        {
            
            if (await iPriAOP.CheckPerms(source))
            {
                string aop = API.GetConvar("aop_sandy", "Sandy Shores");
                SendAOPMessage(aop);
                API.SetConvarReplicated("current_aop", aop);
            }
            else
            {
                SendPermissionErrorMessage(iPriAOP.IPlayerList[source]);
            }
        }

        private async void SetAOPBlaine(int source, List<object> args, string raw)
        {
            
            if (await iPriAOP.CheckPerms(source))
            {
                string aop = API.GetConvar("aop_blaine", "Blaine County");
                SendAOPMessage(aop);
                API.SetConvarReplicated("current_aop", aop);
            }
            else
            {
                SendPermissionErrorMessage(iPriAOP.IPlayerList[source]);
            }
        }

        private async void SetAOPLosSantosCounty(int source, List<object> args, string raw)
        {

            if (await iPriAOP.CheckPerms(source))
            {
                string aop = API.GetConvar("aop_lossantos", "Los Santos County");
                SendAOPMessage(aop);
                API.SetConvarReplicated("current_aop", aop);
            }
            else
            {
                SendPermissionErrorMessage(iPriAOP.IPlayerList[source]);
            }
        }

        private async void SetAOPPaleto(int source, List<object> args, string raw)
        {
            
            if (await iPriAOP.CheckPerms(source))
            {
                string aop = API.GetConvar("aop_paleto", "Paleto Bay");
                SendAOPMessage(aop);
                API.SetConvarReplicated("current_aop", aop);
            }
            else
            {
                SendPermissionErrorMessage(iPriAOP.IPlayerList[source]);
            }
        }

        private async void SetAOPState(int source, List<object> args, string raw)
        {
            if (await iPriAOP.CheckPerms(source))
            {
                string aop = API.GetConvar("aop_state", "Statewide");
                SendAOPMessage(aop);
                API.SetConvarReplicated("current_aop", aop);
            }
            else
            {
                SendPermissionErrorMessage(iPriAOP.IPlayerList[source]);
            }
        }
    }
}
