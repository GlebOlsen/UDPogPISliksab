using System;
using System.Threading.Channels;

namespace ModelLibSlikskab
{
    public class SensorData
    {
        public int SensorID { get; set; }
        public int ReadingId { get; set; }
        public DateTime Time { get; set; }
        public bool IsOpen { get; set; }
        public byte[] ImageData { get; set; }

        public SensorData(int readingId,int sensorID, DateTime time, bool isOpen)
        {
            SensorID = sensorID;
            Time = time;
            IsOpen = isOpen;
            //ImageData = imageData;
            ReadingId = readingId;
        }

        public override string ToString()
        {
            return SensorID + " " + Time + " " + IsOpen + " " + ImageData;
        }
        //test1 git
    }
    
}
