using CrudApiPattern.Core.Application.InputPort.User;
using CrudApiPattern.Core.Application.Models;
using CrudApiPattern.Core.Application.OutputPort.User;
using CrudApiPattern.Core.Application.UseCases.User;
using CrudApiPattern.Ports.Api.Controllers.v1;
using CrudApiPattern.Ports.Builders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CrudApiPattern.Ports.Controllers
{
    public class UserControllerTest
    {
        private readonly Mock<ILogger<UserController>> _logger;
        private readonly Mock<ISearchUserPaged> _searchUserPaged;

        private readonly UserController _userController;

        public UserControllerTest()
        {
            _logger = new Mock<ILogger<UserController>>();
            _searchUserPaged = new Mock<ISearchUserPaged>();

            _userController = new UserController(_logger.Object, _searchUserPaged.Object);
        }

        [Fact]
        public void SelectUser_WhenSelected_MustReturnOkObjectResult()
        {
            // Arrange
            var input = SearchUserInputBuilder.New()
                                              .Id(0)
                                              .Familia(0)
                                              .Nome("Gabriel")
                                              .Builder();

            var output = SearchUserOutputBuilder.New()
                                                    .TotalCount(1)
                                                    .Id(0)
                                                    .Family(0)
                                                    .Name("Gabriel")
                                                    .Builder();

            var outputList = new List<SearchUserOutput>
            {
                output
            };

            var page = new PageModel<SearchUserOutput>(itemsPerPage: 30)
            {
                Items = outputList
            };

            _searchUserPaged.Setup(x => x.Execute(It.IsAny<SearchUserInput>()))
                            .Returns(page);

            // Act
            var result = _userController.SelectUser(input);

            // Assert
            Assert.IsType<OkObjectResult>(result);

            _searchUserPaged.Verify(x => x.Execute(It.IsAny<SearchUserInput>()), Times.Once);
        }

        [Fact]
        public void SelectUser_WhenThrows_MustReturnBadRequestObjectResult()
        {
            // Arrange
            var input = SearchUserInputBuilder.New()
                                              .Id(0)
                                              .Familia(0)
                                              .Nome("Gabriel")
                                              .Builder();

            _searchUserPaged.Setup(x => x.Execute(It.IsAny<SearchUserInput>()))
                            .Throws(new Exception("Teste"));

            // Act
            var result = _userController.SelectUser(input);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);

            _searchUserPaged.Verify(x => x.Execute(It.IsAny<SearchUserInput>()), Times.Once);
        }
    }
}
