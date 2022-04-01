using Godot;
using Lun.Scripts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Controller.MapEditor
{
	internal class TileController : Panel
	{
		Panel Select;
		TextureRect texture;
		SpinBox TileSet;

		bool isPressed = false;

		public override void _Ready()
		{
			Select = GetNode<Panel>("Select");
			texture = GetNode<TextureRect>("Texture");

			TileSet = GetNode<SpinBox>("../TileId");
			TileSet.MaxValue = ResourceService.TilesetCount;
			TileSet.Connect("value_changed", this, nameof(TileSet_ValueChanged));
			
		}

		void TileSet_ValueChanged(float value)									   
		{
			texture.Texture = ResourceService.LoadTileset((int)TileSet.Value);
			GD.Print(TileSet.Value);
		}

		public override void _GuiInput(InputEvent @event)
		{
			if (@event is InputEventMouseButton input)
			{
				if (input.IsPressed())
				{
					var clipScale = 16;
					var mousepos = (input.Position / clipScale).Floor();

					if (mousepos.x < 0 || mousepos.y < 0)
						return;

					Select.RectPosition = mousepos * clipScale;
					Select.RectSize = Vector2.One * clipScale;
					isPressed = true;
				}
				else
					isPressed = false;
			}

			if (@event is InputEventMouseMotion inputMouse)
			{
				if (isPressed)
				{
					if (inputMouse.Position.x < 256 && inputMouse.Position.y < 256)
					{
						var clipScale = 16 ;
						var mousePos = (inputMouse.Position / clipScale).Floor();
						var selectPos = (Select.RectPosition / clipScale).Floor();

						Select.RectSize = (mousePos - selectPos + Vector2.One).Max(Vector2.One) * clipScale;
					}
				}
			}

		}
	}
}
