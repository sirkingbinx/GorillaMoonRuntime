using BepInEx;
using GorillaMoonRuntime;
using Lua;
using Lua.Standard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

namespace BingusDebugger
{
    [BepInPlugin("bingus.gorillamoonruntime", "GorillaMoonRuntime", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance { get; private set; }

        string ScriptsDirectory = Path.Combine(AssemblyDirectory, "Scripts");

        public Action scriptsUpdate = delegate { };
        public Action scriptsInit = delegate { };

        public Dictionary<string, LuaState> loadedScripts = new Dictionary<string, LuaState>();

        public void Start()
        {
            Debug.Log("Initiailizing GorillaMoonRuntime");

            instance = this;

            if (!Directory.Exists(ScriptsDirectory))
                Directory.CreateDirectory(ScriptsDirectory);

            GorillaTagger.OnPlayerSpawned(scriptsInit);

            Debug.Log("STARTING SCRIPT LOADING");
        }

        public void Update() => scriptsUpdate();

        public void LoadScript(string file)
        {
            Debug.Log($"Loading script: {file}");
            LuaState thisLuaState = LuaState.Create();

            // open lib stuff
            thisLuaState.OpenStandardLibraries(); // lua std
            MoonLibrary.OpenMoonLibrary(thisLuaState); // print, warn, error, other stuff

            Debug.Log($"Loading script: {file}");
            thisLuaState.DoFileAsync(file).AsTask().ContinueWith(t =>
            {
                if (t.IsFaulted)
                    Debug.LogError($"Error loading script {file}: {t.Exception}");
                else
                    Debug.Log($"Successfully loaded script: {file}");

                if (thisLuaState.Environment["init"] != LuaValue.Nil && thisLuaState.Environment["init"].Type == LuaValueType.Function)
                {
                    Debug.Log("found init");
                    // soon
                }

                if (thisLuaState.Environment["step"] != LuaValue.Nil && thisLuaState.Environment["step"].Type == LuaValueType.Function)
                {
                    Debug.Log("found step");
                    // soon
                }
            });
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
