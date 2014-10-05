using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TheOpenLauncher
{
    class FileIndex
    {
        public List<string> files = new List<string>();
        public string appID;
        public double applicationVersion = 0.0d;

        public FileIndex(string appID)
        {
            this.appID = appID;
        }

        public void Serialize(string file)
        {
            File.WriteAllText(file, JsonConvert.SerializeObject(this));
        }

        public static FileIndex Deserialize(string file)
        {
            FileIndex info = JsonConvert.DeserializeObject<FileIndex>(File.ReadAllText(file));
            return info;
        }
    }
}
