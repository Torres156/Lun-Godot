using Godot;
using Lun.Scripts.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Lun.Scripts.Services
{
    using File = System.IO.File;
    using Directory = System.IO.Directory;

    internal static class GlobalService
    {
        public const string LunVersion = "0.1";

        public static SettingsModel Settings { get; set; }

        public static void InitializeSettings()
        {
            Settings = new SettingsModel();

            Load();
        }

        static void Load()
        {
            string path = "data/";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                SaveSettings();
                return;
            }

            if (!File.Exists(path + "settings.json"))
            {
                SaveSettings();
                return;
            }

            var json = File.ReadAllText(path + "settings.json");
            Settings = JsonConvert.DeserializeObject<SettingsModel>(json);
        }

        public static void SaveSettings()
        {
            string path = "data/";

            var json = JsonConvert.SerializeObject(Settings);
            File.WriteAllText(path + "settings.json", json);
        }

        public static SceneTree GetTree
           => Engine.GetMainLoop() as SceneTree;

        public static Node CurrentScene
            => GetTree.CurrentScene;

        public static long TickCount
            => (long)OS.GetSystemTimeMsecs();
    }
}
