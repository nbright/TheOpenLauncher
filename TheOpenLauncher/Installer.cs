using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheOpenLauncher
{
    class Installer
    {
        public void CreateUninstallRegistryEntry()
        {
            string name = LauncherSettings.ApplicationName;
            name.Replace('\\', '/');

            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser
                .OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", true)
                .CreateSubKey(name);
            key.SetValue("DisplayName", LauncherSettings.ApplicationName);
            key.SetValue("InstallLocation", InstallationSettings.InstallationFolder);
            key.SetValue("Publisher", LauncherSettings.CompanyName);
            if(!String.IsNullOrEmpty(LauncherSettings.InfoURL)){ key.SetValue("URLInfoAbout", LauncherSettings.InfoURL);}
            if(!String.IsNullOrEmpty(LauncherSettings.HelpURL)) { key.SetValue("HelpLink", LauncherSettings.InfoURL); }
            if(!String.IsNullOrEmpty(LauncherSettings.UpdateInfoURL)) { key.SetValue("URLUpdateInfo", LauncherSettings.InfoURL); }
            key.SetValue("NoModify", 1);
            key.SetValue("NoRepair", 1);
            string uninstallStr = '"' + InstallationSettings.InstallationFolder + "/" + LauncherSettings.UpdaterExecutable + '"' + " -uninstall";
            key.SetValue("UninstallString", uninstallStr);
            key.Close();
        }

        public void CreateDesktopShortcut()
        {
            string pathToExe = InstallationSettings.InstallationFolder + "/" + LauncherSettings.UpdaterExecutable; //
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            WshShell shell = new WshShell();
            string appShortcutLocation = Path.Combine(desktopPath, LauncherSettings.ApplicationName + ".lnk");
            IWshShortcut appShortcut = (IWshShortcut)shell.CreateShortcut(appShortcutLocation);
            appShortcut.Description = "Launch " + LauncherSettings.ApplicationName;
            appShortcut.TargetPath = pathToExe;
            appShortcut.Save(); 
        }

        public void CreateStartMenuEntry()
        {
            string startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            string appStartMenuPath = Path.Combine(Path.Combine(startMenuPath, "Programs"), LauncherSettings.ApplicationName);

            if (!Directory.Exists(appStartMenuPath))
                Directory.CreateDirectory(appStartMenuPath);

            WshShell shell = new WshShell();
            
            //Application/updater shortcut
            string pathToExe = InstallationSettings.InstallationFolder + "/" + LauncherSettings.UpdaterExecutable;
            string appShortcutLocation = Path.Combine(appStartMenuPath, LauncherSettings.ApplicationName + ".lnk");
            IWshShortcut appShortcut = (IWshShortcut)shell.CreateShortcut(appShortcutLocation);
            appShortcut.Description = "Launch " + LauncherSettings.ApplicationName;
            appShortcut.TargetPath = pathToExe;
            appShortcut.Save(); 

            //uninstaller shortcut
            string pathToUninstaller = InstallationSettings.InstallationFolder + "/" + LauncherSettings.UpdaterExecutable;
            string uninstallShortcutLocation = Path.Combine(appStartMenuPath, "Uninstall "+LauncherSettings.ApplicationName + ".lnk");
            IWshShortcut uninstallerShortcut = (IWshShortcut)shell.CreateShortcut(uninstallShortcutLocation);
            uninstallerShortcut.Description = "Uninstall " + LauncherSettings.ApplicationName;
            uninstallerShortcut.Arguments = "-uninstall";
            uninstallerShortcut.TargetPath = pathToUninstaller;
            appShortcut.Save(); 

            //website shortcut
            if (LauncherSettings.InfoURL != null){
                string webShortcutLocation = Path.Combine(appStartMenuPath, LauncherSettings.ApplicationName + " online info.lnk");
                IWshShortcut webShortcut = (IWshShortcut)shell.CreateShortcut(webShortcutLocation);
                webShortcut.Description = "View online info about " + LauncherSettings.ApplicationName;
                webShortcut.TargetPath = LauncherSettings.InfoURL;
                webShortcut.Save(); 
            }
        }

        public void InstallApplication()
        {
            if(!Directory.Exists(InstallationSettings.InstallationFolder)){
                Directory.CreateDirectory(InstallationSettings.InstallationFolder);
            }

            FileIndex newIndex = new FileIndex(LauncherSettings.AppID);
            newIndex.Serialize(InstallationSettings.InstallationFolder + "/UpdateIndex.dat");
            
            Updater updater = new Updater();
            UpdateProgressWindow progressWindow = new UpdateProgressWindow(updater);
            progressWindow.SetProgress(10, "Retrieving update info");
            updater.RetrieveAppInfo((appInfo, host) => {
                if(appInfo == null){
                    MessageBox.Show(progressWindow, "Cannot install: No valid download mirrors online.", "Failed to install", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                updater.RetrieveUpdateInfo(appInfo, host, appInfo.LatestVersion, (updateInfo, updateHost) => {
                    if (updateInfo == null){
                        MessageBox.Show("No valid update info found.");
                        //TODO: Handle this. Should either search for new appInfo host or fail.
                    }
                    progressWindow.SetProgress(20, "Applying updates");
                    updater.ApplyUpdate(appInfo, updateInfo, updateHost);

                    progressWindow.SetProgress(90, "Registering installation");
                    CreateUninstallRegistryEntry();
                    SetInstallationFolder(InstallationSettings.InstallationFolder);
                    if (InstallationSettings.CreateDesktopShortcut)
                    {
                        CreateDesktopShortcut();
                    }
                    if (InstallationSettings.CreateStartMenuEntry)
                    {
                        CreateStartMenuEntry();
                    }
                    progressWindow.Hide();
                    InstallationFinishedForm finishedForm = new InstallationFinishedForm();
                    finishedForm.ShowDialog();
                    progressWindow.Close();
                });
            });
            progressWindow.ShowDialog();
        }

        public void SetInstallationFolder(string folder) {
            string name = LauncherSettings.ApplicationName;
            name.Replace('\\', '/');

            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\" + name, true);
            key.SetValue("InstallationFolder", folder);
        }

        public static string GetInstallationFolder() {
            string name = LauncherSettings.ApplicationName;
            name.Replace('\\', '/');

            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\" + name);
            if(key != null){
                return (string)key.GetValue("InstallationFolder");
            }
            return null;
        }

        public static bool IsInstalled()
        {
            string name = LauncherSettings.ApplicationName;
            name.Replace('\\', '/');

            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\" + name);
            return key != null;
        }
    }
}
