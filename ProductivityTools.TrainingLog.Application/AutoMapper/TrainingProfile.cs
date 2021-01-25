using AutoMapper;
using ProductivityTools.TrainingLog.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.TrainingLog.Application.AutoMapper
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<TrainingRaw, Training>();
        }
    }
}
