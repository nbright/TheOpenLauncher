using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheOpenLauncher.VersionPublisher.GUI {
    [Designer("System.Windows.Forms.Design.TabControlDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public partial class TablessTabControl : TabControl {
        public TablessTabControl() {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m) {
            bool debugMode = false;
            if (!debugMode && m.Msg == 0x1328 && !DesignMode) {
                m.Result = (IntPtr)1;
            }else{
                base.WndProc(ref m);
            }
        }
    }
}
