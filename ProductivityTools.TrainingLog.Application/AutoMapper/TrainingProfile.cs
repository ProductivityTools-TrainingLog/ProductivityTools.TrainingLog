using AutoMapper;
using ProductivityTools.TrainingLog.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductivityTools.TrainingLog.Application.AutoMapper
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<Model.Training, Contract.Training>()
               .ForMember(dest => dest.Gpx, opt => opt.MapFrom(src => src.Gpx.GpxFile))
               .ForMember(dest => dest.Pictures, opt => opt.MapFrom(src => src.Photographs.Select(x => x.PhotographFile)))
               .ForMember(dest => dest.ExternalIdList, opt => opt.MapFrom(
                   src => src.TrainingExternalIdList.ToDictionary(x => x.Application, x => x.Key)));


            CreateMap<Contract.Training, Model.Training>()
               .ForMember(dest => dest.Gpx, opt => opt.Ignore())
               .ForMember(dest => dest.Photographs, opt => opt.Ignore());
        }
    }
}
