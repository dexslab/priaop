using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriAOPClient
{
    public interface IPriAOPInterface
    {
        void RegisterEventHandler(string name,Delegate action);
        Player LocalPlayer { get; }
    }

    public class PriAOPClient : BaseScript, IPriAOPInterface
    {
        AreaOfPatrol aop;
        PriorityCooldown pc;

        Player IPriAOPInterface.LocalPlayer => LocalPlayer;

        public PriAOPClient()
        {
            aop = new AreaOfPatrol();
            pc = new PriorityCooldown(this);
            Tick += PriAOPClient_Tick;
        }

        private async Task PriAOPClient_Tick()
        {
            aop.Tick();
            pc.Tick();
        }

        public void RegisterEventHandler(string name, Delegate action)
        {
            EventHandlers.Add(name, action);
        }

        
    }
}
