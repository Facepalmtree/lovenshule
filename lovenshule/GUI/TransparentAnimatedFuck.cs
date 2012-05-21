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
        private int moleWidth;
        private int moleHeight;
        private Color brushColor = Color.Transparent;
        private Color fillColor = Color.Transparent;
        private Image background;
        private float lineThick = 1.0f;

        public TransparentAnimatedFuck()
        {
            
        }

        public TransparentAnimatedFuck(int type, int x, int y, int Width, int Height, int moleWidth, int moleHeight)
        {
            this.type = type;
            this.moleHeight = moleHeight;
            this.moleWidth = moleWidth;
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
            if (Location.X == 83 && Location.Y==84)
            {
                background = Properties.Resources.Pic1;
            }
            if (Location.X == 83 && Location.Y == 284)
            {
                background = Properties.Resources.Pic2;
            }
            if (Location.X == 83 && Location.Y == 484)
            {
                background = Properties.Resources.Pic3;
            }


            if (Location.X == 283 && Location.Y == 84)
            {
                background = Properties.Resources.Pic4;
            }
            if (Location.X == 283 && Location.Y == 284)
            {
                background = Properties.Resources.Pic5;
            }
            if (Location.X == 283 && Location.Y == 484)
            {
                background = Properties.Resources.Pic6;
            }


            if (Location.X == 483 && Location.Y == 84)
            {
                background = Properties.Resources.Pic7;
            }
            if (Location.X == 483 && Location.Y == 284)
            {
                background = Properties.Resources.Pic8;
            }
            if (Location.X == 483 && Location.Y == 484)
            {
                background = Properties.Resources.Pic9;
            }


            if (Location.X == 683 && Location.Y == 84)
            {
                background = Properties.Resources.Pic10;
            }
            if (Location.X == 683 && Location.Y == 284)
            {
                background = Properties.Resources.Pic11;
            }
            if (Location.X == 683 && Location.Y == 484)
            {
                background = Properties.Resources.Pic12;
            }


            if (Location.X == 883 && Location.Y == 84)
            {
                background = Properties.Resources.Pic13;
            }
            if (Location.X == 883 && Location.Y == 284)
            {
                background = Properties.Resources.Pic14;
            }
            if (Location.X == 883 && Location.Y == 484)
            {
                background = Properties.Resources.Pic15;
            }


            if (Location.X == 1083 && Location.Y == 84)
            {
                background = Properties.Resources.Pic16;
            }
            if (Location.X == 1083 && Location.Y == 284)
            {
                background = Properties.Resources.Pic17;
            }
            if (Location.X == 1083 && Location.Y == 484)
            {
                background = Properties.Resources.Pic18;
            }
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









        public void SetAnimation(int animation)
        {
            this.animation = animation;
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

        public bool AnimationStep()
        {
            int lastAnimStep = animStep;
            animStep += 1;
            if (animStep > animEnd[animation])
            {
                if (animation == 0 || animation == 1 || animation ==2)
                    animStep = animEnd[animation];
            }

            //if animation  number has not changed, return false, otherwise return true.
            if (lastAnimStep == animStep)
                return false;
            else
                return true;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            RectangleF r = new RectangleF(0.0f, 0.0f, (float)this.Width, (float)this.Height);
            float cx = r.Width - 1;
            float cy = r.Height - 1;

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

            e.Graphics.DrawImage(this.background, 0, 0, this.Width, this.Height);
            if (Image.Count > 0)
                e.Graphics.DrawImage(Image[animStep], (this.Width - this.moleWidth) / 2, (this.Height - this.moleHeight) / 2, this.moleWidth, this.moleHeight);

            pen.Dispose();
            brush.Dispose();
            this.Region.Dispose();
            path.Dispose();
        }
    }
}
