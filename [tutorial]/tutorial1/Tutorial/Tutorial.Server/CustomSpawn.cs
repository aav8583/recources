using System;
using System.Collections.Generic;
using CitizenFX.Core;

namespace Tutorial.Server
{
    public class CustomSpawn : BaseScript
    {
        // public CustomSpawn()
        // {
        //     EventHandlers["playerConnecting"] += new Action<Player, string, CallbackDelegate, IDictionary<string, object>>(OnPlayerConnecting);
        //     EventHandlers["someName"] += new Action<Player>(onPlayerSpawned);
        // }
        //
        // private void OnPlayerConnecting([FromSource] Player player, string playerName, CallbackDelegate kickCallback, IDictionary<string, object> deferrals)
        // {
        //     // Отменить стандартный спавн
        //     TriggerClientEvent(player, "cancelAutoSpawn");
        // }
        // private void onPlayerSpawned([FromSource] Player player)
        // {
        //     float spawnX = -2461.849f; 
        //     float spawnY = 1892.905f;
        //     float spawnZ = 200.5102f;
        //     player.TriggerEvent("spawnPlayerAtCoords", spawnX, spawnY, spawnZ);
        // }
    }
    
}