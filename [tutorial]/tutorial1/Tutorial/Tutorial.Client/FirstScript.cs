

using System;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace Tutorial.Client
{
    public class FirstScript : BaseScript
    {
        public FirstScript()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }
        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            RegisterCommand("coord", new Action<int, List<object>, string>((source, args, raw) =>
            {
                Vector3 secondVar = Game.PlayerPed.Position;
                TriggerServerEvent("printWord", secondVar.X, secondVar.Y, secondVar.Z);
            }), false);
            
            RegisterCommand("coord1", new Action<int, List<object>, string>((source, args, raw) =>
            {
                var playerID = GetPlayerServerId(Game.Player.ServerId);
                TriggerServerEvent("printWord1", playerID);
            }), false);

            RegisterCommand("car", new Action<int, List<object>, string>((source, args, raw) =>
            {
                TriggerEvent("chat:addMessage", new
                {
                    color = new[] {255, 0, 0},
                    args = new[] {"[CarSpawner]", $"I wish I could spawn this {(args.Count > 0 ? $"{args[0]} or" : "")} adder but my owner was too lazy. :("}
                });
            }), false);
        }
    }
}