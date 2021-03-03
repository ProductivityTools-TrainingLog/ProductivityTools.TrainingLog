using AutoMapper;
using ProductivityTools.TrainingLog.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.TrainingLog.Application.AutoMapper
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<Training, ProductivityTools.TrainingLog.Database.Entities.Training>()
              .ReverseMap();
        }
    }
}
