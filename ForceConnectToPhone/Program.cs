using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using System.IO;

namespace ForceConnectToPhone
{
    class Program
    {
        static void Main(string[] args)
        {
            BluetoothAddress objPhoneAddress = BluetoothAddress.Parse("F8:CF:C5:B8:6E:4F");
            Guid serviceClass = new Guid("00112233-4455-6677-8899-aabbccddeeff");
            //serviceClass = BluetoothService.SerialPort;

            BluetoothEndPoint objEndpoint = new BluetoothEndPoint(objPhoneAddress, serviceClass);
            BluetoothClient objClient = new BluetoothClient();
            objClient.Connect(objEndpoint);
            Stream peerStream = objClient.GetStream();
            
            System.IO.StreamWriter objWriter = new StreamWriter(peerStream);
            objWriter.WriteLine("This is a test");
            objWriter.Flush();

            Console.ReadLine();
        }
    }
}
