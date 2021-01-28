using AutoMapper;
using ProductivityTools.TrainingLog.Contract;
using ProductivityTools.TrainingLog.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductivityTools.TrainingLog.Application
{
    public interface ITrainingApplication
    {
        string Add(Training training);
    }

    public class TrainingApplication : ITrainingApplication
    {
        private readonly TrainingDbContext Context;
        private readonly IMapper Mapper;

        public TrainingApplication(TrainingDbContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public string Add(Training training)
        {
            var x = this.Context.Training.ToList();
            var t = this.Context.Training.SingleOrDefault(x => x.Start == training.Start && x.End == training.End && x.Sport == training.Sport);
            if (t == null)
            {
                this.Context.Training.Add(training);
                this.Context.SaveChanges();
                return "Added";
            }
            else
            {
                return "Training already exists";
            }
        }
    }
}
