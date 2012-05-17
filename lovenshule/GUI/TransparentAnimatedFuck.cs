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
        private Color brushColor = Color.Transparent;
        private Color fillColor = Color.Transparent;
        private int opacity = 100;
        private float lineThick = 1.0f;

        public TransparentAnimatedFuck()
        {
            
        }

        public TransparentAnimatedFuck(int type, int x, int y, int Width, int Height)
        {
            this.type = type;
            Location = new System.Drawing.Point(x, y);
            Size = new System.Drawing.Size(Width, Height);

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            //Set style for double buffering
            SetStyle(ControlStyles.DoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            //Set the default backcolor
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
                this.Invalidate();
            }
        }

        public float LineThick
        {
            get
            {
                return this.lineThick;
            }
            set
            {
                this.lineThick = value;
                this.Invalidate();
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

            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            RectangleF r = new RectangleF(0.0f, 0.0f, (float)this.Width, (float)this.Height);
            float cx = r.Width - 1;
            float cy = r.Height - 1;
            float offset = 0.4f;

            Pen pen = new Pen(new SolidBrush(Color.Black), lineThick);
            pen.Alignment = PenAlignment.Center;
            SolidBrush brush = new SolidBrush(Color.White);
            SolidBrush bckgnd = new SolidBrush(Color.Green);

            // Creates a path to draw graphics
            GraphicsPath path = new GraphicsPath();

            
            //Add a rectangle to the path. This will be the control background.
            path.AddRectangle(r);

            //Creates a region area for the background painting
            this.Region = new Region(path);

            //Paint the control background
            g.FillRegion(bckgnd, this.Region);

            e.Graphics.DrawImage(Properties.Resources.Unavngivet4, 0, 0, this.Width, this.Height);
            if (Image.Count > 0)
                e.Graphics.DrawImage(Image[animStep], 0, 0, this.Width, this.Height);

            pen.Dispose();
            brush.Dispose();
            this.Region.Dispose();
            path.Dispose();
        }
    }
}
