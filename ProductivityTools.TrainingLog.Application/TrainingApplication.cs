using ProductivityTools.TrainingLog.Database;
using ProductivityTools.TrainingLog.Objects;
using System;
using System.Linq;

namespace ProductivityTools.TrainingLog.Application
{
    public interface ITrainingApplication
    {
        string AddRaw(TrainingRaw training);
    }

    public class TrainingApplication : ITrainingApplication
    {
        private readonly TrainingDbContext Context;

        public TrainingApplication(TrainingDbContext context)
        {
            this.Context = context;
        }

        public string AddRaw(TrainingRaw training)
        {
            var x = this.Context.TrainingRaw.ToList();
            var t = this.Context.TrainingRaw.SingleOrDefault(x => x.Start == training.Start && x.End == training.End && x.Sport == training.Sport);
            if (t == null)
            {
                this.Context.TrainingRaw.Add(training);
                this.Context.SaveChanges();
                return "Added";
            }
            else
            {
                return "Training already exists";
            }
        }

        public void ETL()
        {
            var trainingRaws = this.Context.TrainingRaw.Where(x => x.Processed == false);
            foreach (var trainingRaw in trainingRaws)
            {
                var record = this.Context.Training.Any(x => x.TrainingId == trainingRaw.TrainingId);
                if (record == false)
                {
                    ProcessRecord(trainingRaw);
                }
                
            }
        }

        private void ProcessRecord(TrainingRaw trainingRaw)
        {
            Training training = new Training();
            
        }
    }
}
