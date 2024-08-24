using Autoguard.Application.DTOs;
using System.Threading.Tasks;

namespace Autoguard.Application.Interfaces.Services
{
    public interface IBusinessService
    {
        Task<BusinessDto> RegisterBusinessAsync(BusinessDto businessDto);
    }
}
