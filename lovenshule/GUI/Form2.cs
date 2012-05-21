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

            this.BackgroundImage = Properties.Resources.background;                       

            UpdateGui();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form webcam = new FrmWebcam(controller);
            //this.Close();
            webcam.ShowDialog();
            controller.NewPlayer((Image)Properties.Resources.background);
            if (controller.GetCurrentPlayer() != null)
            {
                Form game = new Form1(controller);
                game.ShowDialog();
            }
            else
            {
                this.Show();
            }
            this.Close();
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
                    labels_score1[i].Text = "---";
                    labels_tid1[i].Text = "---";
                    labels_level1[i].Text = "---";
                    labels_dato1[i].Text = "---";
                    pictureboxes1[i].Image = null;                    
                    i++;
                }

            }

            //for highscore list B, containing alltime highscores

            Label[] labels_score2 = { lblBscore1, lblBscore2, lblBscore3, lblBscore4, lblBscore5, lblBscore6, lblBscore7, lblBscore8, lblBscore9, lblBscore10 };
            Label[] labels_tid2 = { lblBtid1, lblBtid2, lblBtid3, lblBtid4, lblBtid5, lblBtid6, lblBtid7, lblBtid8, lblBtid9, lblBtid10 };
            Label[] labels_level2 = { lblBlevel1, lblBlevel2, lblBlevel3, lblBlevel4, lblBlevel5, lblBlevel6, lblBlevel7, lblBlevel8, lblBlevel9, lblBlevel10 };
            Label[] labels_dato2 = { lblBdato1, lblBdato2, lblBdato3, lblBdato4, lblBdato5, lblBdato6, lblBdato7, lblBdato8, lblBdato9, lblBdato10 };
            PictureBox[] pictureboxes2 = { pbxB1, pbxB2, pbxB3, pbxB4, pbxB5, pbxB6, pbxB7, pbxB8, pbxB9, pbxB10 };            

            i = 0;

            if (ihighscores.Count > 0)
            {
                foreach (IEntry ientry in ihighscores)
                {
                    if (i < 10)
                    {
                        labels_score1[i].Text = ientry.score.ToString();
                        labels_tid1[i].Text = ientry.playTime.ToString();
                        labels_level1[i].Text = ientry.levelCount.ToString();
                        labels_dato1[i].Text = ientry.entryTime.ToShortDateString();
                        pictureboxes1[i].Image = ientry.image;                        
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
                    labels_score2[i].Text = "---";
                    labels_tid2[i].Text = "---";
                    labels_level2[i].Text = "---";
                    labels_dato2[i].Text = "---";
                    pictureboxes2[i].Image = null;                    
                    i++;
                }
            }
        }
    }
}
