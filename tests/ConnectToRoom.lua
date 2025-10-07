-- Test for GorillaMoonRuntime

function init()
    wait(10)

    -- auto-joins modded casual code "MOONTEST"
    if not Networking.InRoom then
        Networking.TryConnectToRoom("MOONTEST", "MODDED_CASUAL")
    end
end