using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TwitterDoorLock
{
    public partial class DoorStatusControl : UserControl
    {
        public DoorStatusControl()
        {
            InitializeComponent();
            countThread = new Thread(new ThreadStart(Counter));
            countThread.Start();
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            countThread.Abort();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            lockStatus.Height = this.Height;
            webStatus.Height = this.Height;
            time.Height = this.Height;

            lockStatus.Width = this.Width / 4;
            webStatus.Width = this.Width / 4;
            time.Width = this.Width / 2;

            lockStatus.Location = new Point(0, 0);
            webStatus.Location = new Point(this.Width / 4, 0);
            time.Location = new Point(this.Width / 2, 0);
        }

        private bool doResetTime = false;
        Thread countThread;
        private void Counter()
        {
            int seconds = 0;
            int minutes = 0;
            int hours = 0;

            while (true)
            {
                if (doResetTime)
                {
                    seconds = 0;
                    minutes = 0;
                    hours = 0;
                    doResetTime = false;
                }

                seconds++;

                if (seconds >= 60)
                {
                    seconds -= 60;
                    minutes++;
                }

                if (minutes >= 60)
                {
                    minutes -= 60;
                    hours++;
                }

                string tMinutes = minutes.ToString().Length > 1? minutes.ToString() : "0" + minutes.ToString();
                string tSeconds = seconds.ToString().Length > 1 ? seconds.ToString() : "0" + seconds.ToString();

                time.SetPropertyThreadSafe(() => time.Text, hours + ":" + tMinutes + ":" + tSeconds);

                Thread.Sleep(1000);
            }
        }

        public void ResetTime()
        {
            doResetTime = true;
        }

        public bool Unlocked
        {
            set
            {
                ResetTime();
                lockStatus.BackColor = value ? StudentRndColors.Green : StudentRndColors.Red;
                lockStatus.Text = value ? "Door unlocked" : "Door locked";
            }
        }

        public bool Open
        {
            set
            {
                ResetTime();
                webStatus.BackColor = value ? StudentRndColors.Green : StudentRndColors.Red;
                webStatus.Text = value ? "Website says Open" : "Website says Closed";
            }
        }

        private void DoorStatusControl_Load(object sender, EventArgs e)
        {
            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
        }
    }
}
