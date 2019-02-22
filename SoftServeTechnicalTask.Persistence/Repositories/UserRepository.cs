using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftServerTechnicalTask.Domain.Abstractions;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Persistence.DBContext;
using SoftServeTechnicalTask.Persistence.Repositories.BuildingBlocks;

namespace SoftServeTechnicalTask.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public Task<User> GetByNameIdentifier(int nameIdentifier)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.NameIdentifier == nameIdentifier);
        }
    }
}
