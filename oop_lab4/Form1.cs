using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace oop_lab4
{
    public partial class UartApp : Form
    {
        public UartApp()
        {
            InitializeComponent();
            update_leds();
        }

        void update_leds()
        {
            rgdLedCtl1.R = rgbLedCtl2.R = (byte)trackR.Value;
            rgdLedCtl1.G = rgbLedCtl2.G = (byte)trackG.Value;
            rgdLedCtl1.B = rgbLedCtl2.B = (byte)trackB.Value;
        }

        private void trackR_Scroll(object sender, EventArgs e)
        {
            update_leds();
        }

        private void trackG_Scroll(object sender, EventArgs e)
        {
            update_leds();
        }

        private void trackB_Scroll(object sender, EventArgs e)
        {
            update_leds();
        }



        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}
    }

    public partial class RgbLedCtl : UserControl
    {
        public enum DisplayMode
        {
            SeparatedColors = 1,
            MixedColor = 2
        }

        private DisplayMode mode;
        private byte r, g, b;

        public void rgb(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            color_changed(true);
        }

        public DisplayMode Mode
        {
            get {return mode;}
            set {this.mode = value; color_changed(true);}
        }

        Brush brush, brush_r, brush_g, brush_b;
        Pen black_pen;

        public RgbLedCtl()
        {
            color_changed(false);
            black_pen = new Pen(Color.FromArgb(0, 0, 0));
            InitializeComponent();
        }

        void color_changed(bool force_invalidation)
        {
            brush = new SolidBrush(Color.FromArgb(r, g, b));
            brush_r = new SolidBrush(Color.FromArgb(r, 0, 0));
            brush_g = new SolidBrush(Color.FromArgb(0, g, 0));
            brush_b = new SolidBrush(Color.FromArgb(0, 0, b));
            if(force_invalidation) Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int x = ClientRectangle.X;
            int y = ClientRectangle.Y;
            int w = ClientRectangle.Width;
            int h = ClientRectangle.Height;
            switch (mode)
            {
                case DisplayMode.MixedColor:
                    pe.Graphics.FillEllipse(brush, new Rectangle(x, y, w - 1, h - 1));
                    break;

                case DisplayMode.SeparatedColors:

                    break;

            }
        }

        }

}
