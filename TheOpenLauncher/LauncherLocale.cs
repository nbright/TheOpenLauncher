using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TheOpenLauncher {
    //Make sure to set the build action for included locale files to "Embedded Resource"

    public class LauncherLocale {
        public static LauncherLocale Current = LoadLocale("English");

        public static LauncherLocale LoadLocale(string localeFilename) {
            string localePath = "TheOpenLauncher.Locale." + localeFilename + ".txt";
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(localePath))
            using (StreamReader reader = new StreamReader(stream)) {
                return LoadLocaleFromData(reader.ReadToEnd());
            }
        }

        public static LauncherLocale LoadLocaleFromData(string localeData) {
            Dictionary<string, string> values = new Dictionary<string,string>();
            string[] entries = localeData.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < entries.Length; i++) {
                string cur = entries[i];
                if (cur.StartsWith("#")) {
                    continue;
                }
                string[] curParts = cur.Split(':');
                string key = curParts[0];
                
                int linesRead = 0;
                string value = ParseValue(entries, i, curParts[1].Trim(), out linesRead);
                values.Add(key, value);
                i = i + linesRead;
            }
            return new LauncherLocale(values);
        }

        private static string ParseValue(string[] entries, int i, string valuePart, out int linesRead){
            linesRead = 0;
            string value;
            if(valuePart.StartsWith("[")){
                StringBuilder builder = new StringBuilder();
                string curString = valuePart.Split('[')[1];
                while(!curString.Contains(']')){
                    if(!String.IsNullOrEmpty(curString)){
                        builder.AppendLine(curString);
                    }
                    linesRead++;
                    curString = entries[i + linesRead].Trim();
                }
                builder.AppendLine(curString.Split(']')[0]);
                value = builder.ToString();
            } else {
                value = valuePart;
            }

            value = value.Replace(@"\n", Environment.NewLine);
            value = value.Replace(@"\t", "\t");
            return value;
        }

        private Dictionary<string, string> values;
        public LauncherLocale(Dictionary<string, string> values) {
            this.values = values;
        }

        public string FillVariableTemplate(string template) {
            template = template.Replace("${applicationName}", LauncherSettings.ApplicationName);
            template = template.Replace("${companyName}", LauncherSettings.CompanyName);
            template = template.Replace("${helpURL}", LauncherSettings.HelpURL);
            template = template.Replace("${infoURL}", LauncherSettings.InfoURL);
            template = template.Replace("${updateInfoURL}", LauncherSettings.UpdateInfoURL);
            return template;
        }

        public string Get(string key) {
            string result;
            if (!values.TryGetValue(key, out result)) {
                MessageBox.Show("Missing locale value for "+key, "Missing locale value");
                return null;
            }
            return FillVariableTemplate(result);
        }
    }
}
