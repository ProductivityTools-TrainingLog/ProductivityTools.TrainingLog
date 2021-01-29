using System;

namespace ProductivityTools.TrainingLog.Model
{
    public class Photograph
    {
        public int PhotoId { get; set; }
        public int TrainingId { get; set; }
        public byte[] PhotographFileHash { get; set; }
        public byte[] PhotographFile { get; set; }
        
    }
}
