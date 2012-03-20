using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace TwitterDoorLock
{
    public class DoorCommunications
    {
        private static DoorCommunications _instance;
        public static DoorCommunications Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DoorCommunications();
                }

                return _instance;
            }
        }

        private SerialPort p;

        private const int baud = 9600;
        private const Parity parity = Parity.None;
        private const int dataBits = 8;
        private const StopBits stopBits = StopBits.One;

        private Thread readThread;
        private bool continueReading = false;

        // Default values:
        private string MethodId = "rfid";
        private int Port = 3;

        private DoorCommunications()
        {
            p = new SerialPort("COM" + Port.ToString(), baud, parity, dataBits, stopBits);

            if (!continueReading)
            {
                continueReading = true;
                readThread = new Thread(Read);
                readThread.Start();
            }
        }

        private void Read()
        {
            p.Open();

            while (continueReading)
            {
                string result = p.ReadLine();

                // Strip out meta-text
                result = result.Replace("u0003", "");
                result = result.Replace("u0002", "");
                result = result.Replace("r", "");
                result = result.Replace("n", "");

                if (result[0] == 's')
                {

                }
            }

            p.Close();
        }
    }
}
