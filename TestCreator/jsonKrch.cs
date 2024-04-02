using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestCreator;
using System.Threading.Tasks;

namespace TestCreator
{
    internal class jsonKrch
    {
        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Questinons";
        public static void Seril<T>(List<T> data, string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Questions";
            string fullpath = Path.Combine(path, fileName);
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(fullpath, json);
        }
        public static List<T> Deseril<T>(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Questions";
            string fullpath = Path.Combine(path, fileName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(fullpath))
            {
                string jsonContent = "[]";
                File.WriteAllText(fullpath, jsonContent);
            }
            string json = File.ReadAllText(fullpath);
            List<T> data = JsonConvert.DeserializeObject<List<T>>(json);
            return data;
        }

    }
}
