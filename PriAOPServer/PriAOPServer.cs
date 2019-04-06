using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core.Native;
using System.Timers;
using System.Globalization;

namespace PriAOPServer
{
    public static class StringHelper
    {
        public static string ToTitleCase(this string str)
        {
            var tokens = str.Split(new[] { " ", "-" }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                tokens[i] = token == token.ToUpper()
                    ? token
                    : token.Substring(0, 1).ToUpper() + token.Substring(1).ToLower();
            }

            return string.Join(" ", tokens);
        }
    }

    public class PriAOPServer : BaseScript, IPriAOP
    {

        PriorityCooldown priorityCooldown;
        AreaOfPatrol areaOfPatrol;
        public PlayerList IPlayerList => Players;
        public ExportDictionary IExports => Exports;

        public PriAOPServer()
        {
            priorityCooldown = new PriorityCooldown(this);
            areaOfPatrol = new AreaOfPatrol(this);
            priorityCooldown.RegisterCommands();
            areaOfPatrol.RegisterCommands();
            Tick += PriAOPServer_Tick;
        }

        private async Task PriAOPServer_Tick()
        {
            priorityCooldown.PriorityCooldown_Tick();
        }

        public static void SendPlayerChatMessage(Player player,string sender, string message)
        {
            dynamic stuff = new System.Dynamic.ExpandoObject();
            stuff.args = new string[] { sender, message };
            stuff.color = new int[] { 255, 255, 0 };
            player.TriggerEvent("chat:addMessage", stuff);
        }

        public static void SendChatMessage(string sender, string message)
        {
            dynamic stuff = new System.Dynamic.ExpandoObject();
            stuff.args = new string[] { sender, message };
            stuff.color = new int[] { 255, 255, 0 };
            TriggerClientEvent("chat:addMessage", stuff);
        }
    }
}
