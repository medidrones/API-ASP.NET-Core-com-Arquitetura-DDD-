using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;

namespace Api.Application.Test.Usuario.QuandoRequisitarDelete
{
    public class Retorno_Deleted
    {
        private UsersController _controller;

        [Fact(DisplayName = "É Possivel realizar o Deleted.")]
        public async Task E_Possivel_Invocar_a_Controller_Delete()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resulValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resulValue);
            Assert.True((Boolean)resulValue);
        }
    }
}
