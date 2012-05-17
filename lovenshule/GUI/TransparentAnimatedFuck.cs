using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

using Interface;

namespace GUI
{
    class TransparentAnimatedFuck : Control
    {
        public List<int> animStart = new List<int>();
        public List<int> animEnd = new List<int>();
        public List<Bitmap> Image = new List<Bitmap>();
        public int animations;
        public int animStep = 0;
        public int animation = 0;
        public int type;
        private Color fillColor = Color.White;
        private int opacity = 100;
        private int alpha;

        public TransparentAnimatedFuck()
        {
            
        }

        public TransparentAnimatedFuck(int type, int x, int y, int Width, int Height)
        {
            this.type = type;
            Location = new System.Drawing.Point(x, y);
            Size = new System.Drawing.Size(Width, Height);

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            this.BackColor = Color.Transparent;
        }





        public Color FillColor
        {
            get
            {
                return this.fillColor;
            }
            set
            {
                this.fillColor = value;
                if (this.Parent != null) Parent.Invalidate(this.Bounds, true);
            }
        }

        public int Opacity
        {
            get
            {
                if (opacity > 100) { opacity = 100; }
                else if (opacity < 1) { opacity = 1; }
                return this.opacity;
            }
            set
            {
                this.opacity = value;
                if (this.Parent != null) Parent.Invalidate(this.Bounds, true);
            }
        }












        public void AddAnimationData(int animStart, int animEnd)
        {
            animations+=1;
            this.animStart.Add(animStart);
            this.animEnd.Add(animEnd);
        }

        public void AddImage(Bitmap Image)
        {
            this.Image.Add(Image);
        }

        public void AnimationStep()
        {
            animStep += 1;
            if (animStep > animEnd[animation])
            {
                if (type == 1)
                {
                    if (animation == 0)
                    {
                        animStep = animStart[animation];
                    }
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            /*e.Graphics.DrawImage(Properties.Resources.Unavngivet4, 0, 0, this.Width, this.Height);
            if (Image.Count > 0)
                e.Graphics.DrawImage(Image[animStep], 0, 0, this.Width, this.Height);*/

            Graphics g = e.Graphics;
            Rectangle bounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            Color frmColor = this.Parent.BackColor;
            Brush brushColor;
            Brush bckColor;

            alpha = (opacity * 255) / 100;


            Color color = fillColor;
            brushColor = new SolidBrush(Color.FromArgb(alpha, color));
            bckColor = new SolidBrush(Color.FromArgb(alpha, this.BackColor));


            Pen pen = new Pen(this.ForeColor);

            g.FillEllipse(new SolidBrush(Color.FromArgb(1, Color.White)), bounds);

            g.DrawEllipse(pen, bounds);
            g.DrawImage(Properties.Resources.Unavngivet4, 0, 0, this.Width, this.Height);
            if (Image.Count > 0)
                g.DrawImage(Image[animStep], 0, 0, this.Width, this.Height);

            pen.Dispose();
            brushColor.Dispose();
            bckColor.Dispose();
            g.Dispose();
            base.OnPaint(e);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = 0x20;
                return cp;
            }
        }
    }
}
