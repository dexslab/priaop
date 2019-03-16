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
                API.SetConvarReplicated("priority_cooldown", $"Peace time has ended");
            }
            else if (elasped.TotalSeconds < currentPC * 60 && pcStarted && inPC)
            {
                API.SetConvarReplicated("priority_cooldown", $"Priority Cooldown: {elasped.Subtract(TimeSpan.FromMinutes(currentPC)).ToString(@"mm\:ss")} until the next priority can begin");
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

            if (await iPriAOP.CheckPerms(p))
            {
                inPC = false;
                pcStarted = false;
                API.SetConvarReplicated("priority_status", "finished");
                API.SetConvarReplicated("priority_cooldown", $"Peace time has ended");
            }
            else
            {
                dynamic stuff = new System.Dynamic.ExpandoObject();
                stuff.args = new string[] { "^1PriorityCooldown", $"Nice try, you dont have permission to use this command" };
                stuff.color = new int[] { 255, 255, 0 };
                iPriAOP.IPlayerList[p].TriggerEvent("chat:addMessage", stuff);
                return;
            }
        }

        private async void BypassPC(int p, List<object> args, string raw)
        {
            
        }

        private async void ActivatePC(int p, List<object> args, string raw)
        {
            
            if (await iPriAOP.CheckPerms(p))
            {
                if (args.Count != 1)
                {
                    dynamic stuff = new System.Dynamic.ExpandoObject();
                    stuff.args = new string[] { "^1PriorityCooldown", $"You must specify a time when using this command" };
                    stuff.color = new int[] { 255, 255, 0 };
                    iPriAOP.IPlayerList[p].TriggerEvent("chat:addMessage", stuff);
                    return;
                }
                if (!int.TryParse(args[0].ToString(), out currentPC))
                {
                    dynamic stuff = new System.Dynamic.ExpandoObject();
                    stuff.args = new string[] { "^1PriorityCooldown", $"You must specify a number when using this command" };
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
                dynamic stuff = new System.Dynamic.ExpandoObject();
                stuff.args = new string[] { "^1PriorityCooldown", $"Nice try, you dont have permission to use this command" };
                stuff.color = new int[] { 255, 255, 0 };
                iPriAOP.IPlayerList[p].TriggerEvent("chat:addMessage", stuff);
                return;
            }
        }

        private async void PCInProgress(int p, List<object> args, string raw)
        {
            
            if (await iPriAOP.CheckPerms(p))
            {
                API.SetConvarReplicated("priority_cooldown", $"Priority in Progress");
                API.SetConvarReplicated("priority_status", "inprogress");
                pcStarted = false;
                inPC = false;
            }
            else
            {
                dynamic stuff = new System.Dynamic.ExpandoObject();
                stuff.args = new string[] { "^1PriorityCooldown", $"Nice try, you dont have permission to use this command" };
                stuff.color = new int[] { 255, 255, 0 };
                iPriAOP.IPlayerList[p].TriggerEvent("chat:addMessage", stuff);
                return;
            }
        }



        private async void PCOnHold(int p, List<object> args, string raw)
        {
            
            if (await iPriAOP.CheckPerms(p))
            {
                API.SetConvarReplicated("priority_cooldown", $"All priorities are on hold");
                API.SetConvarReplicated("priority_status", "onhold");
                inPC = false;
                pcStarted = false;
            }
            else
            {
                dynamic stuff = new System.Dynamic.ExpandoObject();
                stuff.args = new string[] { "^1PriorityCooldown", $"Nice try, you dont have permission to use this command" };
                stuff.color = new int[] { 255, 255, 0 };
                iPriAOP.IPlayerList[p].TriggerEvent("chat:addMessage", stuff);
                return;
            }
        }
    }
}
