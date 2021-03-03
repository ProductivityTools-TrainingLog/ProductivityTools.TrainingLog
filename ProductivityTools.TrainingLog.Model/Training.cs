using ProductivityTools.TrainingLog.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.TrainingLog.Model
{
    public class Training
    {
        public string Application { get; set; }
        public string Account { get; set; }

        public int TrainingId { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public TrainingType Sport { get; set; }
        public string Source { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Duration { get; set; }
        public decimal Distance { get; set; }
        public decimal Calories { get; set; }
        public decimal AverageSpeed { get; set; }
        public List<byte[]> Pictures { get; set; }
        public byte[] Gpx { get; set; }

    }
}
