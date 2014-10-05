using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TheOpenLauncher.VersionPublisher.GUI {
    public partial class MetroSeperator : UserControl {
        public MetroSeperator() {
            InitializeComponent();
        }

        private Orientation orientation = Orientation.Horizontal;
        public Orientation Orientation {
            get {
                return orientation;
            }
            set {
                orientation = value;
                Invalidate();
            }
        }

        private bool fadesIn;
        public bool FadesIn {
            get {
                return fadesIn;
            }
            set {
                fadesIn = value;
                Invalidate();
            }
        }

        private bool fadesOut;
        public bool FadesOut {
            get {
                return fadesOut;
            }
            set {
                fadesOut = value;
                Invalidate();
            }
        }

        private int fadeLenght = 15;
        public int FadeLenght {
            get {
                return fadeLenght;
            }
            set {
                if(value < 1){
                    throw new ArgumentException("Value must be larger than 0");
                }
                fadeLenght = value;
                Invalidate();
            }
        }

        private Color lineColor = SystemColors.Control;
        public Color LineColor {
            get {
                return lineColor;
            }
            set {
                lineColor = value;
                Invalidate();
            }
        }

        private bool ignoreInputEvents;
        public bool IgnoreInputEvents {
            get {
                return ignoreInputEvents;
            }
            set {
                ignoreInputEvents = value;
            }
        }

        protected override void WndProc(ref Message m) {
            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = (-1);

            if (ignoreInputEvents && m.Msg == WM_NCHITTEST) {
                m.Result = (IntPtr)HTTRANSPARENT;
            } else {
                base.WndProc(ref m);
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Point point1, point2;
            if(orientation.Equals(Orientation.Horizontal)){
                point1 = new Point(0, this.Height / 2);
                point2 = new Point(Width, this.Height / 2);
            }else{
                point1 = new Point(this.Width / 2, 0);
                point2 = new Point(this.Width / 2, Height);
            }
            Point solidStartPoint = point1, solidEndPoint = point2;

            if (fadesIn) {
                solidStartPoint = orientation == Orientation.Horizontal ? new Point(fadeLenght, this.Height / 2) : new Point(this.Width / 2, fadeLenght);
                using (LinearGradientBrush fadeBrush = new LinearGradientBrush(point1, solidStartPoint, Color.Transparent, lineColor)) {
                    using (Pen fadePen = new Pen(fadeBrush)) {
                        e.Graphics.DrawLine(fadePen, point1, solidStartPoint);
                    }
                }
            }

            if (fadesOut) {
                solidEndPoint = orientation == Orientation.Horizontal ? new Point(Width - fadeLenght, this.Height / 2) : new Point(this.Width / 2, Height - fadeLenght);
                using (LinearGradientBrush fadeBrush = new LinearGradientBrush(solidEndPoint, point2, lineColor, Color.Transparent)) {
                    using (Pen fadePen = new Pen(fadeBrush)) {
                        e.Graphics.DrawLine(fadePen, solidEndPoint, point2);
                    }
                }
            }

            using(Pen pen = new Pen(lineColor)){
                e.Graphics.DrawLine(pen, solidStartPoint, solidEndPoint);
            }
        }
    }
}
