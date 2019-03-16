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

        private async void SetAOP(int source, List<object> args, string raw)
        {
            if (await iPriAOP.CheckPerms(source))
            {
                if (args.Count < 1)
                {
                    dynamic stuff = new System.Dynamic.ExpandoObject();
                    stuff.args = new string[] { "^1AOP", $"You must specify a location when using this command" };
                    stuff.color = new int[] { 255, 255, 0 };
                    iPriAOP.IPlayerList[source].TriggerEvent("chat:addMessage", stuff);
                    return;
                }
                StringBuilder sb = new StringBuilder();
                foreach (string s in args)
                {
                    sb.Append($"{s} ");
                }
                string aop = sb.ToString().ToTitleCase();
                dynamic msg = new System.Dynamic.ExpandoObject();
                msg.args = new string[] { $"{API.GetConvar}", $"Area of Patrol has moved to ^1^_{aop}^r^7 please finish your RP and move to new AOP location" };
                msg.color = new int[] { 255, 255, 0 };
                PriAOPServer.TriggerClientEvent("chat:addMessage", msg);
                API.SetConvarReplicated("current_aop", aop);
            }
            else
            {
                dynamic stuff = new System.Dynamic.ExpandoObject();
                stuff.args = new string[] { "^1MASRP AOP", $"Nice try, you dont have permission to use this command" };
                stuff.color = new int[] { 255, 255, 0 };
                iPriAOP.IPlayerList[source].TriggerEvent("chat:addMessage", stuff);
                return;
            }
        }

        private async void SetAOPCity(int source, List<object> args, string raw)
        {
            
            if (await iPriAOP.CheckPerms(source))
            {
                string aop = "Los Santos";
                dynamic msg = new System.Dynamic.ExpandoObject();
                msg.args = new string[] { "^1MASRP AOP", $"Area of Patrol has moved to ^1^_{aop}^r^7 please finish your RP and move to new AOP location" };
                msg.color = new int[] { 255, 255, 0 };
                PriAOPServer.TriggerClientEvent("chat:addMessage", msg);
                API.SetConvarReplicated("current_aop", aop);
            }
            else
            {
                dynamic stuff = new System.Dynamic.ExpandoObject();
                stuff.args = new string[] { "^1MASRP AOP", $"Nice try, you dont have permission to use this command" };
                stuff.color = new int[] { 255, 255, 0 };
                iPriAOP.IPlayerList[source].TriggerEvent("chat:addMessage", stuff);
                return;
            }
        }

        private async void SetAOPSandy(int source, List<object> args, string raw)
        {
            
            if (await iPriAOP.CheckPerms(source))
            {
                string aop = "Sandy Shores";
                dynamic msg = new System.Dynamic.ExpandoObject();
                msg.args = new string[] { "^1MASRP AOP", $"Area of Patrol has moved to ^1^_{aop}^r^7 please finish your RP and move to new AOP location" };
                msg.color = new int[] { 255, 255, 0 };
                PriAOPServer.TriggerEvent("chat:addMessage", msg);
                API.SetConvarReplicated("current_aop", aop);
            }
            else
            {
                dynamic stuff = new System.Dynamic.ExpandoObject();
                stuff.args = new string[] { "^1MASRP AOP", $"Nice try, you dont have permission to use this command" };
                stuff.color = new int[] { 255, 255, 0 };
                iPriAOP.IPlayerList[source].TriggerEvent("chat:addMessage", stuff);
                return;
            }
        }

        private async void SetAOPBlaine(int source, List<object> args, string raw)
        {
            
            if (await iPriAOP.CheckPerms(source))
            {
                string aop = "Blaine County";
                dynamic msg = new System.Dynamic.ExpandoObject();
                msg.args = new string[] { "^1MASRP AOP", $"Area of Patrol has moved to ^1^_{aop}^r^7 please finish your RP and move to new AOP location" };
                msg.color = new int[] { 255, 255, 0 };
                PriAOPServer.TriggerClientEvent("chat:addMessage", msg);
                API.SetConvarReplicated("current_aop", aop);
            }
            else
            {
                dynamic stuff = new System.Dynamic.ExpandoObject();
                stuff.args = new string[] { "^1MASRP AOP", $"Nice try, you dont have permission to use this command" };
                stuff.color = new int[] { 255, 255, 0 };
                iPriAOP.IPlayerList[source].TriggerEvent("chat:addMessage", stuff);
                return;
            }
        }

        private async void SetAOPLosSantosCounty(int source, List<object> args, string raw)
        {

            if (await iPriAOP.CheckPerms(source))
            {
                string aop = "Los Santos County";
                dynamic msg = new System.Dynamic.ExpandoObject();
                msg.args = new string[] { "^1MASRP AOP", $"Area of Patrol has moved to ^1^_{aop}^r^7 please finish your RP and move to new AOP location" };
                msg.color = new int[] { 255, 255, 0 };
                PriAOPServer.TriggerClientEvent("chat:addMessage", msg);
                API.SetConvarReplicated("current_aop", aop);
            }
            else
            {
                dynamic stuff = new System.Dynamic.ExpandoObject();
                stuff.args = new string[] { "^1MASRP AOP", $"Nice try, you dont have permission to use this command" };
                stuff.color = new int[] { 255, 255, 0 };
                iPriAOP.IPlayerList[source].TriggerEvent("chat:addMessage", stuff);
                return;
            }
        }

        private async void SetAOPPaleto(int source, List<object> args, string raw)
        {
            
            if (await iPriAOP.CheckPerms(source))
            {
                string aop = "Paleto Bay";
                dynamic msg = new System.Dynamic.ExpandoObject();
                msg.args = new string[] { "^1MASRP AOP", $"Area of Patrol has moved to ^1^_{aop}^r^7 please finish your RP and move to new AOP location" };
                msg.color = new int[] { 255, 255, 0 };
                PriAOPServer.TriggerClientEvent("chat:addMessage", msg);
                API.SetConvarReplicated("current_aop", aop);
            }
            else
            {
                dynamic stuff = new System.Dynamic.ExpandoObject();
                stuff.args = new string[] { "^1MASRP AOP", $"Nice try, you dont have permission to use this command" };
                stuff.color = new int[] { 255, 255, 0 };
                iPriAOP.IPlayerList[source].TriggerEvent("chat:addMessage", stuff);
                return;
            }
        }

        private async void SetAOPState(int source, List<object> args, string raw)
        {
            if (await iPriAOP.CheckPerms(source))
            {
                string aop = "Statewide";
                dynamic msg = new System.Dynamic.ExpandoObject();
                msg.args = new string[] { "^1MASRP AOP", $"Area of Patrol has moved to ^1^_{aop}^r^7 please finish your RP and SPREAD OUT" };
                msg.color = new int[] { 255, 255, 0 };
                PriAOPServer.TriggerClientEvent("chat:addMessage", msg);
                API.SetConvarReplicated("current_aop", aop);
            }
            else
            {
                dynamic stuff = new System.Dynamic.ExpandoObject();
                stuff.args = new string[] { "^1MASRP AOP", $"Nice try, you dont have permission to use this command" };
                stuff.color = new int[] { 255, 255, 0 };
                iPriAOP.IPlayerList[source].TriggerEvent("chat:addMessage", stuff);
                return;
            }
        }
    }
}
