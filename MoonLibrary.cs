using Lua;
using System;
using UnityEngine;
using System.Threading.Tasks;
using GorillaMoonRuntime.MoonLibraries;

namespace GorillaMoonRuntime
{
    public class MoonLibrary
    {
        public static void OpenMoonLibrary(LuaState luaState)
        {
            #region Logging
            luaState.Environment["print"] = new LuaFunction((context, buffer, ct) =>
            {
                var message = context.GetArgument<string>(0);

                if (message != null)
                    Debug.Log(message);
                else
                    Debug.LogAssertion("expected message in print");

                return new ValueTask<int>(0);
            });

            luaState.Environment["warn"] = new LuaFunction((context, buffer, ct) =>
            {
                var message = context.GetArgument<string>(0);

                if (message != null)
                    Debug.LogWarning(message);
                else
                    Debug.LogAssertion("expected message in warn");

                return new ValueTask<int>(0);
            });

            luaState.Environment["error"] = new LuaFunction((context, buffer, ct) =>
            {
                var message = context.GetArgument<string>(0);

                if (message != null)
                    Debug.LogError(message);
                else
                    Debug.LogAssertion("expected message in error");

                return new ValueTask<int>(0);
            });
            #endregion
            #region Threading
            luaState.Environment["wait"] = new LuaFunction(async (context, buffer, ct) =>
            {
                var sec = context.GetArgument<double>(0);
                await Task.Delay(TimeSpan.FromSeconds(sec));
                return 0;
            });
            #endregion
            #region Libraries
            luaState.Environment["Networking"] = new Networking();
            luaState.Environment["Player"] = new Player();
            #endregion
        }
    }
}
