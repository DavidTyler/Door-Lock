using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwitterDoorLock
{
    public enum LogEntryType{
        Lock,
        Unlock,
        Toggle,
        Error
    }
    public partial class LogControl : UserControl
    {
        private List<Tuple<string, LogEntryType>> entries = new List<Tuple<string, LogEntryType>>();
        public LogControl()
        {
            InitializeComponent();
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);

            this.Controls.Clear();
            int i = entries.Count - 1;
            foreach (Tuple<string, LogEntryType> entry in entries)
            {
                Label l = new Label();
                l.Parent = this;
                l.Height = 25;
                l.Width = this.Width;
                l.BackColor = GetEntryColor(entry.Item2);
                if (l.BackColor.GetBrightness() < 50)
                {
                    l.ForeColor = Color.White;
                }
                l.Text = entry.Item1;
                l.Location = new Point(0, i * l.Height);
                i--;
            }
        }

        public void Add(string text, LogEntryType type)
        {
            entries.Add(new Tuple<string, LogEntryType>(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": " + text, type));
            PerformLayout();
        }

        private Color GetEntryColor(LogEntryType type)
        {
            switch (type)
            {
                case LogEntryType.Lock:
                    return StudentRndColors.Red;
                case LogEntryType.Unlock:
                    return StudentRndColors.Green;
                case LogEntryType.Toggle:
                    return StudentRndColors.Blue;
                case LogEntryType.Error:
                default:
                    return StudentRndColors.Red;
            }
        }
    }
}
