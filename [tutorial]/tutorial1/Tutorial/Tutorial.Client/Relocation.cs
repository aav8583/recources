using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;


namespace Tutorial.Client
{
    public class Relocation : BaseScript
    {
        public Relocation()
        {
            Tick += OnTick;
            EventHandlers["playerSpawned"] += new Action<Vector3>(playerSpawned);
            EventHandlers["testClientEvent"] += new Action<List<float>>(respawn);
        }
        
        private async Task OnTick()
        {
            await Task.Delay(100);
        }

        private void respawn(List<float> coords)
        {
            var playerPedId = API.GetPlayerPed(-1);
            if (API.IsPedDeadOrDying(playerPedId, true))
            {
                API.NetworkResurrectLocalPlayer(coords[0], coords[1], coords[2], 0.0f, true, false);
                API.ClearPedTasksImmediately(playerPedId);
                API.SetEntityHealth(playerPedId, 200);
            }
        }

        private void playerSpawned([FromSource] Vector3 spawn)
        {
            float spawnX = -2603.934f; 
            float spawnY = 1861.909f;
            float spawnZ = 167.3199f;
            Game.PlayerPed.Position = new Vector3(spawnX, spawnY, spawnZ);
            Game.PlayerPed.Weapons.Give(WeaponHash.Pistol, 100, false, true);
        }
        
        
    }
}