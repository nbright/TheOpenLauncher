using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TheOpenLauncher {
    [Serializable]
    public class UpdateInfo : ISerializable {
        public Dictionary<string, string> fileChecksums;
        public double version;
        public long releaseDate;
        public string summary;
        public string changeLog;

        public DateTime ReleaseDate {
            get {
                return DateTools.DateTimeFromUnixTimestampSeconds(releaseDate);
            }
            set {
                releaseDate = DateTools.GetUnixTimestampSeconds(value);
            }
        }

        #region Serialization
        public UpdateInfo() { }

        public UpdateInfo(SerializationInfo info, StreamingContext context) {
            fileChecksums = (Dictionary<string, string>)info.GetValue("fileChecksums", typeof(Dictionary<string, string>));
            version = info.GetDouble("version");
            releaseDate = info.GetInt64("releaseDate");
            summary = info.GetString("summary");
            changeLog = info.GetString("changeLog");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("fileChecksums", fileChecksums);
            info.AddValue("version", version);
            info.AddValue("releaseDate", releaseDate);
            info.AddValue("summary", summary);
            info.AddValue("changeLog", changeLog);
        }

        public static UpdateInfo FromJson(string json) {
            try {
                UpdateInfo info = JsonConvert.DeserializeObject<UpdateInfo>(json, new KeyValuePairConverter());
                return info;
            } catch (JsonReaderException) { }
            return null;
        }

        public string ToJson() {
            try {
                return JsonConvert.SerializeObject(this, new KeyValuePairConverter());
            } catch (JsonReaderException) { }
            return null;
        }

        public override string ToString() {
            return ToJson();
        }
        #endregion
    }
}
