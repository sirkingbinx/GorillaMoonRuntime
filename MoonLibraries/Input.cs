using UnityEngine;
using Lua;

using GorillaMoonRuntime.MoonLibraries.Types;
namespace GorillaMoonRuntime.MoonLibraries
{
    [LuaObject]
    public partial class Input
    {
        [LuaMember("LeftPrimary")]
        public static bool LeftPrimary
        {
            get => ControllerInputPoller.instance.leftControllerPrimaryButton;
        }

        [LuaMember("LeftSecondary")]
        public static bool LeftSecondary
        {
            get => ControllerInputPoller.instance.leftControllerSecondaryButton;
        }

        [LuaMember("LeftTrigger")]
        public static float LeftTrigger
        {
            get => ControllerInputPoller.instance.leftControllerIndexFloat;
        }

        [LuaMember("LeftGrip")]
        public static float LeftGrip
        {
            get => ControllerInputPoller.instance.leftControllerGripFloat;
        }

        [LuaMember("LeftThumbstickAxis")]
        public static float LeftThumbstickAxis
        {
            get
            {
                Vector2 JoystickAxis = Vector2.zero;

                if (Player.Platform == "steam")
                    JoystickAxis = SteamVR_Actions.gorillaTag_LeftJoystick2DAxis.axis;
                else
                    JoystickAxis = ControllerInputPoller.Primary2DAxis(XRNode.LeftHand);

                return new LuaVector2(JoystickAxis.x, JoystickAxis.y);
            }
        }

        [LuaMember("RightPrimary")]
        public static bool RightPrimary
        {
            get => ControllerInputPoller.instance.rightControllerPrimaryButton;
        }

        [LuaMember("RightSecondary")]
        public static bool RightSecondary
        {
            get => ControllerInputPoller.instance.rightControllerSecondaryButton;
        }

        [LuaMember("RightTrigger")]
        public static float RightTrigger
        {
            get => ControllerInputPoller.instance.rightControllerIndexFloat;
        }

        [LuaMember("RightGrip")]
        public static float RightGrip
        {
            get => ControllerInputPoller.instance.rightControllerGripFloat;
        }

        [LuaMember("RightThumbstickAxis")]
        public static float RightThumbstickAxis
        {
            get
            {
                Vector2 JoystickAxis = Vector2.zero;

                if (Player.Platform == "steam")
                    JoystickAxis = SteamVR_Actions.gorillaTag_RightJoystick2DAxis.axis;
                else
                    JoystickAxis = ControllerInputPoller.Primary2DAxis(XRNode.RightHand);

                return new LuaVector2(JoystickAxis.x, JoystickAxis.y);
            }
        }
    }
}
