using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheOpenLauncher.Properties;

namespace TheOpenLauncher
{
    class LauncherSettings
    {
        public static string ApplicationName = "ExampleApplication";
        public static string CompanyName = "Example Inc.";
        public static string TargetExecutable = "vlc.exe";//"myapp.exe";  //Updater will run this
        public static string UpdaterExecutable = "myappUpdater.exe"; //Links to program run this.
        public static string[] UpdateURLs = new String[]{
            "http://www.example.com/updater",
            "http://mycompany.net/myapp/updater/",
            "https://dl.dropboxusercontent.com/u/35774053/ExampleProject/"
        };
        public static string AppID = "YourCompany/ExampleProject";//CompanyName+"/"+ApplicationName;

        public static string InfoURL = null;
        public static string HelpURL = null;
        public static string UpdateInfoURL = null;
    }

    class InstallationSettings
    {
        public static string InstallationFolder = @"C:/Program Files/" + LauncherSettings.CompanyName + "/" + LauncherSettings.ApplicationName;
        public static bool CreateDesktopShortcut = true;
        public static bool CreateStartMenuEntry = true;
    }
}
