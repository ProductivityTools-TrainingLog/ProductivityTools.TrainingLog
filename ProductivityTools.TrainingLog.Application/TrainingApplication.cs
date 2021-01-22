using ProductivityTools.TrainingLog.Contract;
using ProductivityTools.TrainingLog.Database;
using System;

namespace ProductivityTools.TrainingLog.Application
{
    public interface ITrainingApplication
    {
        void AddRaw(Training training);
    }

    public class TrainingApplication : ITrainingApplication
    {
        private readonly TrainingDbContext Context;

        public TrainingApplication(TrainingDbContext context)
        {
            this.Context = context;
        }

        public void AddRaw(Training training)
        {
            this.Context.TrainingRaw.Add(training);
            this.Context.SaveChanges();
        }
    }
}
