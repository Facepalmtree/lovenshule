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
            this.lblScore = new System.Windows.Forms.Label();
            this.healthBarM = new System.Windows.Forms.PictureBox();
            this.healthBarR = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.healthBarM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBarR)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.ForeColor = System.Drawing.Color.Black;
            this.lblScore.Location = new System.Drawing.Point(12, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(13, 13);
            this.lblScore.TabIndex = 25;
            this.lblScore.Text = "0";
            // 
            // healthBarM
            // 
            this.healthBarM.Image = global::GUI.Properties.Resources.Unavngivet4;
            this.healthBarM.Location = new System.Drawing.Point(12, 25);
            this.healthBarM.Name = "healthBarM";
            this.healthBarM.Size = new System.Drawing.Size(200, 20);
            this.healthBarM.TabIndex = 26;
            this.healthBarM.TabStop = false;
            // 
            // healthBarR
            // 
            this.healthBarR.Image = global::GUI.Properties.Resources.Pic6;
            this.healthBarR.Location = new System.Drawing.Point(12, 68);
            this.healthBarR.Name = "healthBarR";
            this.healthBarR.Size = new System.Drawing.Size(200, 20);
            this.healthBarR.TabIndex = 27;
            this.healthBarR.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1362, 742);
            this.Controls.Add(this.healthBarR);
            this.Controls.Add(this.healthBarM);
            this.Controls.Add(this.lblScore);
            this.ForeColor = System.Drawing.Color.Cornsilk;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.healthBarM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBarR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.PictureBox healthBarM;
        private System.Windows.Forms.PictureBox healthBarR;

    }
}

