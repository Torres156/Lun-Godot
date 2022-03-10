using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Models.Components
{
    [Tool]
    internal class WindowManager : Control
    {
        public override void _Ready()
        {
            this.RectPosition = Vector2.Zero;
            base._Ready();
        }

        public override string _GetConfigurationWarning()
        {
            var childs = GetChildren().Cast<Node>();

            if (!childs.Any(i => i is WindowComponent))
                return "Require WindowComponent child!";

            return "";
        }

        public void SetWindowFocus(WindowComponent window)
        {
            this.MoveChild(window, this.GetChildCount() - 1);
        }
    }
}
