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
            var x=this.Context.TrainingRaw.ToList();
            var t=this.Context.TrainingRaw.SingleOrDefault(x => x.Start == training.Start && x.End == training.End && x.Sport == training.Sport);
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
            
        }
    }
}
