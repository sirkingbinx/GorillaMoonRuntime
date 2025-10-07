-- Test for GorillaMoonRuntime

local controllerValues = {
    {"left.primary", Input.LeftPrimary},
    {"left.secondary", Input.LeftSecondary},
    {"left.trigger(float)", Input.LeftTrigger},
    {"left.grip(float)", Input.LeftGrip},
    {"left.thumbstickAxis", Input.LeftThumbstickAxis},
    {"left.thumbstickAxis", Input.LeftThumbstickAxis},

    {"right.primary", Input.RightPrimary},
    {"right.secondary", Input.RightSecondary},
    {"right.trigger(float)", Input.RightTrigger},
    {"right.grip(float)", Input.RightGrip},
    {"right.thumbstickAxis", Input.RightThumbstickAxis},
    {"right.thumbstickAxis", Input.RightThumbstickAxis},
}

function init()
    for idx, cvalueTbl in pairs(controllerValues) do
        print(cvalueTbl[1] .. ": " .. tostring(cvalueTbl[2]))
    end
end