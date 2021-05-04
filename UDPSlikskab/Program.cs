using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ModelLibSlikskab;

namespace UDPSlikskab
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient receiveUdp = new UdpClient(9001);
            IPEndPoint receiveEndPoint = new IPEndPoint(IPAddress.Any, 0);

            try
            {
                while (true)
                {
                    Byte[] receiveBytes = receiveUdp.Receive(ref receiveEndPoint);
                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine("This message was sent from " +
                                      receiveEndPoint.Address.ToString() +
                                      " on their port number " +
                                      receiveEndPoint.Port.ToString());

                    Console.WriteLine(receivedData);

                    string[] txtSplit = receivedData.Split(" ");
                    for (int i = 0; i < txtSplit.Length; i++)
                    {
                        Console.WriteLine(txtSplit[i]);
                    }

                    SensorData sensorData = new SensorData(Convert.ToInt16(txtSplit[0]), Convert.ToInt16(txtSplit[1]),
                        Convert.ToDateTime(txtSplit[2] + " " + txtSplit[3]), Convert.ToBoolean(txtSplit[4]));
                    Thread.Sleep(3000);
                    break;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
