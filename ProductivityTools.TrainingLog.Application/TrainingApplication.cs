using AutoMapper;
using ProductivityTools.TrainingLog.Application.Etl;
using ProductivityTools.TrainingLog.Database;
using ProductivityTools.TrainingLog.Objects;
using System;
using System.Collections.Generic;
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
        private readonly IMapper Mapper;

        public TrainingApplication(TrainingDbContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
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
                var record = this.Context.Training.Any(x => x.TrainingId == trainingRaw.TrainingRawId);
                if (record == false)
                {
                    ProcessRecord(trainingRaw);
                }
                
            }
        }

        private void ProcessRecord(TrainingRaw trainingRaw)
        {
            List<IRule> rules = new List<IRule>();
            Training training = this.Mapper.Map<Training>(trainingRaw);
            foreach (var rule in rules)
            {
                rule.Process(trainingRaw, training);
            }

            this.Context.Training.Add(training);
            this.Context.SaveChanges();
        }
    }
}
