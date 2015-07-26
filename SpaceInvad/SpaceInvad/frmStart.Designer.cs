namespace SpaceInvad
{
    partial class frmStart
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
            this.components = new System.ComponentModel.Container();
            this.timerStartText = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerCredits = new System.Windows.Forms.Timer(this.components);
            this.pancredits = new System.Windows.Forms.Panel();
            this.lblcredits = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pancredits.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerStartText
            // 
            this.timerStartText.Enabled = true;
            this.timerStartText.Interval = 700;
            this.timerStartText.Tick += new System.EventHandler(this.timerStartText_Tick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(554, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "PRESS ENTER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-4, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "(C) Infiniteshroom 2011\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SpaceInvad.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(553, 228);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timerCredits
            // 
            this.timerCredits.Interval = 350;
            this.timerCredits.Tick += new System.EventHandler(this.timerCredits_Tick);
            // 
            // pancredits
            // 
            this.pancredits.Controls.Add(this.lblcredits);
            this.pancredits.Location = new System.Drawing.Point(3, 267);
            this.pancredits.Name = "pancredits";
            this.pancredits.Size = new System.Drawing.Size(550, 95);
            this.pancredits.TabIndex = 3;
            this.pancredits.Visible = false;
            // 
            // lblcredits
            // 
            this.lblcredits.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcredits.ForeColor = System.Drawing.Color.White;
            this.lblcredits.Location = new System.Drawing.Point(9, 13);
            this.lblcredits.Name = "lblcredits";
            this.lblcredits.Size = new System.Drawing.Size(527, 503);
            this.lblcredits.TabIndex = 3;
            this.lblcredits.Text = "Created By Mark J. Lang\r\n\r\n\r\n\r\n\r\n\r\nProgrammed By Mark J. Lang\r\n\r\n\r\n\r\n\r\nSprite Art" +
                "work By Taito/Midway\r\n\r\n\r\n\r\nThanks for playing\r\n\r\n\r\n\r\nPS. Taito don\'t sue me...P" +
                "lease?\r\n";
            this.lblcredits.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(551, 399);
            this.Controls.Add(this.pancredits);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "frmStart";
            this.Text = "GDI+ Invaders";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStart_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pancredits.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerStartText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerCredits;
        private System.Windows.Forms.Panel pancredits;
        private System.Windows.Forms.Label lblcredits;
    }
}