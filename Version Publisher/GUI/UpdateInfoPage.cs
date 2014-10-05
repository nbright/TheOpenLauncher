using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace TheOpenLauncher.VersionPublisher.GUI {
    public partial class UpdateInfoPage : UserControl {
        public UpdateInfoPage() {
            InitializeComponent();
        }

        public void SetUpdateInfoPanel(UpdateInfo lastUpdate, UpdateInfo info) {
            NumberFormatInfo formatInfo = new NumberFormatInfo();
            formatInfo.NumberDecimalSeparator = ".";

            if (info.summary != null) {
                summaryLabel.Text = info.summary;
                versionLabel.Text = "Version " + info.version.ToString(formatInfo) + " - " + info.ReleaseDate.ToString("MMMM dd, yyyy");
            } else {
                summaryLabel.Text = "Version " + info.version.ToString(formatInfo);
                versionLabel.Text = "Released on " + info.ReleaseDate.ToString("MMMM dd, yyyy");
            }

            notesTextBox.Text = info.changeLog;

            FileDiffListItem[] diff;
            if (lastUpdate != null) {
                diff = GetUpdateFilesDiff(lastUpdate, info);
            } else {
                diff = new FileDiffListItem[info.fileChecksums.Count];
                for (int i = 0; i < diff.Length; i++) {
                    diff[i] = new FileDiffListItem(info.fileChecksums.Keys.ElementAt(i), FileDiffListItem.FileState.ADDED);
                }
            }

            SetFileChangesList(diff);
        }

        //TODO: check entire update history to get deleted files
        private FileDiffListItem[] GetUpdateFilesDiff(UpdateInfo baseUpdate, UpdateInfo newUpdate) {
            List<FileDiffListItem> items = new List<FileDiffListItem>();
            foreach (KeyValuePair<string, string> cur in newUpdate.fileChecksums) {
                string baseCheckSum;
                if (baseUpdate.fileChecksums.TryGetValue(cur.Key, out baseCheckSum)) {
                    if (!baseCheckSum.Equals(cur.Value)) {
                        items.Add(new FileDiffListItem(cur.Key, FileDiffListItem.FileState.CHANGED));
                    }
                } else {
                    items.Add(new FileDiffListItem(cur.Key, FileDiffListItem.FileState.ADDED));
                }
            }

            foreach (KeyValuePair<string, string> cur in baseUpdate.fileChecksums) {
                string baseCheckSum;
                if (!baseUpdate.fileChecksums.TryGetValue(cur.Key, out baseCheckSum)) {
                    items.Add(new FileDiffListItem(cur.Key, FileDiffListItem.FileState.REMOVED));
                }
            }

            return items.ToArray();
        }

        private void SetFileChangesList(FileDiffListItem[] changes) {
            changesListbox.Invoke((Action)(() => {
                changesListbox.Clear();
                foreach (FileDiffListItem cur in changes) {
                    changesListbox.Items.Add(cur.path);
                    changesListbox.ItemBackgroundColors.Add(FileDiffListItem.GetStateColor(cur.state));
                }
            }));
        }
    }
}
