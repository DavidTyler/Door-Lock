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
    public partial class KeyboardShortcutsControl : UserControl
    {
        public KeyboardShortcutsControl()
        {
            InitializeComponent();
        }

        private Dictionary<char, Tuple<string, KeyEventHandler>> keys = new Dictionary<char, Tuple<string, KeyEventHandler>>();
        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);

            this.Controls.Clear();

            int i = 0;
            foreach (KeyValuePair<char, Tuple<string, KeyEventHandler>> key in keys)
            {
                Label l = new Label();
                l.Text = key.Key + "\n" + key.Value.Item1;
                l.Parent = this;
                l.Width = this.Width / keys.Count;
                l.Height = this.Height;
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.BackColor = Color.FromArgb(i * (255 / (keys.Count + 2)), (i + 1) * (255 / (keys.Count + 2)), (i + 2) * (255 / (keys.Count + 2)));
                if (l.BackColor.GetBrightness() < .5)
                {
                    l.ForeColor = Color.White;
                }
                l.Location = new Point(i * l.Width, 0);
                i++;
            }
        }

        public bool IsKeyBound(char c)
        {
            return keys.ContainsKey(c);
        }

        public void AddKey(char c, string message, KeyEventHandler onPress)
        {
            keys.Add(c.ToString().ToUpper().ToCharArray()[0], new Tuple<string, KeyEventHandler>(message, onPress));
            PerformLayout();
        }

        private void KeyUpHandler(object sender, KeyEventArgs e)
        {
            char key = (char)e.KeyValue;

            if (keys.ContainsKey(key))
            {
                keys[key].Item2(sender, e);
            }
        }

        private void KeyboardShortcutsControl_Load(object sender, EventArgs e)
        {
            this.ParentForm.KeyUp += new KeyEventHandler(KeyUpHandler);
        }
    }
}
