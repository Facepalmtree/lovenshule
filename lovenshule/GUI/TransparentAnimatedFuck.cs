using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Interface;

namespace GUI
{
    class TransparentAnimatedFuck : Control
    {
        private List<int> animStart = new List<int>();
        private List<int> animEnd = new List<int>();
        private List<Bitmap> Image = new List<Bitmap>();
        int animations;
        int animStep = 0;
        int animation = 0;
        int type;
        private Image Hej;

        public Image SetHej
        {
            get
            {
                return Hej;
            }
            set
            {
                Hej = value;
            }
        }


        public TransparentAnimatedFuck()
        {
            
        }

        public TransparentAnimatedFuck(int type, int x, int y, int Width, int Height)
        {
            this.type = type;
            Location = new System.Drawing.Point(x, y);
            Size = new System.Drawing.Size(Width, Height);
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
                    if (animation == 1)
                    {
                        animStep = animStart[animation];
                    }
                }
            }
        }
        
        public void TransPictureBox()
        {
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if(Image.Count>0)
                pe.Graphics.DrawImage(Image[0], 0, 0, this.Width, this.Height);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
    }
}
