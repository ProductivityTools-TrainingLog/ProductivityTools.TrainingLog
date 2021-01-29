using AutoMapper;
using ProductivityTools.TrainingLog.Contract;
using ProductivityTools.TrainingLog.Database;
using ProductivityTools.TrainingLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace ProductivityTools.TrainingLog.Application
{
    public interface ITrainingApplication
    {
        Training Add(Training training);
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

        public Training Add(Training training)
        {
            Training dbTraining = AddMetaData(training);
            if (dbTraining.TrainingId == 0)
            {
                Console.WriteLine("fdsa");
            }
            AddPhoto(training, dbTraining.TrainingId);
            return dbTraining;
        }

        private void AddPhoto(Training training, int databaseTrainingId)
        {
            foreach (var picture in training.Pictures)
            {
                var hash = ComputeHash(picture);
                var dbPicture = this.Context.Photo.Any(x => x.TrainingId == databaseTrainingId && x.PhotographHash == hash);
                if (dbPicture == false)
                {
                    Photo photo = new Photo();
                    photo.TrainingId = training.TrainingId;
                    photo.Photograph = picture;
                    photo.PhotographHash = hash;
                    this.Context.Photo.Add(photo);
                    this.Context.SaveChanges();
                }
            }
        }

        private byte[] ComputeHash(byte[] picture)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] hashValue = mySHA256.ComputeHash(picture);
                return hashValue;
            }
        }

        private Training AddMetaData(Training training)
        {
            var t = this.Context.Training.SingleOrDefault(x => x.Start == training.Start && x.End == training.End && x.Sport == training.Sport);
            if (t == null)
            {
                this.Context.Training.Add(training);
                this.Context.SaveChanges();
                return training;
            }
            else
            {
                return t;
            }
        }
    }
}
