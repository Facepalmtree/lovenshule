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

            //Makes the winform run in fullscreen.
            //this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            //Hides the curser
            //Commented out until it's needed.
            //Cursor.Hide();
        }

        public void UpdateGui()
        {
            //for highscore list A, containing todays highscores

            controller.LoadHighscore();

            Label[] labels_score1 = { lblAscore1, lblAscore2, lblAscore3, lblAscore4, lblAscore5, lblAscore6, lblAscore7, lblAscore8, lblAscore9, lblAscore10 };
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
                            labels_score1[i].TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                            pictureboxes1[i].Image = ientry.image;
                            i++;
                        }
                    }
                    else
                    {
                        break;
                    }
                    
                }
            }
            
            
            while (i < 10)
            {
                labels_score1[i].Text = "---";
                pictureboxes1[i].Image = null;                    
                i++;
            }

            

            //for highscore list B, containing alltime highscores

            Label[] labels_score2 = { lblBscore1, lblBscore2, lblBscore3, lblBscore4, lblBscore5, lblBscore6, lblBscore7, lblBscore8, lblBscore9, lblBscore10 };
            PictureBox[] pictureboxes2 = { pbxB1, pbxB2, pbxB3, pbxB4, pbxB5, pbxB6, pbxB7, pbxB8, pbxB9, pbxB10 };            

            i = 0;

            if (ihighscores.Count > 0)
            {
                foreach (IEntry ientry in ihighscores)
                {
                    if (i < 10)
                    {
                        labels_score2[i].Text = ientry.score.ToString();
                        pictureboxes2[i].Image = ientry.image;
                        i++;
                    }
                    else
                    {
                        break; 
                    }
                }
            }
            
            
            while (i < 10)
            {
                labels_score2[i].Text = "---";                    
                pictureboxes2[i].Image = null;                    
                i++;
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UpdateGui();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form webcam = new FrmWebcam(controller);
            webcam.ShowDialog();

            if (controller.GetCurrentPlayer() != null)
            {
                Form game = new Form1(controller);
                game.ShowDialog();
            }
            else
            {
                this.Show();
            }
            UpdateGui();
        }
        

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space)
            {
                Form admin = new FrmAdmin(controller);
                this.Hide();
                admin.ShowDialog();
                this.Show();
                UpdateGui();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
