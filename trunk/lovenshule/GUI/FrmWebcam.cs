using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AForge.Controls;
using AForge.Video.DirectShow;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using Controller;



namespace GUI
{
    public partial class FrmWebcam : Form
    {
        FilterInfoCollection videoDevices;

        List<System.Windows.Forms.PictureBox> buttonsImages = new List<System.Windows.Forms.PictureBox>();

        ModelController controller;

        Image saveImage = null;

        public FrmWebcam(ModelController controller)
        {
            InitializeComponent();
            this.controller = controller;           
        }

        private void FrmWebcam_Load(object sender, EventArgs e)
        {
            //background
            this.BackgroundImage = Properties.Resources.background;

            //webcam stream
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            
            videoSourcePlayer1.VideoSource = videoSource;

            videoSourcePlayer1.Size = new Size(800, 600);

            this.videoSourcePlayer1.Start();

            //snapshot button
            buttonsImages.Add(new System.Windows.Forms.PictureBox());
            buttonsImages[0].Size = Properties.Resources.kamera.Size;
            buttonsImages[0].Image = Properties.Resources.kamera;
            buttonsImages[0].Location = new Point(1000, 300);
            buttonsImages[0].Click +=new EventHandler(Snapshot);
            buttonsImages[0].BackColor = Color.Transparent;

            Controls.Add(buttonsImages[0]);

            //continue button
            buttonsImages.Add(new System.Windows.Forms.PictureBox());
            buttonsImages[1].Size = Properties.Resources.flueben.Size;
            buttonsImages[1].Image = Properties.Resources.flueben;
            buttonsImages[1].Location = new Point(950, 560);
            buttonsImages[1].Click +=new EventHandler(Continue);
            buttonsImages[1].BackColor = Color.Transparent;

            Controls.Add(buttonsImages[1]);

            //continue button
            buttonsImages.Add(new System.Windows.Forms.PictureBox());
            buttonsImages[2].Size = Properties.Resources.cross.Size;
            buttonsImages[2].Image = Properties.Resources.cross;
            buttonsImages[2].Location = new Point(1150, 560);
            buttonsImages[2].Click += new EventHandler(Cancel);
            buttonsImages[2].BackColor = Color.Transparent;

            Controls.Add(buttonsImages[2]);

            
        }

        public void Snapshot(object sender, EventArgs e)
        {
            Bitmap image1 = videoSourcePlayer1.GetCurrentVideoFrame();


            Image previewImage = ResizeImageToPreview(image1);

            saveImage = ResizeImageToSave(image1);

            pictureBox1.Image = previewImage;
        }

        public void Continue(object sender, EventArgs e)
        {
            try
            {
                //if picture not taken, take and continue.
                if (saveImage == null)
                {
                    Snapshot(sender, e);
                }
                controller.NewPlayer(saveImage);
                this.videoSourcePlayer1.SignalToStop();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Kunne ikke oprette ny spiller, Fejl");
            }

        }

        public void Cancel(object sender, EventArgs e)
        {
            this.videoSourcePlayer1.SignalToStop();
            controller.ResetPlayer();
            this.Close();
        }

        public Image ResizeImageToPreview(Image image)
        {
            //the new size
            int resizedW = (int)(360);
            int resizedH = (int)(240);

            //create a new Bitmap the size of the new image
            Bitmap tempimage = new Bitmap(resizedW, resizedH);
            //create a new graphic from the Bitmap
            Graphics graphic = Graphics.FromImage((Image)tempimage);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //draw the newly resized image
            graphic.DrawImage(image, 0, 0, resizedW, resizedH);
            //dispose and free up the resources
            graphic.Dispose();
            //return the image
            return (Image)tempimage;
        }

        public Image ResizeImageToSave(Image image)
        {
        
            //the new size
            int resizedW = (int)(160);
            int resizedH = (int)(120);

            //create a new Bitmap the size of the new image
            Bitmap tempimage = new Bitmap(resizedW, resizedH);
            //create a new graphic from the Bitmap
            Graphics graphic = Graphics.FromImage((Image)tempimage);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //draw the newly resized image
            graphic.DrawImage(image, 0, 0, resizedW, resizedH);
            //dispose and free up the resources
            graphic.Dispose();
            //return the image
            return (Image)tempimage;
        
        }
    }
}
