using Autoguard.Application.DTOs;
using Autoguard.Application.Features.Business.Commands;
using Autoguard.Application.Interfaces.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Autoguard.Application.Features.Business.Handlers
{
    public class RegisterBusinessCommandHandler : IRequestHandler<RegisterBusinessCommand, BusinessDto>
    {
        private readonly IBusinessService _businessService;

        public RegisterBusinessCommandHandler(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        public async Task<BusinessDto> Handle(RegisterBusinessCommand request, CancellationToken cancellationToken)
        {
            return await _businessService.RegisterBusinessAsync(request.BusinessDto);
        }
    }
}
