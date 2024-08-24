using Autoguard.Application.DTOs;
using MediatR;

namespace Autoguard.Application.Features.Business.Commands
{
    public class RegisterBusinessCommand : IRequest<BusinessDto>
    {
        public BusinessDto BusinessDto { get; set; }

        public RegisterBusinessCommand(BusinessDto businessDto)
        {
            BusinessDto = businessDto;
        }
    }
}
