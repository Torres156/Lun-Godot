using Godot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Models
{
    internal class SettingsModel
    {
        public Vector2 WindowSize       { get; set; } = new Vector2(800, 600); 
        public bool    WindowMaximize   { get; set; } = false;
        public bool    WindowFullscreen { get; set; } = false;

        [JsonIgnore]
        public string WindowTitle { get; set; } = "Lun Godot Engine";
    }
}
