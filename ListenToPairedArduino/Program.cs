using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace ListenToPairedArduino
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BYTES_TO_READ = 24;

            using (SerialPort objSerialPort = new SerialPort("COM6", 9600))
            {
                objSerialPort.Open();

                using (Stream objStream = objSerialPort.BaseStream)
                {
                    byte[] bytBuffer = new byte[BYTES_TO_READ];
                    int intBytesRead = 0;

                    while (true)
                    {
                        intBytesRead = objStream.Read(bytBuffer, 0, BYTES_TO_READ);
                        if (intBytesRead > 0) System.Diagnostics.Debug.WriteLine(System.Text.Encoding.UTF8.GetString(bytBuffer));
                        else System.Diagnostics.Debug.WriteLine("no bytes");
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }
        }
    }
}
