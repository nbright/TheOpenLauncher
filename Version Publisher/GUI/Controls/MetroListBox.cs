using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Interfaces;
using System.Windows.Forms.Design;
using System.Collections;
using MetroFramework.Drawing;
using MetroFramework;
using MetroFramework.Components;
using System.Runtime.Serialization;
using System.Drawing.Design;

namespace TheOpenLauncher.VersionPublisher.GUI {
    [Designer(typeof(MetroListBoxDesigner))]
    [ToolboxBitmap(typeof(Button))]
    [DefaultEvent("Click")]
    public partial class MetroListBox : ListBox, IMetroControl {

        #region Interface

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                CustomPaintBackground(this, e);
            }
        }

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private MetroColorStyle metroStyle = MetroColorStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DefaultValue(MetroColorStyle.Default)]
        public MetroColorStyle Style
        {
            get
            {
                if (DesignMode || metroStyle != MetroColorStyle.Default)
                {
                    return metroStyle;
                }

                if (StyleManager != null && metroStyle == MetroColorStyle.Default)
                {
                    return StyleManager.Style;
                }
                if (StyleManager == null && metroStyle == MetroColorStyle.Default)
                {
                    return MetroDefaults.Style;
                }

                return metroStyle;
            }
            set { metroStyle = value; }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DefaultValue(MetroThemeStyle.Default)]
        public MetroThemeStyle Theme
        {
            get
            {
                if (DesignMode || metroTheme != MetroThemeStyle.Default)
                {
                    return metroTheme;
                }

                if (StyleManager != null && metroTheme == MetroThemeStyle.Default)
                {
                    return StyleManager.Theme;
                }
                if (StyleManager == null && metroTheme == MetroThemeStyle.Default)
                {
                    return MetroDefaults.Theme;
                }

                return metroTheme;
            }
            set { metroTheme = value; }
        }

        private MetroStyleManager metroStyleManager = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroStyleManager StyleManager
        {
            get { return metroStyleManager; }
            set { metroStyleManager = value; }
        }

        private bool useCustomBackColor= false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool useCustomForeColor = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseCustomForeColor
        {
            get { return useCustomForeColor; }
            set { useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [Category(MetroDefaults.PropertyCategory.Behaviour)]
        [DefaultValue(false)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }

        #endregion

        #region Fields

        private bool displayFocusRectangle = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool DisplayFocus
        {
            get { return displayFocusRectangle; }
            set { displayFocusRectangle = value; }
        }

        private List<ListIcon> icons = new List<ListIcon>();
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [MergableProperty(false)]
        [Bindable(false)]
        public List<ListIcon> ItemIcons {
            get{
                return icons;
            }
        }

        public class ListIcon {
            private Image icon;
            private Image selectedIcon;
            public Image Icon {
                get {
                    return icon;
                }
                set {
                    icon = value;
                }
            }
            public Image ItemSelectedIcon {
                get {
                    return selectedIcon;
                }
                set {
                    selectedIcon = value;
                }
            }
        }

        private bool repeatIcons;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool RepeatIcons {
            get {
                return repeatIcons;
            }
            set {
                repeatIcons = value;
            }
        }

        private List<String> subTexts = new List<String>();
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [MergableProperty(false)]
        [Bindable(false)]
        public List<String> ItemSubTexts {
            get {
                return subTexts;
            }
        }

        private List<Color> itembgColors = new List<Color>();
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [MergableProperty(false)]
        [Bindable(false)]
        public List<Color> ItemBackgroundColors {
            get {
                return itembgColors;
            }
        }

        private bool drawSeperator;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool DrawSeperator {
            get {
                return drawSeperator;
            }
            set {
                drawSeperator = value;
            }
        }

        private Color seperatorColor = SystemColors.Control;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public Color SeperatorColor {
            get {
                return seperatorColor;
            }
            set {
                seperatorColor = value;
            }
        }
        
        #endregion

        #region Constructor

        public MetroListBox()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);
            this.SelectedIndexChanged += MetroListBox_SelectedIndexChanged;
            this.Resize += (sender, e) => { ClampScroll(); };
        }

        void MetroListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.Invalidate();
        }

        #endregion

        #region Paint Methods

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try 
            {
                Color backColor = MetroPaint.BackColor.Form(this.metroTheme);
                base.OnPaintBackground(e);
                OnCustomPaintBackground(new MetroPaintEventArgs(backColor, Color.Empty, e.Graphics));
            }
            catch
            { 
                Invalidate(); 
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color selectedItemBGColor = MetroPaint.GetStyleColor(this.metroStyle);
            using (Brush b = new SolidBrush(selectedItemBGColor)) {
                e.Graphics.FillRectangle(b, new Rectangle(0, 0, Width, Height));
            }

            try			
            {
                if (GetStyle(ControlStyles.AllPaintingInWmPaint))
                {
                    OnPaintBackground(e);
                }

                OnCustomPaint(new MetroPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
                OnPaintForeground(e); 
            }
            catch 
            {
                Invalidate();
            }
        }

        protected virtual void OnPaintForeground(PaintEventArgs e)
        {
            Color selectedItemBGColor = MetroPaint.GetStyleColor(this.metroStyle);
            if (useCustomForeColor) {
                selectedItemBGColor = ForeColor;
            }
            Color foreColor = MetroPaint.ForeColor.Label.Normal(this.metroTheme);
            
            for (int i = 0; i < this.Items.Count;i++ ) {
                int curY = (i * ItemHeight) - (ItemHeight * scrollY);
                Rectangle itemRect = new Rectangle(0, curY, Width, ItemHeight);
                Color textColor = foreColor;

                if(this.SelectedIndex == i){
                    using (Brush b = new SolidBrush(selectedItemBGColor))
                    {
                        e.Graphics.FillRectangle(b, itemRect);
                    }
                    textColor = Color.White;
                } else if (itembgColors.Count > i && itembgColors[i] != Color.Empty) {
                    using (Brush b = new SolidBrush(itembgColors[i]))
                    {
                        e.Graphics.FillRectangle(b, itemRect);
                    }
                    textColor = itembgColors[i].GetBrightness() < 0.5 ? Color.White : Color.Black;
                }

                if(drawSeperator && i != this.Items.Count-1){
                    using (Pen p = new Pen(seperatorColor)) {
                        e.Graphics.DrawLine(p, 0, curY + ItemHeight-1, this.Width, curY + ItemHeight-1);
                    }
                }

                ListIcon curIcon = null;
                if (icons.Count > 0) {
                    if(repeatIcons){
                        curIcon = icons[i % icons.Count];
                    } else if(i < icons.Count){
                        curIcon = icons[i];
                    }
                }

                PaintListItemForeground(e, i, itemRect, curIcon, textColor);
            }

            OnCustomPaintForeground(new MetroPaintEventArgs(Color.Empty, selectedItemBGColor, e.Graphics));
        }

        private Font mainFont = MetroFonts.Label(MetroLabelSize.Medium, MetroLabelWeight.Regular);
        private Font subFont = MetroFonts.Label(MetroLabelSize.Small, MetroLabelWeight.Regular);
        public virtual void PaintListItemForeground(PaintEventArgs e, int i, Rectangle itemRect, ListIcon icon, Color textColor) {
            if (icon != null) {
                Image img = SelectedIndex == i ? icon.ItemSelectedIcon : icon.Icon;
                if(img != null){
                    e.Graphics.DrawImage(img, new Rectangle(16, (i * ItemHeight) + (ItemHeight / 2) - 8, 16, 16));
                }
            }

            Rectangle textRect = itemRect;
            if (icon == null) {
                textRect.X = textRect.X + 10;
                textRect.Width = textRect.Width - 10;
            } else {
                textRect.X = textRect.X + 40;
                textRect.Width = textRect.Width - 40;
            }

            if (this.ItemSubTexts.Count > i && subTexts[i] != null && ItemHeight > 40) {
                //Ugly hacks look nice
                Rectangle mainTextRect = textRect, subTextRect; //Top part of item is for main text
                mainTextRect.Height = mainTextRect.Height / 2;
                
                subTextRect = mainTextRect;                     //Bottom part is for subtext
                subTextRect.Offset(3, mainTextRect.Height);
                subTextRect.Width = subTextRect.Width - 3;
                subTextRect.Height = subTextRect.Height - 5;    //Vertical offset

                mainTextRect.Height = mainTextRect.Height - 7;  //Vertical offset
                mainTextRect.Y = mainTextRect.Y + 7;

                String mainStr = ClipText(e.Graphics, mainFont, Items[i].ToString(), mainTextRect.Width);
                TextRenderer.DrawText(
                    e.Graphics,
                    mainStr,
                    mainFont,
                    mainTextRect,
                    textColor,
                    TextFormatFlags.Left | TextFormatFlags.Bottom
                );

                String subStr = ClipText(e.Graphics, subFont, subTexts[i], subTextRect.Width);
                TextRenderer.DrawText(
                    e.Graphics,
                    subStr,
                    subFont,
                    subTextRect,
                    textColor,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter
                );
            } else {
                String str = ClipText(e.Graphics, subFont, Items[i].ToString(), textRect.Width);
                TextRenderer.DrawText(
                    e.Graphics,
                    str,
                    subFont,
                    textRect,
                    textColor,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter
                );
            }
        }

        private string ClipText(Graphics g, Font font, string str, int maxSize) {
            char[] chars = str.ToCharArray();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < str.Length;i++ ) {
                builder.Append(chars[i]);
                if (g.MeasureString(builder.ToString(), font).Width > maxSize) {
                    builder.Remove(builder.Length - 4, 4);
                    builder.Append("...");
                    return builder.ToString();
                }
            }
            return str;
        }

        #endregion

        #region Focus Methods

        protected override void OnGotFocus(EventArgs e)
        {
            Invalidate();

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            Invalidate();

            base.OnLostFocus(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            Invalidate();

            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            Invalidate();

            base.OnLeave(e);
        }

        #endregion

        #region Keyboard Methods

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            //Remove this code cause this prevents the focus color
            //isHovered = false;
            //isPressed = false;
            Invalidate();

            base.OnKeyUp(e);
        }

        #endregion

        #region Mouse Methods

        protected override void OnMouseEnter(EventArgs e)
        {
            Invalidate();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Invalidate();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Invalidate();

            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Invalidate();

            base.OnMouseLeave(e);
        }

        #endregion

        #region Overridden Methods

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        private int scrollY;
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x115) { //WM_VSCROLL
                int type = m.WParam.ToInt32() & 0xffff;
                int value = m.WParam.ToInt32() >> 16;
                if ((ScrollEventType)type == ScrollEventType.ThumbTrack) {
                    scrollY = value;
                }
            } else if (m.Msg == 0x020A) { //WM_MOUSEWHEEL
                int amount = m.WParam.ToInt32() >> 16;
                int iDelta = (amount / -120) * 3; // (distance / -WHEEL_DELTA) * items_per_scroll
                scrollY = scrollY + iDelta;
                ClampScroll();
            }
            base.WndProc(ref m);
        }

        private void ClampScroll() {
            int contentHeight = this.ItemHeight * this.Items.Count;
            if (contentHeight == 0 || (this.Height / contentHeight) > 1) {
                scrollY = 0;
                return;
            }

            if (scrollY < 0) {
                scrollY = 0;
            }
            int maxScroll = this.Items.Count - (this.Height / this.ItemHeight);
            if (scrollY > maxScroll) {
                scrollY = maxScroll;
            }
        }

        #endregion

        public void Clear() {
            Items.Clear();
            ItemIcons.Clear();
            ItemSubTexts.Clear();
            ItemBackgroundColors.Clear();
        }
    }

    internal static class MetroDefaults {
        public const MetroColorStyle Style = MetroColorStyle.Blue;
        public const MetroThemeStyle Theme = MetroThemeStyle.Light;

        public static class PropertyCategory {
            public const string Appearance = "Metro Appearance";
            public const string Behaviour = "Metro Behaviour";
        }
    }

    internal class MetroListBoxDesigner : ControlDesigner {
        public override SelectionRules SelectionRules {
            get {
                return base.SelectionRules;
            }
        }

        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            // Selection of tabs via mouse
            if (m.Msg == 0x201/*WM_LBUTTONDOWN*/) {
                MetroListBox control = (MetroListBox)Component;
                Point hitPoint = control.PointToClient(Cursor.Position);
                int i = hitPoint.Y / control.ItemHeight;
                if(i < control.Items.Count){
                    control.SelectedIndex = i;
                    control.Invalidate();
                }
            }
        }

        protected override void PreFilterProperties(IDictionary properties) {
            properties.Remove("ImeMode");
            properties.Remove("Padding");
            properties.Remove("FlatAppearance");
            properties.Remove("FlatStyle");
            properties.Remove("AutoEllipsis");
            properties.Remove("UseCompatibleTextRendering");

            properties.Remove("Image");
            properties.Remove("ImageAlign");
            properties.Remove("ImageIndex");
            properties.Remove("ImageKey");
            properties.Remove("ImageList");
            properties.Remove("TextImageRelation");

            properties.Remove("UseVisualStyleBackColor");

            properties.Remove("Font");
            properties.Remove("RightToLeft");

            base.PreFilterProperties(properties);
        }
    }
}
