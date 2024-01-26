AddEventHandler('onClientMapStart', function()
  exports.spawnmanager:setAutoSpawn(false)
end)

local isDead = false

Citizen.CreateThread(function()
    while true do
        Wait(500)
        local ped = GetPlayerPed(-1)
        if IsEntityDead(ped) and not isDead then
            isDead = true
            TriggerServerEvent("printAllEvents1")  -- Событие для воскрешения на сервере
        elseif not IsEntityDead(ped) then
            isDead = false
        end
    end
end)

RegisterNetEvent('resurrectPlayer')
AddEventHandler('resurrectPlayer', function(coords)
    local playerPed = GetPlayerPed(-1)
    if IsPedDeadOrDying(playerPed, true) then
        local x, y, z = table.unpack(coords)
        NetworkResurrectLocalPlayer(x, y, z, true, true, false)
        SetEntityHealth(playerPed, 200) -- Можете установить здоровье, которое вам нужно
        ClearPedTasksImmediately(playerPed)
    end
end)
