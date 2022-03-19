using Lun.Shared.Models;
using Lun.Shared.Models.Player;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Server.Services
{
    internal class ClassService
    {
        public static List<ClassModel> Classes;

        public static void Initialize()
        {
            WriteLine("Inicializa as classes!");

            var directory = "classes/";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            Classes = new List<ClassModel>();
            if (Directory.GetFiles(directory).Length > 0)
            {
                int i = 1;
                while(File.Exists(directory + $"{i}.json"))
                {
                    var classObj = JsonConvert.DeserializeObject<ClassModel>(File.ReadAllText(directory + $"{i}.json"));
                    Classes.Add(classObj);
                    i++;
                }
            }
            else
            {
                var warrior = new ClassModel();
                warrior.Name         = "Guerreiro";
                warrior.MaleSprite   = new[] { 1 };
                warrior.FemaleSprite = new[] { 4 };
                File.WriteAllText(directory + "1.json", JsonConvert.SerializeObject(warrior, Formatting.Indented));

                var mage = new ClassModel();
                mage.Name = "Mago";
                mage.MaleSprite = new[] { 2 };
                mage.FemaleSprite = new[] { 3 };
                File.WriteAllText(directory + "2.json", JsonConvert.SerializeObject(mage, Formatting.Indented));

                Classes.Add(warrior);
                Classes.Add(mage);
            }


        }
    }
}
