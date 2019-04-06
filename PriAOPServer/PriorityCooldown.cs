using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriAOPServer
{
    internal class PriorityCooldown
    {
        IPriAOP iPriAOP;
        TimeSpan elasped;
        bool inPC = true;
        bool pcStarted = false;
        DateTime pcStartTime;
        int currentPC;

        internal PriorityCooldown(IPriAOP priAOP)
        {
            iPriAOP = priAOP;
            API.SetConvarReplicated("priority_cooldown", "Priorities are on HOLD");
            API.SetConvarReplicated("priority_status", "onhold");
            currentPC = 10;
            pcStartTime = DateTime.Now;
        }

        internal void PriorityCooldown_Tick()
        {
            elasped = DateTime.Now - pcStartTime;
            if (elasped.TotalSeconds >= currentPC * 60 && pcStarted && inPC)
            {
                pcStarted = false;
                inPC = false;
                pcStartTime = DateTime.Now;
                API.SetConvarReplicated("priority_status", "finished");
                API.SetConvarReplicated("priority_cooldown", API.GetConvar("priority_onhold_message","Peace time has ended"));
            }
            else if (elasped.TotalSeconds < currentPC * 60 && pcStarted && inPC)
            {
                API.SetConvarReplicated("priority_cooldown",String.Format(API.GetConvar("priority_cooldown_message","Priority Cooldown: {0} until the next priority can begin"), elasped.Subtract(TimeSpan.FromMinutes(currentPC)).ToString(@"mm\:ss")));
            }
        }

        internal void RegisterCommands()
        {
            API.RegisterCommand("resetpc", new Action<int, List<object>, string>(ResetPC), false);
            API.RegisterCommand("inprogress", new Action<int, List<object>, string>(PCInProgress), false);
            API.RegisterCommand("onhold", new Action<int, List<object>, string>(PCOnHold), false);
            API.RegisterCommand("cooldown", new Action<int, List<object>, string>(ActivatePC), false);
            API.RegisterCommand("pcbypass", new Action<int, List<object>, string>(BypassPC), true);

        }

        private async void ResetPC(int p, List<object> args, string raw)
        {
            if (API.IsPlayerAceAllowed(iPriAOP.IPlayerList[p].Handle, "priaop.priority.use"))
            {
                inPC = false;
                pcStarted = false;
                API.SetConvarReplicated("priority_status", "finished");
                API.SetConvarReplicated("priority_cooldown", API.GetConvar("priority_finished_message", "Peace time has ended"));
            }
            else
            {
                SendPermissionErrorMessage(iPriAOP.IPlayerList[p]);
                return;
            }
        }

        private async void BypassPC(int p, List<object> args, string raw)
        {
            
        }

        private async void ActivatePC(int p, List<object> args, string raw)
        {

            if (API.IsPlayerAceAllowed(iPriAOP.IPlayerList[p].Handle, "priaop.priority.use"))
            {
                if (args.Count != 1)
                {
                    dynamic stuff = new System.Dynamic.ExpandoObject();
                    stuff.args = new string[] { API.GetConvar("priority_chat_sender_name", "^1PriorityCooldown"), "You must specify a time in mins for this command" };
                    stuff.color = new int[] { 255, 255, 0 };
                    iPriAOP.IPlayerList[p].TriggerEvent("chat:addMessage", stuff);
                    return;
                }
                if (!int.TryParse(args[0].ToString(), out currentPC))
                {
                    dynamic stuff = new System.Dynamic.ExpandoObject();
                    stuff.args = new string[] { API.GetConvar("priority_chat_sender_name", "^1PriorityCooldown"), "The time value must me a number please try again" };
                    stuff.color = new int[] { 255, 255, 0 };
                    iPriAOP.IPlayerList[p].TriggerEvent("chat:addMessage", stuff);
                    return;
                }
                API.SetConvarReplicated("priority_status", "cooldown");
                currentPC = int.Parse(args[0].ToString());
                pcStartTime = DateTime.Now;
                pcStarted = true;
                inPC = true;
            }
            else
            {
                SendPermissionErrorMessage(iPriAOP.IPlayerList[p]);
                return;
            }
        }

        private async void PCInProgress(int p, List<object> args, string raw)
        {

            if (API.IsPlayerAceAllowed(iPriAOP.IPlayerList[p].Handle, "priaop.priority.use"))
            {
                API.SetConvarReplicated("priority_cooldown", API.GetConvar("priority_inprogress_message", "Priority in Progress"));
                API.SetConvarReplicated("priority_status", "inprogress");
                pcStarted = false;
                inPC = false;
            }
            else
            {
                SendPermissionErrorMessage(iPriAOP.IPlayerList[p]);
                return;
            }
        }



        private async void PCOnHold(int p, List<object> args, string raw)
        {

            if (API.IsPlayerAceAllowed(iPriAOP.IPlayerList[p].Handle, "priaop.priority.use"))
            {
                API.SetConvarReplicated("priority_cooldown", API.GetConvar("priority_onhold_message","Priorities are on HOLD"));
                API.SetConvarReplicated("priority_status", "onhold");
                inPC = false;
                pcStarted = false;
            }
            else
            {
                SendPermissionErrorMessage(iPriAOP.IPlayerList[p]);
                return;
            }
        }

        private async void SendPermissionErrorMessage(Player player)
        {
            PriAOPServer.SendPlayerChatMessage(player, API.GetConvar("priority_chat_sender_name", "^1PriorityCooldown"), API.GetConvar("priaop_permission_denied", $"Nice try, you dont have permission to use this command"));
        }
    }
}
