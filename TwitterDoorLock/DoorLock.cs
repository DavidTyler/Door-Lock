using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterDoorLock
{
    class DoorLock
    {
        private static AsyncSerial s;

        private static void init()
        {
            try
            {
                s = AsyncSerial.SearchPort("2", 'k');
            }
            catch
            {
                MainForm.Instance.logControl.Add("Could not connect to the door", LogEntryType.Error);
            }
        }

        public static bool Locked
        {
            set
            {
                if (s == null)
                {
                    init();
                }
                try
                {
                    if (value)
                    {
                        s.Write("0");
                    }
                    else
                    {
                        s.Write("1");
                    }
                }
                catch
                {
                    MainForm.Instance.logControl.Add("Changing lock state failed.", LogEntryType.Error);
                }
            }
        }

        public static void Unlock()
        {
            Locked = false;
        }

        public static void Lock()
        {
            Locked = true;
        }
    }
}
