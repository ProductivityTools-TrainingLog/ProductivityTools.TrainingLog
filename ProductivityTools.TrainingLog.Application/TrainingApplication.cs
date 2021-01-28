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
        string AddRaw(Training training);
        void ETL();
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

        public string AddRaw(Training training)
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

        public void ETL()
        {
            //var trainingRaws = this.Context.Training.Where(x => x.Processed == false);
            //foreach (var training in trainingRaws)
            //{
            //    var record = this.Context.Training.Any(x => x.TrainingId == training.TrainingId);
            //    if (record == false)
            //    {
            //        ProcessRecord(training);
            //        //trainingRaw.Processed = true;
            //    }
                
            //}
            //this.Context.SaveChanges();
        }

        private void ProcessRecord(Training training)
        {
            //List<IRule> rules = new List<IRule>();
            //rules.Add(new EndomondoSport());

            //Training training = this.Mapper.Map<Training>(training);
            //foreach (var rule in rules)
            //{
            //    rule.Process(training, training);
            //}

            this.Context.Training.Add(training);
  
        }
    }
}
