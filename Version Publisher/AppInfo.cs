using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheOpenLauncher
{
    public class AppInfo
    {
        public string appId;
        public string downloadBaseDir;
        public double[] versions;

        public double LatestVersion
        {
            get
            {
                double result = 0;
                foreach(double cur in versions){
                    if(cur > result){
                        result = cur;
                    }
                }
                return result;
            }
        }

        public static AppInfo FromJson(string p) {
            try {
                AppInfo info = JsonConvert.DeserializeObject<AppInfo>(p);
                return info;
            } catch (JsonReaderException) { }
            return null;
        }

        public string ToJson() {
            try {
                return JsonConvert.SerializeObject(this);
            } catch (JsonReaderException) { }
            return null;
        }
    }
}
