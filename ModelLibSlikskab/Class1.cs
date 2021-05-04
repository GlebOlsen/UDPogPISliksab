using System;
using System.Threading.Channels;

namespace ModelLibSlikskab
{
    public class Class1
    {
        public int SensorID { get; set; }
        public DateTime Time { get; set; }
        public bool IsOpen { get; set; }
        public byte[] ImageData { get; set; }

        public Class1(int sensorID, DateTime time, bool isOpen, byte[] imageData)
        {
            SensorID = sensorID;
            Time = time;
            IsOpen = isOpen;
            ImageData = imageData;
        }

        public override string ToString()
        {
            return SensorID + " " + Time + " " + IsOpen + " " + ImageData;
        }
    }
    
}
