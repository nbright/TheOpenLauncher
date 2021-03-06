﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using TheOpenLauncher.Properties;

namespace TheOpenLauncher
{
    static class Program
    {
        private static Dictionary<string, string> startupArguments = new Dictionary<string, string>();

        private static void ParseArguments(string[] args){
            string lastKey = null;
            for (int i = 0; i < args.Length;i++ )
            {
                if (String.IsNullOrEmpty(args[i].Trim())) {
                    continue;
                }

                if(args[i].StartsWith("-")){
                    lastKey = args[i].Substring(1);
                    startupArguments.Add(lastKey, "");
                }else if (lastKey != null){
                    string value;
                    if (startupArguments.TryGetValue(lastKey, out value)){
                        startupArguments[lastKey] = value + " " + args[i];
                    }else{
                        MessageBox.Show(
                            "Invalid startup argument: " + args[i] + ". Please specify options as keys with corresponding option values (-exampleKey exampleValue1 exampleValue2)",
                            "Invalid startup argument", MessageBoxButtons.OK, MessageBoxIcon.Error
                            );
                    }
                }else{
                    MessageBox.Show(
                            "Invalid startup argument: " + args[i] + ". Please specify options as keys with corresponding option values (-exampleKey exampleValue1 exampleValue2)",
                            "Invalid startup argument", MessageBoxButtons.OK, MessageBoxIcon.Error
                            );
                }
            }
        }

        public static void SerializeSettings(string file) {
            string[] lines = new string[3];
            lines[0] = InstallationSettings.CreateDesktopShortcut.ToString();
            lines[1] = InstallationSettings.CreateStartMenuEntry.ToString();
            lines[2] = InstallationSettings.InstallationFolder;
            File.WriteAllLines(file, lines);
        }

        public static void DeserializeSettings(string file) {
            string[] lines = File.ReadAllLines(file);
            InstallationSettings.CreateDesktopShortcut = Boolean.Parse(lines[0]);
            InstallationSettings.CreateStartMenuEntry = Boolean.Parse(lines[1]);
            InstallationSettings.InstallationFolder = lines[2];
        }

        /// <summary>
        /// Try to start the application with administrator rights. 
        /// The arguments are copied from the current instance.
        /// If this succeeds, the current application will close immediately.
        /// If this fails, this method will return false
        /// </summary>
        public static bool RequestElevation() {
            string[] args = Environment.GetCommandLineArgs();
            return RequestElevation(String.Join(" ", args, 1, args.Length - 1));
        }

        /// <summary>
        /// Try to start the application with administrator rights.
        /// If this succeeds, the current application will close immediately.
        /// If this fails, this method will return false
        /// </summary>
        public static bool RequestElevation(string args) {
            string configFile;
            try {
                configFile = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".tmp";
                SerializeSettings(configFile);
            } catch (Exception) {
                MessageBox.Show("The settings could not be saved. Please reenter your preferences after providing administator rights.");
                configFile = null;
            }

            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = Application.ExecutablePath;
            proc.Arguments = args + (configFile != null ? (" -settingsFile " + configFile) : "");
            proc.Verb = "runas";

            try {
                Process.Start(proc);
            } catch {
                return false;
            }

            Application.Exit();
            return true; //unreachable
        }

        public static bool IsRunningElevated()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        static Program() {
            DependenciesLoader.Init();
        }

        [STAThread]
        static void Main(String[] args)
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            ParseArguments(args);

            if (startupArguments.ContainsKey("elevate") && !IsRunningElevated()){
                if (!RequestElevation(String.Join(" ", args)))
                {
                    MessageBox.Show("Failed to obtain admin rights.", "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (startupArguments.ContainsKey("settingsFile")) {
                string settingsFile;
                if (startupArguments.TryGetValue("settingsFile", out settingsFile)) {
                    DeserializeSettings(settingsFile);
                    File.Delete(settingsFile);
                }
            }

            System.Net.ServicePointManager.DefaultConnectionLimit = 32;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Installer.IsInstalled() && !startupArguments.ContainsKey("forceInstallDir")) {
                Application.Run(new InstallForm());
            } else {
                if (startupArguments.ContainsKey("forceInstallDir")) {
                    string value;
                    if (startupArguments.TryGetValue("forceInstallDir", out value)) {
                        Installer.SetInstallationFolder(value);
                    } else {
                        MessageBox.Show("Invalid installation directory");
                        return;
                    }
                }

                InstallationSettings.InstallationFolder = Installer.GetInstallationFolder();
                if (startupArguments.ContainsKey("uninstall")) {
                    Application.Run(new UninstallForm());
                } else {
                    Application.Run(new MainForm());
                }
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            OnUncaughtException(e.ExceptionObject.ToString());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            OnUncaughtException(e.Exception.ToString());
        }

        private static void OnUncaughtException(string exStr) {
            string executableName = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string log = "launcher_crashlog.txt";

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("--------------------------------");
            builder.Append("Crash of ").Append(executableName).Append(" at ").AppendFormat("{0:yyyy-MM-dd hh-mm-ss}", DateTime.Now).AppendLine();
            builder.AppendLine("Exception message: ");
            builder.AppendLine(exStr);
            builder.AppendLine("--------------------------------").AppendLine();
            File.AppendAllText(log, builder.ToString());

            MessageBox.Show("A critical error occured! Please provide the application developers with the crash log generated at " + log, "An unexpected error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void LaunchTargetApplication(IWin32Window owner) {
            try{
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = InstallationSettings.InstallationFolder;
                proc.FileName = InstallationSettings.InstallationFolder + "/" + LauncherSettings.TargetExecutable;
                Process.Start(proc);
            }catch(FileNotFoundException ex){
                MessageBox.Show(owner, "Could not start application: " + ex.FileName + " is missing.", "Failed to start " + LauncherSettings.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }catch(Win32Exception ex){
                MessageBox.Show(owner, "Could not start application: " + ex.Message, "Failed to start " + LauncherSettings.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
