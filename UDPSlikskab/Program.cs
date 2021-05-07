using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ModelLibSlikskab;

namespace UDPSlikskab
{
    public class Program
    {
        static void Main(string[] args)
        {
            Post postData = new Post();
            //Vi sætter her den port vi skal bruge til at modtage data fra raspberry pi'en.
            UdpClient receiveUdp = new UdpClient(9001);
            IPEndPoint receiveEndPoint = new IPEndPoint(IPAddress.Any, 0);

            try
            {
                while (true)
                {
                    //Her modtager vi data som bytes fra vores raspberry pi og konverterer det til en string
                    Byte[] receiveBytes = receiveUdp.Receive(ref receiveEndPoint);
                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine("This message was sent from " +
                                      receiveEndPoint.Address.ToString() +
                                      " on their port number " +
                                      receiveEndPoint.Port.ToString());

                    Console.WriteLine(receivedData);

                    //Vi splitter vores string op i bidder så man kan bruge dem til at lave et objekt.
                    string[] txtSplit = receivedData.Split(" ");

                    for (int i = 0; i < txtSplit.Length; i++)
                    {
                        Console.WriteLine(txtSplit[i]);
                    }

                    //Her laver vi et objekt af det modtaget data, hvor vi konverterer de forskellige txtsplit til den ønskede data type.
                    SensorData sensorData = new SensorData(Convert.ToInt16(txtSplit[0]), Convert.ToInt16(txtSplit[1]),
                        Convert.ToInt32(txtSplit[2]), Convert.ToBoolean(txtSplit[3]), Convert.ToString(txtSplit[4]));

                    //Vi laver her en PostRequest til at sende objektet til vores database.
                    postData.PostItemHttpTask(sensorData);
                    Thread.Sleep(1000);
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
