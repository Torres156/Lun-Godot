using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Controller
{
	internal class MusicController : AudioStreamPlayer
	{
		public static MusicController Instance { get; private set; }

		public override void _Ready()
		{
			Instance = this;
		}

		public static void Play(string file)
		{
			var path = "res://Audio/Music/" + file;

			if (!ResourceLoader.Exists(path))
				return;

			if (!Settings.Music)
				return;

			Instance.Stream = ResourceLoader.Load<AudioStreamMP3>(path);
			Instance.Play();
		}
	}
}
