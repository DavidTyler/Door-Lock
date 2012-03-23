using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace TwitterDoorLock
{
    public delegate void AuthorizedUnlockEvent(string ServiceName, string Username);
    interface IListener
    {
        string ServiceName
        {
            get;
        }

        Image ServiceIcon
        {
            get;
        }

        event AuthorizedUnlockEvent OnUnlock;
    }
}
