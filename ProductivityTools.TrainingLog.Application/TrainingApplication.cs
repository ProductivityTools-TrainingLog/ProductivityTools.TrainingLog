using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        Contract.Training Add(Contract.Training training);
        List<Contract.Training> List(string account);
        Contract.Training Get(int trainingId);
        void UpdateExternalId(int trainingId, string externalSystemName, string externalSystemId);
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

        public Contract.Training Add(Contract.Training training)
        {
            Model.Training dbTraining = AddMetaData(training);
            if (dbTraining.TrainingId == 0)
            {
                Console.WriteLine("fdsa");
            }
            AddPhoto(training.Pictures, dbTraining.TrainingId);
            AddGpx(training.Gpx, dbTraining.TrainingId);
            return this.Mapper.Map<Contract.Training>(dbTraining);
        }

        private void AddPhoto(List<byte[]> photos, int databaseTrainingId)
        {
            if (photos != null)
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

        private Model.Training AddMetaData(Contract.Training training)
        {
            Model.Training dbTraining = this.Mapper.Map<Model.Training>(training);
            var t = this.Context.Training.SingleOrDefault(x => x.Account == training.Account && x.Start == training.Start && x.End == training.End && x.Sport == training.Sport);
            if (t == null)
            {
                this.Context.Training.Add(dbTraining);
                this.Context.SaveChanges();
                return dbTraining;
            }
            else
            {
                return t;
            }
        }

        public List<Contract.Training> List(string account)
        {
            //var photo = this.Context.Photo.Select(x => x.TrainingId).Take(10).ToList();
            //var r = this.Context.Training.Include(x => x.TrainingExternalIdList)
            //    .Where(x => x.Account == account && photo.Contains(x.TrainingId));
            //return this.Mapper.Map<List<Contract.Training>>(r.ToList());

            
            var r = this.Context.Training.Include(x => x.TrainingExternalIdList)
                .Where(x => x.Account == account);
            return this.Mapper.Map<List<Contract.Training>>(r.ToList());
        }

        public Contract.Training Get(int trainingId)
        {
            //throw new Exception();
            var r = this.Context.Training
                .Include(x => x.Gpx)
                .Include(x => x.Photographs)
                .Include(x => x.TrainingExternalIdList)
                .Single(x => x.TrainingId == trainingId);
            return this.Mapper.Map<Contract.Training>(r); ;

        }

        public void UpdateExternalId(int trainingId, string externalSystemName, string externalSystemId)
        {
            var trainingExternalId = this.Context.TrainingExternalId.SingleOrDefault(x => x.TrainingId == trainingId && x.Application == externalSystemName);
            if (trainingExternalId == null)
            {
                var @new = new TrainingExternalId();
                @new.Application = externalSystemName;
                @new.Key = externalSystemId;
                @new.TrainingId = trainingId;
                this.Context.TrainingExternalId.Add(@new);
            }
            else
            {
                trainingExternalId.Key = externalSystemId;
            }
            this.Context.SaveChanges();
        }
    }
}
