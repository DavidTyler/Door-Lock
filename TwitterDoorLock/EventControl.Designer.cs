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
            ((System.ComponentModel.ISupportInitialize)(this.webStatusIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // webStatusIcon
            // 
            this.webStatusIcon.Image = global::TwitterDoorLock.Properties.Resources.Network_Server;
            this.webStatusIcon.Location = new System.Drawing.Point(3, 3);
            this.webStatusIcon.Name = "webStatusIcon";
            this.webStatusIcon.Size = new System.Drawing.Size(64, 64);
            this.webStatusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.webStatusIcon.TabIndex = 2;
            this.webStatusIcon.TabStop = false;
            // 
            // EventControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webStatusIcon);
            this.Name = "EventControl";
            this.Size = new System.Drawing.Size(150, 517);
            ((System.ComponentModel.ISupportInitialize)(this.webStatusIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox webStatusIcon;
    }
}
