using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TheOpenLauncher.VersionPublisher {
    [Serializable]
    class Settings : ISerializable {
        #region Statics
        private static Settings instance = null;
        public static Settings Instance{
            get {
                if(instance == null){
                    instance = LoadSettingsFile(GetSettingsFile());
                }
                return instance;
            }
        }

        private static string GetSettingsFile() {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string applicationFolder = Path.Combine(appdata, "VersionPublisher");
            return Path.Combine(applicationFolder, "config.dat");
        }

        private static Settings LoadSettingsFile(string file) {
            if(!File.Exists(file)){
                Settings newSettings = new Settings();
                newSettings.SettingsFile = file;
                newSettings.Save();
                return newSettings;
            }
            Stream stream = File.Open(file, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            Settings settings = (Settings)bformatter.Deserialize(stream);
            stream.Close();
            settings.SettingsFile = file;
            return settings;
        }
        #endregion

        #region Serialization
        private Settings() {
            SetDefaultValues();
        }
        public string SettingsFile { get; private set; }
        public void Save() {
            if(!Directory.GetParent(this.SettingsFile).Exists){
                Directory.GetParent(this.SettingsFile).Create();
            }
            Stream stream = File.Open(SettingsFile, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, this);
            stream.Close();
        }
        #endregion

        public List<Project> Projects { get; set; }

        private void SetDefaultValues() {
            Projects = new List<Project>();
        }

        private Settings(SerializationInfo info, StreamingContext ctxt) {
            Projects = (List<Project>)info.GetValue("Projects", typeof(List<Project>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("Projects", Projects);
        }
    }
}
