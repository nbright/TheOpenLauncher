using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using TheOpenLauncher.Properties;

namespace TheOpenLauncher
{
    public class UpdateHost
    {
        private static UpdateHost[] hosts;
        public static UpdateHost[] GetUpdateHosts(){
            if(hosts == null){
                List<UpdateHost> validURLs = new List<UpdateHost>();
                foreach(string curURL in LauncherSettings.UpdateURLs){
                    UriBuilder builder = new UriBuilder(curURL);
                    try{
                        validURLs.Add(new UpdateHost(builder.Uri));
                    }catch (UriFormatException){
                        MessageBox.Show("Invalid updater URL: " + curURL, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                hosts = validURLs.ToArray();
            }
            return hosts;
        }

        private Uri hostURL;
        private UpdateHost(Uri host){
            this.hostURL = host;
        }

        public Uri HostURL{
            get
            {
                return hostURL;
            }
        }

        public Uri AppInfoURL
        {
            get
            {
                UriBuilder uriBuilder = new UriBuilder(hostURL);
                uriBuilder.Path = uriBuilder.Path + '/' + "appinfo.json";
                return uriBuilder.Uri;
            }
        }

        public Uri GetVersionFolderURL(AppInfo appInfo, double version) {
            UriBuilder uriBuilder = new UriBuilder(hostURL);

            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            uriBuilder.Path = uriBuilder.Path + '/' + appInfo.downloadBaseDir + '/' + version.ToString(nfi) + '/';
            return uriBuilder.Uri;
        }

        public Uri GetVersionInfoURL(AppInfo appInfo, double version)
        {
            UriBuilder uriBuilder = new UriBuilder(GetVersionFolderURL(appInfo, version));
            uriBuilder.Path = uriBuilder.Path + "info.json";
            return uriBuilder.Uri;
        }

        internal Uri GetFileURL(AppInfo appInfo, UpdateInfo info, string curFile) {
            UriBuilder uriBuilder = new UriBuilder(GetVersionFolderURL(appInfo, info.version));
            uriBuilder.Path = uriBuilder.Path + "dl/" + curFile;
            return uriBuilder.Uri;
        }
    }
}
