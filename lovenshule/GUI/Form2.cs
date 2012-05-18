using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Controller;
using Interface;

namespace GUI
{
    public partial class Form2 : Form
    {
        ModelController controller;

        public Form2()
        {
            InitializeComponent();

            controller = new ModelController();

            UpdateGui();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form webcam = new FrmWebcam(controller);
            this.Hide();
            webcam.ShowDialog();            
            if (controller.GetCurrentPlayer() != null)
            {
                Form game = new Form1(controller);
                game.ShowDialog();
            }     
        }

        public void UpdateGui()
        {
            //for highscore list A, containing todays highscores

            Label[] labels_score1 = { lblAscore1, lblAscore2, lblAscore3, lblAscore4, lblAscore5, lblAscore6, lblAscore7, lblAscore8, lblAscore9, lblAscore10 };
            Label[] labels_tid1 = { lblAtid1, lblAtid2, lblAtid3, lblAtid4, lblAtid5, lblAtid6, lblAtid7, lblAtid8, lblAtid9, lblAtid10 };
            Label[] labels_level1 = { lblAlevel1, lblAlevel2, lblALevel3, lblAlevel4, lblAlevel5, lblAlevel6, lblAlevel7, lblAlevel8, lblAlevel9, lblAlevel10 };
            Label[] labels_dato1 = { lblAdato1, lblAdato2, lblAdato3, lblAdato4, lblAdato5, lblAdato6, lblAdato7, lblAdato8, lblAdato9, lblAdato10 };
            PictureBox[] pictureboxes1 = { pbxA1, pbxA2, pbxA3, pbxA4, pbxA5, pbxA6, pbxA7, pbxA8, pbxA9, pbxA10 };            

            List<IEntry> ihighscores = controller.GetIEntries();

            int i = 0;

            if (ihighscores.Count > 0)
            {
                foreach (IEntry ientry in ihighscores)
                {
                    if (i < 10)
                    {
                        if (ientry.entryTime.Date == DateTime.Now.Date)
                        {
                            labels_score1[i].Text = ientry.score.ToString();
                            labels_tid1[i].Text = ientry.playTime.ToString();
                            labels_level1[i].Text = ientry.levelCount.ToString();
                            labels_dato1[i].Text = ientry.entryTime.ToShortDateString();
                            pictureboxes1[i].Image = ientry.image;                           
                        }
                    }
                    else
                    {
                        break;
                    }
                    i++;
                }
            }
            else
            {
                while (i < 10)
                {
                    labels_score1[i].Text = "Tom";
                    labels_tid1[i].Text = "Tom";
                    labels_level1[i].Text = "Tom";
                    labels_dato1[i].Text = "Tom";
                    pictureboxes1[i].Image = null;                    
                    i++;
                }

            }
        }
    }
}
