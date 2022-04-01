using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Services
{
	internal static class ExtendService
	{
		public static Godot.Vector2 Max(this Godot.Vector2 obj, Godot.Vector2 value)
			=> new Godot.Vector2((float)Math.Max(obj.x, value.x), (float)Math.Max(obj.y, value.y));

		public static Godot.Vector2 ToGodotVector2(this Shared.Models.Vector2 obj)
			=> new Godot.Vector2(obj.x, obj.y);

		public static Shared.Models.Vector2 ToLunVector2(this Godot.Vector2 obj)
			=> new Shared.Models.Vector2(obj.x, obj.y);

		public static float Round(this float obj)
			=> (float)Math.Round(obj, 2);
	}
}
