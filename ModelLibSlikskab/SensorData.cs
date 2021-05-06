using System;
using System.Threading.Channels;

namespace ModelLibSlikskab
{
    public class SensorData
    {
        public int SensorID { get; set; }
        public int ReadingId { get; set; }
        public int Time { get; set; }
        public bool IsOpen { get; set; }
        public string ImageData { get; set; }

        public SensorData(int sensorID, int readingId, int time, bool isOpen, string imageData)
        {
            SensorID = sensorID;
            Time = time;
            IsOpen = isOpen;
            ImageData = imageData;
            ReadingId = readingId;
        }

        public override string ToString()
        {
            return SensorID +" "+ ReadingId + " " + Time + " " + IsOpen + " " + ImageData;
        }
        //test1 git
    }
    
}
