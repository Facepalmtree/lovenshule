using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using Controller;
using Interface;

namespace GUI
{
    public partial class FrmAdmin : Form
    {
        ModelController controller;

        public FrmAdmin(ModelController controller)
        {
            InitializeComponent();

            this.controller = controller;
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            //Makes the winform run in fullscreen.
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;

            //Hides the curser
            //Commented out until it's needed.
            //Cursor.Hide();

            listView1.Hide();

            UpdateGui();
            

            #region highscore in listview

            //List<IEntry> ihighscores = controller.GetIEntries();

            //foreach(IEntry ientry in ihighscores)
            //{

                //string[] array = { Convert.ToInt32(ientry.entryID).ToString(),ientry.score.ToString(), ientry.playTime.ToString(), ientry.levelCount.ToString(), ientry.entryTime.ToShortDateString(), "billede"};
                //ListViewItem item = new ListViewItem(array);                
                //listView1.Items.Add(item);
            //}

            #endregion
        }

        public void UpdateGui()
        {
            //for highscore list A, containing todays highscores

            Label[] labels_score1 = { lblAscore1, lblAscore2, lblAscore3, lblAscore4, lblAscore5, lblAscore6, lblAscore7, lblAscore8, lblAscore9, lblAscore10 };
            Label[] labels_tid1 = { lblAtid1, lblAtid2, lblAtid3, lblAtid4, lblAtid5, lblAtid6, lblAtid7, lblAtid8, lblAtid9, lblAtid10 };
            Label[] labels_level1 = { lblAlevel1, lblAlevel2, lblALevel3, lblAlevel4, lblAlevel5, lblAlevel6, lblAlevel7, lblAlevel8, lblAlevel9, lblAlevel10 };
            Label[] labels_dato1 = { lblAdato1, lblAdato2, lblAdato3, lblAdato4, lblAdato5, lblAdato6, lblAdato7, lblAdato8, lblAdato9, lblAdato10 };
            PictureBox[] pictureboxes1 = { pbxA1, pbxA2, pbxA3, pbxA4, pbxA5, pbxA6, pbxA7, pbxA8, pbxA9, pbxA10 };
            Button[] buttons1 = { btnSletA1, btnSletA2, btnSletA3, btnSletA4, btnSletA5, btnSletA6, btnSletA7, btnSletA8, btnSletA9, btnSletA10 };
            
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
                            buttons1[i].Tag = ientry.entryID;
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
                labels_tid1[i].Text = "---";
                labels_level1[i].Text = "---";
                labels_dato1[i].Text = "---";
                pictureboxes1[i].Image = null;
                buttons1[i].Tag = -1;
                i++;
            }   

            //for highscore list B, containing alltime highscores

            Label[] labels_score2 = { lblBscore1, lblBscore2, lblBscore3, lblBscore4, lblBscore5, lblBscore6, lblBscore7, lblBscore8, lblBscore9, lblBscore10 };
            Label[] labels_tid2 = { lblBtid1, lblBtid2, lblBtid3, lblBtid4, lblBtid5, lblBtid6, lblBtid7, lblBtid8, lblBtid9, lblBtid10 };
            Label[] labels_level2 = { lblBlevel1, lblBlevel2, lblBlevel3, lblBlevel4, lblBlevel5, lblBlevel6, lblBlevel7, lblBlevel8, lblBlevel9, lblBlevel10 };
            Label[] labels_dato2 = { lblBdato1, lblBdato2, lblBdato3, lblBdato4, lblBdato5, lblBdato6, lblBdato7, lblBdato8, lblBdato9, lblBdato10 };
            PictureBox[] pictureboxes2 = { pbxB1, pbxB2, pbxB3, pbxB4, pbxB5, pbxB6, pbxB7, pbxB8, pbxB9, pbxB10 };
            Button[] buttons2 = { btnSletB1, btnSletB2, btnSletB3, btnSletB4, btnSletB5, btnSletB6, btnSletB7, btnSletB8, btnSletB9, btnSletB10 };

            i = 0;

            if (ihighscores.Count > 0)
            {
                foreach (IEntry ientry in ihighscores)
                {
                    if (i < 10)
                    {
                        labels_score2[i].Text = ientry.score.ToString();
                        labels_tid2[i].Text = ientry.playTime.ToString();
                        labels_level2[i].Text = ientry.levelCount.ToString();
                        labels_dato2[i].Text = ientry.entryTime.ToShortDateString();
                        pictureboxes2[i].Image = ientry.image;
                        buttons2[i].Tag = ientry.entryID;
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
                labels_tid2[i].Text = "---";
                labels_level2[i].Text = "---";
                labels_dato2[i].Text = "---";
                pictureboxes2[i].Image = null;
                buttons2[i].Tag = -1;
                i++;
            }                
            


        }

        #region button clicks

        private void btnSletA1_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletA1.Tag.ToString()));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletA2_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletA2.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletA3_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletA3.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletA4_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletA4.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletA5_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletA5.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletA6_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletA6.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletA7_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletA7.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletA8_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletA8.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletA9_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletA9.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletA10_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletA10.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletB1_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletB1.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletB2_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletB2.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletB3_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletB3.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletB4_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletB4.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletB5_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletB5.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletB6_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletB6.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletB7_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletB7.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletB8_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletB8.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletB9_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletB9.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        private void btnSletB10_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveEntry(Convert.ToInt32(btnSletB10.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
            UpdateGui();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                controller.ResetHighscore();
                UpdateGui();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                controller.ResetDailyHighscore();
                UpdateGui();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl");
            }

        }

        private void FrmAdmin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }


        //    private void ImageTest()
    //    {
            
    //        //listView1.View = View.LargeIcon;

    //        // imageList2 imageList2 = new ImageList();

    //        // imageList2.Images.Add(Bitmap.FromFile(@"C:/Calendar_scheduleHS.PNG")); 

    //        //listView1.LargeImageList = imageList2;

    //        ///------ string fileName = (@"C:/Calendar_scheduleHS.PNG");

    //        ///

    //        string fileName = comboBox1.Text;
    //        Bitmap image = new Bitmap(fileName);

    //        MemoryStream strem = new MemoryStream();image.Save(strem, ImageFormat.Bmp);
    //        imageList2.Images.Add(image);

    //        pictureBox2.Image = imageList2.Images[0];

    //        // imageList2.Images.Add(bmp);

    //        // listView1.LargeImageList = imageList2.Images[0];

    //        listView1.LargeImageList = imageList2;

    //        ListViewItem item1 = new ListViewItem("");
    //        item1.SubItems.Add("");

    //        item1.SubItems.Add("");
    //        item1.ImageIndex = 0; 

    //        listView1.Items.AddRange(

    //        new ListViewItem[ {item1} ]

    }

}
