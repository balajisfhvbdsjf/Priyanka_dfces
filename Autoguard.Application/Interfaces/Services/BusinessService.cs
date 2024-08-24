using Autoguard.Application.DTOs;
using Autoguard.Application.Interfaces.Repositories;
using Autoguard.Application.Interfaces.Services;
using Autoguard.Domain.Entities;
using AutoMapper;
using System.Threading.Tasks;

namespace Autoguard.Application.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly IMapper _mapper;

        public BusinessService(IBusinessRepository businessRepository, IMapper mapper)
        {
            _businessRepository = businessRepository;
            _mapper = mapper;
        }

        public async Task<BusinessDto> RegisterBusinessAsync(BusinessDto businessDto)
        {
            var businessEntity = _mapper.Map<Business>(businessDto);
            var registeredBusiness = await _businessRepository.AddBusinessAsync(businessEntity);
            return _mapper.Map<BusinessDto>(registeredBusiness);
        }
    }
}
