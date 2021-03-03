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
        List<Training> List(string account);
        Training Get(int trainingId);
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
            AddPhoto(training.Pictures, dbTraining.TrainingId);
            AddGpx(training.Gpx, dbTraining.TrainingId);
            return dbTraining;
        }

        private void AddPhoto(List<byte[]> photos, int databaseTrainingId)
        {
            foreach (var picture in photos)
            {
                var hash = ComputeHash(picture);
                var dbPicture = this.Context.Photo.Any(x => x.TrainingId == databaseTrainingId && x.PhotographFileHash == hash);
                if (dbPicture == false)
                {
                    Photograph photo = new Photograph();
                    photo.TrainingId = databaseTrainingId;
                    photo.PhotographFile = picture;
                    photo.PhotographFileHash = hash;
                    this.Context.Photo.Add(photo);
                    this.Context.SaveChanges();
                }
            }
        }

        private void AddGpx(byte[] gpx, int databaseTrainingId)
        {
            if (gpx != null)
            {
                var hash = ComputeHash(gpx);
                var dbPicture = this.Context.Gpx.Any(x => x.TrainingId == databaseTrainingId && x.GpxFileHash == hash);
                if (dbPicture == false)
                {
                    Gpx databaseGpx = new Gpx();
                    databaseGpx.TrainingId = databaseTrainingId;
                    databaseGpx.GpxFile = gpx;
                    databaseGpx.GpxFileHash = hash;
                    this.Context.Gpx.Add(databaseGpx);
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
            Database.Entities.Training dbTraining = this.Mapper.Map<Database.Entities.Training>(training);
            var t = this.Context.Training.SingleOrDefault(x => x.Start == training.Start && x.End == training.End && x.Sport == training.Sport);
            if (t == null)
            {
                this.Context.Training.Add(dbTraining);
                this.Context.SaveChanges();
                return training;
            }
            else
            {
                return this.Mapper.Map<Training>(t);
            }
        }

        public List<Training> List(string account)
        {
            var r = this.Context.Training.Where(x => x.Account == account);
            return this.Mapper.Map<List<Training>>(r.ToList());
        }

        public Training Get(int trainingId)
        {
            throw new Exception();
            //var r = this.Context.Training.Include( .Single(x => x.TrainingId == trainingId);

        }
    }
}
