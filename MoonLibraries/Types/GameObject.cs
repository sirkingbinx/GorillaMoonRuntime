using Lua;

namespace GorillaMoonRuntime.MoonLibraries.Types
{
    [LuaObject("GameObject")]
    public partial class GameObject
    {
#region Fields
        [LuaMember("Position")]
        public LuaVector3 Position;
        // more stuff later
#endregion Fields
        #region Constructors
        [LuaMember("new")]
        public static GameObject Lnew() =>
            new GameObject();
#endregion
    }
}