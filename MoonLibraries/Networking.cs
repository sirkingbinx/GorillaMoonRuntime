using GorillaNetworking;
using Lua;
using Photon.Pun;

namespace GorillaMoonRuntime.MoonLibraries
{
    [LuaObject]
    public partial class Networking
    {
        [LuaMember("IsConnected")]
        public static bool IsConnectedToRoom
        {
            get => PhotonNetwork.InLobby;
        }

        [LuaMember("RoomCode")]
        public static string RoomCode
        {
            get => PhotonNetwork.CurrentRoom.Name;
        }

        [LuaMember("PlayerCount")]
        public static int PlayerCount
        {
            get => IsConnectedToRoom ? PhotonNetwork.CurrentRoom.PlayerCount : -1;
        }

        [LuaMember("IsModded")]
        public static bool IsModded
        {
            get => NetworkSystem.Instance.GameModeString.Contains("MODDED_");
        }

        [LuaMember("TryConnectToRoom")]
        public static void TryConnectToRoom(string roomCode, string gamemode)
        {
            if (IsConnectedToRoom)
                PhotonNetwork.Disconnect();

            GorillaComputer.instance.SetGameModeWithoutButton(gamemode);
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(roomCode, JoinType.Solo);
        }

        [LuaMember("TryConnectToPublic")]
        public static void TryConnectToPublic(string gamemode)
        {
            if (IsConnectedToRoom)
                PhotonNetwork.Disconnect();

            GorillaComputer.instance.SetGameModeWithoutButton(gamemode);
            PhotonNetworkController.Instance.AttemptToJoinPublicRoom(PhotonNetworkController.Instance.currentJoinTrigger, JoinType.Solo);
        }
    }
}
