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
        private static string localeFolderPrefix = "TheOpenLauncher.Locale.";
        private static LauncherLocale current = null;
        private static string[] availableLocales = null;
        public static LauncherLocale Current {
            get {
                if(current == null){
                    current = LoadLocale("English");
                }
                return current;
            }
            set {
                current = value;
            }
        }

        public static string[] AvailableLocales {
            get {
                if (availableLocales == null) {
                    availableLocales = Assembly.GetExecutingAssembly().GetManifestResourceNames().Where(name => name.StartsWith(localeFolderPrefix) && name.EndsWith(".txt")).ToArray();
                    for (int i = 0; i < availableLocales.Length; i++) {
                        string cur = availableLocales[i];
                        cur = cur.Substring(0, cur.LastIndexOf(".txt"));
                        int lastSeperator = cur.LastIndexOf('.');
                        cur = cur.Substring(lastSeperator + 1, cur.Length - lastSeperator - 1);
                        availableLocales[i] = cur;
                    }
                }
                return availableLocales;
            }
        }

        public static LauncherLocale LoadLocale(string localeFilename) {
            string localePath = localeFolderPrefix + localeFilename + ".txt";
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(localePath))
            using (StreamReader reader = new StreamReader(stream)) {
                return LoadLocaleFromData(localeFilename, reader.ReadToEnd());
            }
        }

        public static LauncherLocale LoadLocaleFromData(string name, string localeData) {
            Dictionary<string, string> values = new Dictionary<string,string>();
            string[] entries = localeData.Split(new string[]{Environment.NewLine, "\n"}, StringSplitOptions.RemoveEmptyEntries);
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
            return new LauncherLocale(name, values);
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
        public string localeName;

        public LauncherLocale(string name, Dictionary<string, string> values) {
            this.localeName = name;
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
