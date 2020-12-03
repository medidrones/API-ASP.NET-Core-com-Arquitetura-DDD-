using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;

namespace Api.Application.Test.Usuario.QuandoRequisitarUpdate
{
    public class Retorno_Updated
    {
        private UsersController _controller;

        [Fact(DisplayName = "É Possivel realizar o Updated.")]
        public async Task E_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
                new UserDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMock.Object);

            var userDtoUpdate = new UserDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = nome,
                Email = email
            };

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resulValue = ((OkObjectResult)result).Value as UserDtoUpdateResult;
            Assert.NotNull(resulValue);
            Assert.Equal(userDtoUpdate.Name, resulValue.Name);
            Assert.Equal(userDtoUpdate.Email, resulValue.Email);
        }
    }
}
