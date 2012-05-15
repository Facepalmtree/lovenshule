using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Interface;

namespace GUI
{
    class TransparentAnimatedFuck : Control
    {
        private List<int> animStart = new List<int>();
        private List<int> animEnd = new List<int>();
        private List<Image> Image = new List<Image>();
        int animations;
        int animStep = 0;
        int animation = 0;
        int type;

        public TransparentAnimatedFuck(int type)
        {
            this.type = type;
        }

        public void AddAnimationData(int animStart, int animEnd)
        {
            animations+=1;
            this.animStart.Add(animStart);
            this.animEnd.Add(animEnd);
        }

        public void AddImage(Image image)
        {
            this.Image.Add(image);
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
                        //animation = 2;
                        //animStep = animStart[animation];
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
