using Lua;

namespace GorillaMoonRuntime.MoonLibraries.Types
{
    [LuaObject]
    public partial class LuaVector2
    {
#region Fields
        [LuaMember("X")]
        public float X;

        [LuaMember("Y")]
        public float Y;
#endregion Fields
#region Constructors
        [LuaMember("new")]
        public static LuaVector2 Lnew(float _X, float _Y)
        {
            return new LuaVector2(_X, _Y);
        }

        public LuaVector2(float _X = 0, float _Y = 0)
        {
            this.X = _X;
            this.Y = _Y;
        }
#endregion
#region Operators / Metamethods
        [LuaMetamethod(LuaObjectMetamethod.ToString)]
        public override string ToString() => $"X: {X}, Y: {Y}";

        [LuaMetamethod(LuaObjectMetamethod.Add)]
        public LuaVector2 Add(LuaVector2 v1, LuaVector2 v2) =>
            new LuaVector2(v1.X + v2.X, v1.Y + v2.Y);

        [LuaMetamethod(LuaObjectMetamethod.Sub)]
        public LuaVector2 Subtract(LuaVector2 v1, LuaVector2 v2) =>
            new LuaVector2(v1.X - v2.X, v1.Y - v2.Y);

        [LuaMetamethod(LuaObjectMetamethod.Mul)]
        public LuaVector2 Multiply(LuaVector2 v1, LuaVector2 v2) =>
            new LuaVector2(v1.X * v2.X, v1.Y * v2.Y);

        [LuaMetamethod(LuaObjectMetamethod.Div)]
        public LuaVector2 Divide(LuaVector2 v1, LuaVector2 v2) =>
            new LuaVector2(v1.X / v2.X, v1.Y / v2.Y);
#endregion
    }
}