RegisterNetEvent('cancelAutoSpawn')
AddEventHandler('cancelAutoSpawn', function()
    -- Отменяет стандартный спавн
    exports.spawnmanager:setAutoSpawn(false)
    exports.spawnmanager:forceRespawn()
end)

RegisterNetEvent('spawnPlayerAtCoords')
AddEventHandler('spawnPlayerAtCoords', function(x, y, z)
    -- Устанавливает координаты спавна
    exports.spawnmanager:spawnPlayer({
        x = x,
        y = y,
        z = z,
        model = 'a_m_m_skater_01'
    }, function()
        -- Код, который будет выполнен после спавна
    end)
end)