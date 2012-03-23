using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace TwitterDoorLock
{
    public partial class EventControl : UserControl
    {
        private List<IListener> listeners = new List<IListener>();
        public EventControl()
        {
            InitializeComponent();

            foreach (Type t in Listeners)
            {
                if (t.IsInterface)
                {
                    continue;
                }
                IListener listener = (IListener)Activator.CreateInstance(t);
                listener.OnUnlock += new AuthorizedUnlockEvent(listener_OnUnlock);
                listeners.Add(listener);
            }

        }

        private Thread RelockThread;
        private void Relock()
        {
            Thread.Sleep(20000);
            MainForm.Instance.doorStatusControl.Unlocked = false;
        }

        void listener_OnUnlock(string ServiceName, string Username)
        {
            MainForm.Instance.logControl.Add(ServiceName + " entry from " + Username, LogEntryType.Unlock);
            MainForm.Instance.doorStatusControl.Unlocked = true;
            RelockThread = new Thread(new ThreadStart(Relock));
            RelockThread.Start();
        }

        private IEnumerable<Type> Listeners
        {
            get
            {
                var type = typeof(IListener);
                return AppDomain.CurrentDomain.GetAssemblies().ToList()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
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
