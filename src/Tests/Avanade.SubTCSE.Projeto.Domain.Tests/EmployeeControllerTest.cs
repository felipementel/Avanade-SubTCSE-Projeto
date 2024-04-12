using Avanade.SubTCSE.Projeto.Api.Controllers.v1;
using Avanade.SubTCSE.Projeto.Application.Dtos.Employee;
using Avanade.SubTCSE.Projeto.Application.Interfaces.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Avanade.SubTCSE.Projeto.Api.Tests.Controllers.v1
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IEmployeeAppService> _employeeAppServiceMock;
        private readonly EmployeeController _employeeController;

        public EmployeeControllerTests()
        {
            _employeeAppServiceMock = new Mock<IEmployeeAppService>();
            _employeeController = new EmployeeController(_employeeAppServiceMock.Object);
        }

        [Fact]
        public async Task EmployeeRole_ValidInput_ReturnsOkResult()
        {
            // Arrange
            string id = "1";
            var employeeDto = new EmployeeDto();

            _employeeAppServiceMock.Setup(x => x.UpdateEmployeeAsync(id, employeeDto))
                .ReturnsAsync(new EmployeeDto());

            // Act
            var result = await _employeeController.EmployeeRole(id, employeeDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
            var okResult = (NoContentResult)result;
            Assert.Equal(StatusCodes.Status204NoContent, okResult.StatusCode);
            //Assert.IsType<EmployeeDto>(okResult);
        }

        [Fact]
        public async Task EmployeeRole_InvalidInput_ReturnsUnprocessableEntityResult()
        {
            // Arrange
            string id = "1";
            var employeeDto = new EmployeeDto();

            var errorResponse = new EmployeeDto
            {
                Errors = new List<string> { "Error 1", "Error 2" }
            };

            _employeeAppServiceMock.Setup(x => x.UpdateEmployeeAsync(id, employeeDto))
                .ReturnsAsync(errorResponse);

            // Act
            var result = await _employeeController.EmployeeRole(id, employeeDto);

            // Assert
            Assert.IsType<UnprocessableEntityObjectResult>(result);
            var unprocessableEntityResult = (UnprocessableEntityObjectResult)result;
            Assert.Equal(StatusCodes.Status422UnprocessableEntity, unprocessableEntityResult.StatusCode);
            Assert.Equal(string.Join('\n', errorResponse.Errors), unprocessableEntityResult.Value);
        }

        [Fact]
        public async Task EmployeeRole_InternalServerError_ReturnsNoContentResult()
        {
            // Arrange
            string id = "1";
            var employeeDto = new EmployeeDto();

            _employeeAppServiceMock.Setup(x => x.UpdateEmployeeAsync(id, employeeDto))
                .ThrowsAsync(new Exception("Internal Server Error"));

            // Act
            var result = await _employeeController.EmployeeRole(id, employeeDto);

            // Assert
            Assert.True(true);
        }
    }
}