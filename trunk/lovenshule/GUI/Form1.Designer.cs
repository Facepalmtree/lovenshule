namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblScore = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.healthBarR = new System.Windows.Forms.PictureBox();
            this.healthBarM = new System.Windows.Forms.PictureBox();
            this.lblBonusCount = new System.Windows.Forms.Label();
            this.PicBNextLevel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBarR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBarM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBNextLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Celestia Redux", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.Red;
            this.lblScore.Location = new System.Drawing.Point(11, 3);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(30, 39);
            this.lblScore.TabIndex = 25;
            this.lblScore.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::GUI.Properties.Resources.Star_løve1_small;
            this.pictureBox1.Location = new System.Drawing.Point(600, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // healthBarR
            // 
            this.healthBarR.Image = global::GUI.Properties.Resources.hp_bar_liv;
            this.healthBarR.Location = new System.Drawing.Point(18, 48);
            this.healthBarR.Name = "healthBarR";
            this.healthBarR.Size = new System.Drawing.Size(200, 20);
            this.healthBarR.TabIndex = 27;
            this.healthBarR.TabStop = false;
            // 
            // healthBarM
            // 
            this.healthBarM.Image = ((System.Drawing.Image)(resources.GetObject("healthBarM.Image")));
            this.healthBarM.Location = new System.Drawing.Point(12, 45);
            this.healthBarM.Name = "healthBarM";
            this.healthBarM.Size = new System.Drawing.Size(212, 26);
            this.healthBarM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.healthBarM.TabIndex = 26;
            this.healthBarM.TabStop = false;
            // 
            // lblBonusCount
            // 
            this.lblBonusCount.AutoSize = true;
            this.lblBonusCount.BackColor = System.Drawing.Color.Transparent;
            this.lblBonusCount.Font = new System.Drawing.Font("Celestia Redux", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonusCount.ForeColor = System.Drawing.Color.Red;
            this.lblBonusCount.Location = new System.Drawing.Point(666, 210);
            this.lblBonusCount.Name = "lblBonusCount";
            this.lblBonusCount.Size = new System.Drawing.Size(30, 39);
            this.lblBonusCount.TabIndex = 31;
            this.lblBonusCount.Text = "0";
            this.lblBonusCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBonusCount.Visible = false;
            // 
            // PicBNextLevel
            // 
            this.PicBNextLevel.BackColor = System.Drawing.Color.Transparent;
            this.PicBNextLevel.Cursor = System.Windows.Forms.Cursors.Default;
            this.PicBNextLevel.Image = ((System.Drawing.Image)(resources.GetObject("PicBNextLevel.Image")));
            this.PicBNextLevel.Location = new System.Drawing.Point(0, 0);
            this.PicBNextLevel.Name = "PicBNextLevel";
            this.PicBNextLevel.Size = new System.Drawing.Size(1378, 780);
            this.PicBNextLevel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBNextLevel.TabIndex = 32;
            this.PicBNextLevel.TabStop = false;
            this.PicBNextLevel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1362, 742);
            this.Controls.Add(this.PicBNextLevel);
            this.Controls.Add(this.lblBonusCount);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.healthBarR);
            this.Controls.Add(this.healthBarM);
            this.Controls.Add(this.lblScore);
            this.ForeColor = System.Drawing.Color.Cornsilk;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBarR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBarM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBNextLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.PictureBox healthBarM;
        private System.Windows.Forms.PictureBox healthBarR;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblBonusCount;
        private System.Windows.Forms.PictureBox PicBNextLevel;

    }
}

