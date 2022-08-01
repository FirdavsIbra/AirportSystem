using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Service.DTO_s.Airplanes;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Airplane, AirplaneForCreation>().ReverseMap();
        }
    }
}
