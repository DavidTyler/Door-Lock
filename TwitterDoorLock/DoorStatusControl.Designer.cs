namespace TwitterDoorLock
{
    partial class DoorStatusControl
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
            this.lockStatus = new System.Windows.Forms.Label();
            this.webStatus = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lockStatus
            // 
            this.lockStatus.BackColor = System.Drawing.Color.Maroon;
            this.lockStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lockStatus.ForeColor = System.Drawing.Color.White;
            this.lockStatus.Location = new System.Drawing.Point(3, 0);
            this.lockStatus.Name = "lockStatus";
            this.lockStatus.Size = new System.Drawing.Size(220, 111);
            this.lockStatus.TabIndex = 1;
            this.lockStatus.Text = "[lock status]";
            this.lockStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // webStatus
            // 
            this.webStatus.BackColor = System.Drawing.Color.Maroon;
            this.webStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webStatus.ForeColor = System.Drawing.Color.White;
            this.webStatus.Location = new System.Drawing.Point(229, 0);
            this.webStatus.Name = "webStatus";
            this.webStatus.Size = new System.Drawing.Size(220, 111);
            this.webStatus.TabIndex = 2;
            this.webStatus.Text = "[web status]";
            this.webStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time
            // 
            this.time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(124)))), ((int)(((byte)(155)))));
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.ForeColor = System.Drawing.Color.White;
            this.time.Location = new System.Drawing.Point(455, 0);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(518, 111);
            this.time.TabIndex = 3;
            this.time.Text = "[time]";
            this.time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DoorStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.time);
            this.Controls.Add(this.webStatus);
            this.Controls.Add(this.lockStatus);
            this.Name = "DoorStatusControl";
            this.Size = new System.Drawing.Size(976, 567);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lockStatus;
        private System.Windows.Forms.Label webStatus;
        private System.Windows.Forms.Label time;
    }
}
