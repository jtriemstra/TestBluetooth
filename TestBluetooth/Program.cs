using System;
using InTheHand.Net.Sockets;

namespace TestBluetooth
{
    class Program
    {
        static void Main(string[] args)
        {
            var bluetoothClient = new BluetoothClient();
            var devices = bluetoothClient.DiscoverDevices();
            Console.WriteLine("Bluetooth devices");
            foreach (var device in devices)
            {
                var blueToothInfo =
                    string.Format(
                       "- DeviceName: {0}{1}  Connected: {2}{1}  Address: {3}{1}  Last seen: {4}{1}  Last used: {5}{1}",
                        device.DeviceName, Environment.NewLine, device.Connected, device.DeviceAddress, device.LastSeen,
                        device.LastUsed);

                blueToothInfo += string.Format("  Class of device{0}   Device: {1}{0}   Major Device: {2}{0}   Service: {3}",
                    Environment.NewLine, device.ClassOfDevice.Device, device.ClassOfDevice.MajorDevice,
                    device.ClassOfDevice.Service);
                Console.WriteLine(blueToothInfo);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
