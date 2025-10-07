using GorillaNetworking;
using Lua;
using Photon.Pun;

namespace GorillaMoonRuntime.MoonLibraries
{
    [LuaObject]
    public partial class Networking
    {
        [LuaMember("IsConnected")]
        public static bool IsConnected
        {
            get => PhotonNetwork.InRoom;
        }

        [LuaMember("RoomCode")]
        public static string RoomCode
        {
            get => PhotonNetwork.CurrentRoom.Name;
        }

        [LuaMember("PlayerCount")]
        public static int PlayerCount
        {
            get => IsConnected ? PhotonNetwork.CurrentRoom.PlayerCount : -1;
        }

        [LuaMember("IsModded")]
        public static bool IsModded
        {
            get => NetworkSystem.Instance.GameModeString.Contains("MODDED_");
        }

        [LuaMember("Gamemode")]
        public static string Gamemode
        {
            get => NetworkSystem.Instance.GameModeString;
        }

        [LuaMember("TryConnectToRoom")]
        public static void TryConnectToRoom(string roomCode, string gamemode)
        {
            if (IsConnected)
                NetworkSystem.Instance.ReturnToSinglePlayer();

            GorillaComputer.instance.SetGameModeWithoutButton(gamemode);
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(roomCode, JoinType.Solo);
        }

        [LuaMember("TryConnectToPublic")]
        public static void TryConnectToPublic(string gamemode)
        {
            if (IsConnected)
                NetworkSystem.Instance.ReturnToSinglePlayer();

            GorillaComputer.instance.SetGameModeWithoutButton(gamemode);
            PhotonNetworkController.Instance.AttemptToJoinPublicRoom(PhotonNetworkController.Instance.currentJoinTrigger, JoinType.Solo);
        }

        [LuaMember("Disconnect")]
        public static void Disconnect() => NetworkSystem.Instance.ReturnToSinglePlayer();
    }
}
