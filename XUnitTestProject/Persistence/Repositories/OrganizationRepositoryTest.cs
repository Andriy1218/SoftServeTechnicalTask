using Moq;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Persistence.DBContext;
using SoftServeTechnicalTask.Persistence.Repositories;

namespace XUnitTestProject.Persistence.Repositories
{
    public class OrganizationRepositoryTest
    {
        private readonly Mock<ApplicationContext> _context;
        private readonly OrganizationRepository _repository;
        private readonly Organization _organization;

        public OrganizationRepositoryTest()
        {
            _repository = new OrganizationRepository(_context.Object);

            _organization = new Organization("name", "code", OrganizationType.GeneralPartnership, "owner");
        }
    }
}
