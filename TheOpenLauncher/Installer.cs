using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TheOpenLauncher {
    class Installer {
        public void CreateUninstallRegistryEntry() {
            string name = LauncherSettings.ApplicationName;
            name.Replace('\\', '/');

            RegistryKey uninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", true);
            if (uninstallKey == null) {
                uninstallKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
            }

            string installationFolder = new FileInfo(InstallationSettings.InstallationFolder).FullName;
            using (RegistryKey key = uninstallKey.CreateSubKey(name)) {
                key.SetValue("DisplayName", LauncherSettings.ApplicationName);
                key.SetValue("DisplayIcon", installationFolder + "\\" + LauncherSettings.UpdaterExecutable);
                string uninstallStr = '"' + installationFolder + "\\" + LauncherSettings.UpdaterExecutable + '"' + " -uninstall";
                key.SetValue("UninstallString", uninstallStr);
                key.SetValue("InstallLocation", installationFolder);
                key.SetValue("Publisher", LauncherSettings.CompanyName);
                if (!String.IsNullOrEmpty(LauncherSettings.InfoURL)) { key.SetValue("URLInfoAbout", LauncherSettings.InfoURL); }
                if (!String.IsNullOrEmpty(LauncherSettings.HelpURL)) { key.SetValue("HelpLink", LauncherSettings.InfoURL); }
                if (!String.IsNullOrEmpty(LauncherSettings.UpdateInfoURL)) { key.SetValue("URLUpdateInfo", LauncherSettings.InfoURL); }
                key.SetValue("NoModify", 1);
                key.SetValue("NoRepair", 1);
                key.Close();
            }
            uninstallKey.Close();
        }

        public void RemoveUninstallRegistryEntry() {
            string name = LauncherSettings.ApplicationName;
            name.Replace('\\', '/');

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", true);
            if (key != null) {
                key.DeleteSubKey(name);
            }
        }

        public void CreateDesktopShortcut() {
            string pathToExe = InstallationSettings.InstallationFolder + "/" + LauncherSettings.UpdaterExecutable; //
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            WshShell shell = new WshShell();
            string appShortcutLocation = Path.Combine(desktopPath, LauncherSettings.ApplicationName + ".lnk");
            IWshShortcut appShortcut = (IWshShortcut)shell.CreateShortcut(appShortcutLocation);
            appShortcut.Description = "Launch " + LauncherSettings.ApplicationName;
            appShortcut.TargetPath = pathToExe;
            appShortcut.Save();
        }

        public void CreateStartMenuEntry() {
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
            string uninstallShortcutLocation = Path.Combine(appStartMenuPath, "Uninstall " + LauncherSettings.ApplicationName + ".lnk");
            IWshShortcut uninstallerShortcut = (IWshShortcut)shell.CreateShortcut(uninstallShortcutLocation);
            uninstallerShortcut.Description = "Uninstall " + LauncherSettings.ApplicationName;
            uninstallerShortcut.Arguments = "-uninstall";
            uninstallerShortcut.TargetPath = pathToUninstaller;
            uninstallerShortcut.Save();

            //website shortcut
            if (LauncherSettings.InfoURL != null) {
                string webShortcutLocation = Path.Combine(appStartMenuPath, LauncherSettings.ApplicationName + " online info.lnk");
                IWshShortcut webShortcut = (IWshShortcut)shell.CreateShortcut(webShortcutLocation);
                webShortcut.Description = "View online info about " + LauncherSettings.ApplicationName;
                webShortcut.TargetPath = LauncherSettings.InfoURL;
                webShortcut.Save();
            }
        }

        public void RemoveStartMenuEntry() {
            string startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            string appStartMenuPath = Path.Combine(Path.Combine(startMenuPath, "Programs"), LauncherSettings.ApplicationName);
            if (!Directory.Exists(appStartMenuPath)) { return; }

            string appShortcutLocation = Path.Combine(appStartMenuPath, LauncherSettings.ApplicationName + ".lnk");
            string uninstallShortcutLocation = Path.Combine(appStartMenuPath, "Uninstall " + LauncherSettings.ApplicationName + ".lnk");
            string webShortcutLocation = Path.Combine(appStartMenuPath, LauncherSettings.ApplicationName + " online info.lnk");
            if (System.IO.File.Exists(appShortcutLocation)) {
                System.IO.File.Delete(appShortcutLocation);
            }
            if (System.IO.File.Exists(uninstallShortcutLocation)) {
                System.IO.File.Delete(uninstallShortcutLocation);
            }
            if (System.IO.File.Exists(webShortcutLocation)) {
                System.IO.File.Delete(webShortcutLocation);
            }
            DirectoryInfo appStartMenuDir = new DirectoryInfo(appStartMenuPath);
            if (appStartMenuDir.GetFiles().Length == 0 && appStartMenuDir.GetDirectories().Length == 0) {
                appStartMenuDir.Delete();
            }
        }

        public void InstallApplication(Action finishCallback) {
            if (!Directory.Exists(InstallationSettings.InstallationFolder)) {
                Directory.CreateDirectory(InstallationSettings.InstallationFolder);
            }

            string lockFile = InstallationSettings.InstallationFolder + "/Updater.lock";
            if (System.IO.File.Exists(lockFile)) {
                string message = "The chosen installation folder contains updater files. Installing in this folder may corrupt previous installations. Force installation?";
                if (MessageBox.Show(null, message, "Folder contains updater traces", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes) {
                    System.IO.File.Delete(lockFile);
                } else {
                    Application.Exit();
                }
            }

            FileIndex newIndex = new FileIndex(LauncherSettings.AppID);
            newIndex.Serialize(InstallationSettings.InstallationFolder + "/UpdateIndex.dat");

            Updater updater = new Updater();
            UpdateProgressWindow progressWindow = new UpdateProgressWindow(updater);
            progressWindow.SetProgress(0, "Retrieving update info");
            updater.RetrieveAppInfo((appInfo, host) => {
                if (appInfo == null) {
                    MessageBox.Show(progressWindow, "Cannot install: No valid download mirrors online.", "Failed to install", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                updater.RetrieveUpdateInfo(appInfo, host, appInfo.LatestVersion, (updateInfo, updateHost) => {
                    Action startUpdate = (() => {
                        if (updateInfo == null) {
                            MessageBox.Show("No valid update info found.");
                            //TODO: Handle this. Should either search for new appInfo host or fail.
                        }
                        progressWindow.SetProgress(20, "Applying updates");
                        updater.ApplyUpdate(appInfo, updateInfo, updateHost);
                        progressWindow.SetProgress(90, "Registering installation");
                        try {
                            CreateUninstallRegistryEntry();
                            SetInstallationFolder(InstallationSettings.InstallationFolder);
                            if (InstallationSettings.CreateDesktopShortcut) {
                                CreateDesktopShortcut();
                            }
                            if (InstallationSettings.CreateStartMenuEntry) {
                                CreateStartMenuEntry();
                            }
                        } catch (Exception ex) {
                            MessageBox.Show(
                                "An exception occured while registering the application. \r\n" +
                                ex.Message +
                                "\r\nTo uninstall the application run the updater with -uninstall -forceInstallDir <installfolder>", "Error"
                                );
                        }

                        progressWindow.Invoke((Action)(() => { progressWindow.Close(); }));

                        InstallationFinishedForm finishedForm = new InstallationFinishedForm();
                        finishedForm.ShowDialog();
                        finishCallback.Invoke();
                    });
                    Thread updateThread = new Thread(new ThreadStart(startUpdate));
                    updateThread.Name = "Update thread";
                    updateThread.IsBackground = true;
                    updateThread.Start();
                });
            });
            progressWindow.Show();
        }

        private string[] DeleteFiles() {
            FileIndex index = FileIndex.Deserialize(InstallationSettings.InstallationFolder + "/UpdateIndex.dat");
            List<string> failedToRemove = new List<string>();
            string[] filesSortedByDepth = index.files.OrderByDescending(path => path.Split(new Char[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries).Length).ToArray();
            foreach (string cur in filesSortedByDepth) { //Delete files, deepest first, topmost last.
                try {
                    string curFile = InstallationSettings.InstallationFolder + '/' + cur;
                    System.IO.File.Delete(curFile);
                    DirectoryInfo subDirInfo = Directory.GetParent(curFile);
                    if (subDirInfo.GetFiles().Length == 0 && subDirInfo.GetDirectories().Length == 0) {
                        subDirInfo.Delete();
                    }
                } catch (Exception) {
                    failedToRemove.Add(cur);
                }
            }

            System.IO.File.Delete(InstallationSettings.InstallationFolder + "/UpdateIndex.dat");

            DirectoryInfo dirInfo = new DirectoryInfo(InstallationSettings.InstallationFolder);
            if (dirInfo.GetFiles().Length == 0 && dirInfo.GetDirectories().Length == 0) {
                dirInfo.Delete();
            }

            return failedToRemove.ToArray();
        }

        private void ScheduleFileRemovals(string[] files) {
            string taskGUID = Guid.NewGuid().ToString();

            string cleanupFile = InstallationSettings.InstallationFolder + "/Cleanup.bat";
            StringBuilder cmds = new StringBuilder();
            cmds.AppendLine("@echo off");
            cmds.AppendLine("@title Removing installation leftovers");
            cmds.AppendLine("echo Removing installation leftovers...");
            foreach (string file in files) {
                cmds.AppendLine("del /F /S /Q /A \"" + file + "\"");
            }
            cmds.AppendLine(@"reg Delete HKCU\Software\Microsoft\Windows\CurrentVersion\Run /f /v " + taskGUID);
            cmds.AppendLine("del /F /S /Q /A \"" + cleanupFile + "\"");

            System.IO.File.WriteAllText(cleanupFile, cmds.ToString());

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue(taskGUID, Application.ExecutablePath);
            registryKey.Close();
        }

        public void UninstallApplication() {
            if (!Directory.Exists(InstallationSettings.InstallationFolder)) {
                throw new Exception("Application folder does not exist.");
            }

            if (!System.IO.File.Exists(InstallationSettings.InstallationFolder + "/UpdateIndex.dat")) {
                throw new Exception("Application update index does not exist.");
            }

            string[] files = DeleteFiles();
            if (files.Length > 0) {
                ScheduleFileRemovals(files);
            }

            RemoveStartMenuEntry();
            RemoveUninstallRegistryEntry();
        }

        public static void SetInstallationFolder(string folder) {
            string name = LauncherSettings.ApplicationName;
            name.Replace('\\', '/');

            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\" + name, true);
            key.SetValue("InstallationFolder", folder);
        }

        public static string GetInstallationFolder() {
            string name = LauncherSettings.ApplicationName;
            name.Replace('\\', '/');

            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\" + name);
            if (key != null) {
                return (string)key.GetValue("InstallationFolder");
            }
            return null;
        }

        public static bool IsInstalled() {
            string name = LauncherSettings.ApplicationName;
            name.Replace('\\', '/');

            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\" + name);
            return key != null;
        }
    }
}
