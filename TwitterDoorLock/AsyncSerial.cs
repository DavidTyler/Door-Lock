using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace TwitterDoorLock
{
    public delegate void ProcessLine(string line);
    public class AsyncSerial
    {
        public event ProcessLine IncomingLine;

        private SerialPort p;

        private const Parity parity = Parity.None;
        private const int dataBits = 8;
        private const StopBits stopBits = StopBits.One;

        private Thread readThread;
        private bool continueReading = true;

        public AsyncSerial(string port, int baud=9600, string newLine = "\n")
        {
            p = new SerialPort(port, baud, parity, dataBits, stopBits);
            p.NewLine = newLine;
            p.Open();

            readThread = new Thread(Read);
            readThread.Start();
            readThread.IsBackground = true;
        }

        public void Write(string s)
        {
            p.Write(s);
        }

        public static AsyncSerial SearchPort(string write, char search, int baud=9600)
        {
            foreach (string port in SerialPort.GetPortNames())
            {
                SerialPort temp;
                try
                {
                    temp = new SerialPort(port, baud);
                    try
                    {
                        temp.Open();
                        temp.ReadTimeout = 2500;
                        temp.Write(write);
                        var v = temp.ReadChar();
                        MainForm.Instance.logControl.Add(v.ToString(), LogEntryType.Error);
                        if (v == search)
                        {
                            temp.Close();
                            return new AsyncSerial(port);
                        }
                    }
                    catch (Exception ex)
                    {}
                    finally
                    {
                        temp.Close();
                    }
                }
                catch (Exception ex)
                {}
            }

            throw new Exception("Port not found.");
        }

        public void DtsDisable()
        {
            p.DtrEnable = false;
        }

        public void DtsEnable()
        {
            p.DtrEnable = true;
        }

        private void Read()
        {
            while (continueReading)
            {
                string result = p.ReadLine();

                // Strip out meta-text
                result = result.Replace("u0003", "");
                result = result.Replace("u0002", "");
                result = result.Replace("\r", "");
                result = result.Replace("\n", "");

                if (IncomingLine != null && result != "")
                {
                    IncomingLine(result);
                }
            }

            p.Close();
        }
    }
}
