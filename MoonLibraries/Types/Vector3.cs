using Lua;

namespace GorillaMoonRuntime.MoonLibraries.Types
{
    [LuaObject]
    public partial class LuaVector3
    {
#region Fields
        [LuaMember("X")]
        public float X;

        [LuaMember("Y")]
        public float Y;

        [LuaMember("Z")]
        public float Z;
#endregion Fields
#region Constructors
        [LuaMember("new")]
        public static LuaVector3 Lnew(float _X, float _Y, float _Z)
        {
            return new LuaVector3(_X, _Y, _Z);
        }

        public LuaVector3(float _X = 0, float _Y = 0, float _Z = 0)
        {
            this.X = _X;
            this.Y = _Y;
            this.Z = _Z;
        }
#endregion
#region Operators / Metamethods
        [LuaMetamethod(LuaObjectMetamethod.ToString)]
        public override string ToString() => $"X: {this.X}, Y: {this.Y}, Z: {this.Z}";

        [LuaMetamethod(LuaObjectMetamethod.Add)]
        public LuaVector3 Add(LuaVector3 v1, LuaVector3 v2) =>
            new LuaVector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        [LuaMetamethod(LuaObjectMetamethod.Sub)]
        public LuaVector3 Subtract(LuaVector3 v1, LuaVector3 v2) =>
            new LuaVector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

        [LuaMetamethod(LuaObjectMetamethod.Mul)]
        public LuaVector3 Multiply(LuaVector3 v1, LuaVector3 v2) =>
            new LuaVector3(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);

        [LuaMetamethod(LuaObjectMetamethod.Div)]
        public LuaVector3 Divide(LuaVector3 v1, LuaVector3 v2) =>
            new LuaVector3(v1.X / v2.X, v1.Y / v2.Y, v1.Z / v2.Z);
#endregion
    }
}