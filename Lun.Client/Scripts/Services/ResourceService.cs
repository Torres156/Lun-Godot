using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Services
{
	internal class ResourceService
	{
		public static int TilesetCount { get; private set; } = 0;

		public static void Initialize()
		{
			while(ResourceLoader.Exists($"res://Textures/Tileset/{TilesetCount + 1}.png"))
			{
				TilesetCount++;
			}
		}

		public static Texture LoadTileset(int tileNum)
			=> ResourceLoader.Load<Texture>($"res://Textures/Tileset/{tileNum}.png");

	}
}
