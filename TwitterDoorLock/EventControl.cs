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
    public partial class EventControl : UserControl
    {
        public EventControl()
        {
            InitializeComponent();
        }

        private bool _twitterEnabled = true;
        public bool TwitterEnabled
        {
            get
            {
                return _twitterEnabled;
            }
            set
            {
                _twitterEnabled = value;
                twitterStatusIcon.Visible = value;
                MainForm.Instance.logControl.Add("Twitter unlocks " + (value ? "enabled" : "disabled"), LogEntryType.Toggle);
            }
        }

        private bool _senseEnabled = true;
        public bool SenseEnabled
        {
            get
            {
                return _senseEnabled;
            }
            set
            {
                _senseEnabled = value;
                senseStatusIcon.Visible = value;
                MainForm.Instance.logControl.Add("Sense unlocks " + (value ? "enabled" : "disabled"), LogEntryType.Toggle);
            }
        }

        private bool _webEnabled = true;
        public bool WebEnabled
        {
            get
            {
                return _webEnabled;
            }
            set
            {
                _webEnabled = value;
                webStatusIcon.Visible = value;
                MainForm.Instance.logControl.Add("Web updates " + (value ? "enabled" : "disabled"), LogEntryType.Toggle);
            }
        }
    }
}
