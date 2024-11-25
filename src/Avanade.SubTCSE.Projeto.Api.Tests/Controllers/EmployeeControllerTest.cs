using Avanade.SubTCSE.Projeto.Api.Controllers.v1;
using Avanade.SubTCSE.Projeto.Application.Dtos.Employee;
using Avanade.SubTCSE.Projeto.Application.Interfaces.Employee;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Avanade.SubTCSE.Projeto.Api.Tests.Controllers
{
    public class EmployeeControllerTest
    {
        private readonly Mock<IEmployeeAppService> _mockEmployeeAppService;
        private readonly EmployeeController _controller;

        public EmployeeControllerTest()
        {
            _mockEmployeeAppService = new Mock<IEmployeeAppService>();
            _controller = new EmployeeController(_mockEmployeeAppService.Object);
        }

        [Fact]
        public async Task GetEmployeeAsync_ReturnsOkResult_WithEmployee()
        {
            // Arrange
            var employeeId = "1";
            var employeeDto = new EmployeeDto { Identificador = employeeId, PrimeiroNome = "Felipe" };
            _mockEmployeeAppService.Setup(service => service.GetEmployeeAsync(employeeId))
                .ReturnsAsync(employeeDto);

            // Act
            var result = await _controller.GetById(employeeId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<EmployeeDto>(okResult.Value);
            Assert.Equal(employeeId, returnValue.Identificador);
        }
    }
}
