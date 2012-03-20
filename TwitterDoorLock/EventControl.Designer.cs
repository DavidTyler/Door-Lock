namespace TwitterDoorLock
{
    partial class EventControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webStatusIcon = new System.Windows.Forms.PictureBox();
            this.senseStatusIcon = new System.Windows.Forms.PictureBox();
            this.twitterStatusIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.webStatusIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.senseStatusIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twitterStatusIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // webStatusIcon
            // 
            this.webStatusIcon.Image = global::TwitterDoorLock.Properties.Resources.Network_Server;
            this.webStatusIcon.Location = new System.Drawing.Point(0, 140);
            this.webStatusIcon.Name = "webStatusIcon";
            this.webStatusIcon.Size = new System.Drawing.Size(64, 64);
            this.webStatusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.webStatusIcon.TabIndex = 2;
            this.webStatusIcon.TabStop = false;
            // 
            // senseStatusIcon
            // 
            this.senseStatusIcon.Image = global::TwitterDoorLock.Properties.Resources.Light_Bulb;
            this.senseStatusIcon.Location = new System.Drawing.Point(0, 70);
            this.senseStatusIcon.Name = "senseStatusIcon";
            this.senseStatusIcon.Size = new System.Drawing.Size(64, 64);
            this.senseStatusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.senseStatusIcon.TabIndex = 1;
            this.senseStatusIcon.TabStop = false;
            // 
            // twitterStatusIcon
            // 
            this.twitterStatusIcon.Image = global::TwitterDoorLock.Properties.Resources.Um___;
            this.twitterStatusIcon.Location = new System.Drawing.Point(0, 0);
            this.twitterStatusIcon.Name = "twitterStatusIcon";
            this.twitterStatusIcon.Size = new System.Drawing.Size(64, 64);
            this.twitterStatusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.twitterStatusIcon.TabIndex = 0;
            this.twitterStatusIcon.TabStop = false;
            // 
            // EventControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webStatusIcon);
            this.Controls.Add(this.senseStatusIcon);
            this.Controls.Add(this.twitterStatusIcon);
            this.Name = "EventControl";
            this.Size = new System.Drawing.Size(150, 517);
            ((System.ComponentModel.ISupportInitialize)(this.webStatusIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.senseStatusIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twitterStatusIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox twitterStatusIcon;
        private System.Windows.Forms.PictureBox senseStatusIcon;
        private System.Windows.Forms.PictureBox webStatusIcon;
    }
}
