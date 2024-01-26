using System;
using System.Collections.Generic;
using System.Linq;
using CitizenFX.Core;
using Microsoft.EntityFrameworkCore;
using static CitizenFX.Core.Native.API;

namespace Tutorial.Server
{
    public class Server : BaseScript
    {
        public Server()
        {
            EventHandlers["printWord"] += new Action<float, float, float>(onPrintWord);
            EventHandlers["printWord1"] += new Action<int>(onPrintWord1);
            EventHandlers["printAllEvents1"] += new Action(onPrintAllEvents);
        }

        private void onPrintAllEvents()
        {
            float spawnX = -2603.934f; 
            float spawnY = 1861.909f;
            float spawnZ = 167.3199f;
            List<float> coords = new List<float> { spawnX, spawnY, spawnZ };
            Debug.WriteLine("call testClientEvent");
            TriggerClientEvent("resurrectPlayer", coords);
            Debug.WriteLine("call testClientEvent done");
        }
        
        // NetworkResurrectLocalPlayer(-2603.934, 1861.909, 167.3199, true, true, false)
        // ClearPedTasks(ped)

        
        
        // private void onPrintWord(float x, float y, float z)
        private void onPrintWord(float x, float y, float z)
        {
            using (var context = new MyDbContext())
            {
                int userId = 9;
                var user = context.Users
                    .Include(u => u.UserCustomization)
                    .FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    Debug.WriteLine(user.ToString());
                }
                else
                {
                    Debug.WriteLine("user doesn't exist");
                }
            }
            
            Vector3 coords = new Vector3(x, y, z);
            Debug.WriteLine("JUST WORD IN CONSOLE BEFORE");
            Debug.WriteLine($"{coords.ToString()}");
            // Debug.WriteLine($"{player.Name}");
            Debug.WriteLine("JUST WORD IN CONSOLE");
        }

        private void onPrintWord1(int playerId)
        {
            Player player = Players[playerId];
            if (player != null)
            {
                Debug.WriteLine("JUST WORD IN CONSOLE BEFORE");
                Debug.WriteLine($"Player Name: {player.Name}");
                Debug.WriteLine("JUST WORD IN CONSOLE");
            }
            else
            {
                Debug.WriteLine($"Player with ID {playerId} not found.");
            }
        }
    }
}