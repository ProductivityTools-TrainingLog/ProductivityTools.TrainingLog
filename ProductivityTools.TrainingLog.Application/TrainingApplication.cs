using ProductivityTools.TrainingLog.Contract;
using ProductivityTools.TrainingLog.Database;
using System;

namespace ProductivityTools.TrainingLog.Application
{
    public interface ITrainingApplication
    {
        void Add(Training training);
    }

    public class TrainingApplication : ITrainingApplication
    {
        private readonly TrainingDbContext Context;

        public TrainingApplication(TrainingDbContext context)
        {
            this.Context = context;
        }

        public void Add(Training training)
        {
            this.Context.Training.Add(training);
            this.Context.SaveChanges();
        }
    }
}
