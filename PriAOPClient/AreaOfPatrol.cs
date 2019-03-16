using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Inspired by FAXES converted by Dex's Lab
/// </summary>
namespace PriAOPClient
{
    internal class AreaOfPatrol
    {

        internal AreaOfPatrol()
        {

        }

        internal void Tick()
        {
            DrawTextAOP(0.674f, 1.358f, 1.0f, 1.0f, 0.55f, "AOP: ", 255, 255, 255, 255);
            DrawTextAOP(0.699f, 1.358f, 1.0f, 1.0f, 0.55f, API.GetConvar("current_aop",API.GetConvar("default_aop","Sandy Shores")), 30, 144, 255, 255);
        }

        void DrawTextAOP(float x, float y, float width, float height, float scale, string text, int r, int g, int b, int a)
        {
            API.SetTextFont(4);
            API.SetTextProportional(true);
            API.SetTextScale(scale, scale);
            API.SetTextColour(r, g, b, a);
            API.SetTextDropShadow();
            API.SetTextEdge(2, 0, 0, 0, 255);
            API.SetTextDropShadow();
            API.SetTextOutline();
            API.SetTextEntry("STRING");
            API.AddTextComponentString(text);
            API.DrawText(x - width / 2, (float)(y - height / 2 + 0.005));
        }

    }
}
