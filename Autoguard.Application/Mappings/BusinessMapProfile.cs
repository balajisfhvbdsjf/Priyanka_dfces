using Autoguard.Application.DTOs;
using Autoguard.Domain.Entities;
using AutoMapper;

namespace Autoguard.Application.Mappings
{
    public class BusinessMapProfile : Profile
    {
        public BusinessMapProfile()
        {
            CreateMap<Business, BusinessDto>().ReverseMap();
        }
    }
}
