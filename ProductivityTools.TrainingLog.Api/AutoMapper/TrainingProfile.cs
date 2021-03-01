using AutoMapper;
using ProductivityTools.TrainingLog.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductivityTools.TrainingLog.AutoMapper
{
    public class TrainingProfile:Profile
    {
        public TrainingProfile()
        {
            //CreateMap<Contract.Training, Objects.Training>().ReverseMap();
        }
    }
}
