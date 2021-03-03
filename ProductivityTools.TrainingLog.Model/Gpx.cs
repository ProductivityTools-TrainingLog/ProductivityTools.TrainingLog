using System;

namespace ProductivityTools.TrainingLog.Model
{
    public class Gpx
    {
        public int GpxId { get; set; }
        public int TrainingId { get; set; }
        public byte[] GpxFileHash { get; set; }
        public byte[] GpxFile { get; set; }

        public Training Training { get; set; }
    }
}
