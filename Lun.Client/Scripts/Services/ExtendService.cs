using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Services
{
	internal static class ExtendService
	{
		public static Godot.Vector2 ToGodotVector2(this Shared.Models.Vector2 obj)
			=> new Godot.Vector2(obj.x, obj.y);
	}
}
