using Autoguard.Domain.Entities;
using System.Threading.Tasks;

namespace Autoguard.Application.Interfaces.Repositories
{
    public interface IBusinessRepository
    {
        Task<Business> AddBusinessAsync(Business business);
    }
}
