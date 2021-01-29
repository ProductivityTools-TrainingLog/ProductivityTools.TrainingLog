using System;

namespace ProductivityTools.TrainingLog.Model
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public int TrainingId { get; set; }
        public byte[] PhotographHash { get; set; }
        public byte[] Photograph { get; set; }
        
    }
}
