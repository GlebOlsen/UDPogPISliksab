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
        public string Image { get; set; }

        public SensorData(int sensorID, int readingId, int time, bool isOpen, string image)
        {
            SensorID = sensorID;
            Time = time;
            IsOpen = isOpen;
            Image = image;
            ReadingId = readingId;
        }

        public override string ToString()
        {
            return SensorID +" "+ ReadingId + " " + Time + " " + IsOpen + " " + Image;
        }
    }
    
}
