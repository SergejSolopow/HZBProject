using AutoMapper;

using BeamlineX.Api.Controllers;
using BeamlineX.Domain;
using BeamlineX.DtoMapper;
using BeamlineX.Dtos;
using BeamlineX.Repositories.Abstraction;

using FluentAssertions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Moq;

using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;

namespace BeamlineX.ApiTests
{
    public class CustomersControllerTests
    {
        private Mock<IRepository> _repositoryMoq = new();
        private IMapper _mapper = MapperExtensions.GetMapper();
        private Mock<ILogger<CustomersController>> _loggerMap = new();

        [Fact(DisplayName = "GetAll should return all Customers")]
        public async Task GetAllShouldReturnAllCustomers()
        {
            CustomersController customersController = new(_repositoryMoq.Object, _mapper, _loggerMap.Object);

            Customer customer1 = new("C1");
            Customer customer2 = new("C2");
            List<Customer> customers = new() { customer1, customer2 };
            ICollection<CustomerViewDto> customersViews = _mapper.Map<Customer, CustomerViewDto>(customers);

            _repositoryMoq.Setup(r => r.GetAllAsync<Customer>()).ReturnsAsync(customers);

            OkObjectResult? result = (await customersController.GetAll()) as OkObjectResult;

            result.Should().NotBeNull();
            Assert.Equal(200, result.StatusCode);
            result.Value.Should().BeEquivalentTo(customersViews);
        }
    }
}