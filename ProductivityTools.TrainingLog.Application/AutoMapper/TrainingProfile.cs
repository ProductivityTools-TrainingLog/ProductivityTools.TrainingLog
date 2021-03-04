﻿using AutoMapper;
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
            CreateMap<Model.Training, Contract.Training>()
              .ReverseMap();
            //CreateMap<List<Model.Training>, List<Training>>()
            //    .ReverseMap();
        }
    }
}
