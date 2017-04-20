using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using System.IO;

namespace ProvideServerToPhone
{
    class Program
    {
        static void Main(string[] args)
        {
            BluetoothListener objListener = new BluetoothListener(new Guid("00112233-4455-6677-8899-aabbccddeeee"));
            objListener.Start();
            
            // Now accept new connections, perhaps using the thread pool to handle each
            BluetoothClient conn = objListener.AcceptBluetoothClient();
            Stream peerStream = conn.GetStream();

            StreamReader objReader = new StreamReader(peerStream);
            int x;
            do
            {
                x = objReader.Read();
                Console.WriteLine(x);
            }
            while (x > -1);

            Console.ReadLine();
        }
    }
}
