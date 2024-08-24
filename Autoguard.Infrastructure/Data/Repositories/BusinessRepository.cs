using Autoguard.Application.Interfaces.Repositories;
using Autoguard.Domain.Entities;
using Autoguard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Autoguard.Infrastructure.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly AutoguardDbContext _context;

        public BusinessRepository(AutoguardDbContext context)
        {
            _context = context;
        }

        public async Task<Business> AddBusinessAsync(Business business)
        {
            await _context.Businesses.AddAsync(business);
            await _context.SaveChangesAsync();
            return business;
        }
    }
}
