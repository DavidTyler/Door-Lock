using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwitterDoorLock
{
    public partial class MainForm : Form
    {
        private static MainForm _instance;
        public static MainForm Instance{
            get
            {
                if (_instance == null)
                {
                    _instance = new MainForm();
                }

                return _instance;
            }
        }

        public EventControl eventControl = new EventControl();
        public LogControl logControl = new LogControl();
        public DoorStatusControl doorStatusControl = new DoorStatusControl();

        private MainForm()
        {
            InitializeComponent();

            // Display the door status
            doorStatusControl.Height = 100;
            doorStatusControl.Parent = this;
            doorStatusControl.Location = new Point(0, 0);
            doorStatusControl.Width = Screen.PrimaryScreen.Bounds.Width;

            // Display the log
            logControl.Height = this.Height - 180;
            logControl.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            logControl.Parent = this;
            logControl.Location = new Point(64, 100);

            // Display the event control
            eventControl.Height = Screen.PrimaryScreen.Bounds.Height - 180;
            eventControl.Width = 64;
            eventControl.Parent = this;
            eventControl.Location = new Point(0, 100);
            

            // Init and display keyboard shortcuts
            KeyboardShortcutsControl k = new KeyboardShortcutsControl();
            k.Height = 50;
            k.Parent = this;
            k.Location = new Point(0, Screen.PrimaryScreen.Bounds.Height - k.Height); // I have no idea why I have to subtract 30 here.
            k.Width = Screen.PrimaryScreen.Bounds.Width;
            this.KeyPreview = true;

            k.AddKey('x', "Exit", new KeyEventHandler(delegate(object o, KeyEventArgs e)
            {
                Application.Exit();
            }));

            k.AddKey('u', "Toggle Pushing Status Updates", new KeyEventHandler(delegate(object o, KeyEventArgs e)
            {
                eventControl.WebEnabled = !eventControl.WebEnabled;
            }));

        }
    }
}
