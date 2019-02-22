using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SoftServerTechnicalTask.Domain.Abstractions;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Application.Controllers;
using Xunit;

namespace XUnitTestProject.Application.Controllers
{
    public class OrganizationControllerTest
    {
        private readonly Mock<IOrganizationRepository> _repository;
        private readonly OrganizationController _controller;

        public OrganizationControllerTest()
        {
            _repository = new Mock<IOrganizationRepository>();
            _controller = new OrganizationController(_repository.Object);
        }

        [Fact]
        public async Task Get()
        {
            //Arrange
            var organization = new Organization("name", "code", OrganizationType.GeneralPartnership, "owner");
            _repository.Setup(r => r.GetByIdAsync(organization.Id)).ReturnsAsync(organization);

            //Act
            var result = await _controller.Get(organization.Id);

            //Assert
            var res = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(organization, res.Value);
        }

        [Fact]
        public async Task Get_WhenOrganization_IsNotFound_ReturnsNotFound()
        {
            //Arrange
            var organization = new Organization("name", "code", OrganizationType.GeneralPartnership, "owner");
            _repository.Setup(r => r.GetByIdAsync(organization.Id)).ReturnsAsync(null as Organization);

            //Act
            var result = await _controller.Get(organization.Id);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Create()
        {
            Organization organization = new Organization("Name1", "Code1", OrganizationType.GeneralPartnership, "Owner");
            _repository.Setup(r => r.CreateAsync(It.IsAny<Organization>())).ReturnsAsync(true);

            //Act
            var result = await _controller.Create(organization);

            //Assert
            Assert.IsType<AcceptedResult>(result);
        }

        [Fact]
        public async Task Create_WhenConflict_ReturnsConflict()
        {
            Organization organization = new Organization("Name1", "Code1", OrganizationType.GeneralPartnership, "Owner");
            _repository.Setup(r => r.CreateAsync(It.IsAny<Organization>())).ReturnsAsync(false);

            //Act
            var result = await _controller.Create(organization);

            //Assert
            Assert.IsType<ConflictObjectResult>(result);
        }
    }
}
