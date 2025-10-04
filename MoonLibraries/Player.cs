using Lua;
using GorillaNetworking;
using Photon.Pun;
namespace GorillaMoonRuntime.MoonLibraries
{
    [LuaObject]
    public partial class Player
    {
        [LuaMember("Platform")]
        public static string Platform
        {
            get
            {
                string currentTag = PlayFabAuthenticator.instance.platform.PlatformTag.ToLower();

                if (currentTag.Contains("steam"))
                    return "steam";
                else if (currentTag.Contains("pc"))
                    return "rift";
                else
                    return "quest";
            }
        }

        [LuaMember("Nickname")]
        public static string Nickname
        {
            get => GorillaComputer.instance.currentName;
        }

        [LuaMember("PlayerId")]
        public static string PlayerId
        {
            get => PlayFabAuthenticator.instance.GetPlayFabPlayerId();
        }
    }
}
