using CrudApiPattern.Core.Application.Abstractions.Read;
using CrudApiPattern.Core.Application.InputPort.User;
using CrudApiPattern.Core.Application.Models;
using CrudApiPattern.Core.Application.OutputPort.User;
using CrudApiPattern.Core.Application.UseCases.User;
using CrudApiPattern.Ports.Builders;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace CrudApiPattern.Core.Application
{
    public class SearchUserPagedTest
    {
        private readonly Mock<IUserReadOnly> _userReadOnly;
        private readonly SearchUserPaged _useCase;

        public SearchUserPagedTest()
        {
            _userReadOnly = new Mock<IUserReadOnly>();

            _useCase = new SearchUserPaged(_userReadOnly.Object);
        }

        [Fact]
        public void Execute_WhenGetUsers_MustReturnSearchUserOutputPaged()
        {
            // Arrange

            var input = SearchUserInputBuilder.New().Builder();
            var output = new List<SearchUserOutput>()
            {
                SearchUserOutputBuilder.New().Name("Gabriel").Id(0).Family(0).TotalCount(2).Builder(),
                SearchUserOutputBuilder.New().Name("Stheppany").Id(1).Family(0).TotalCount(2).Builder()
            };

            var expectedResult = new PageModel<SearchUserOutput>(itemsPerPage: input.Pagination.ItensPerPage,
                                                                 numberPage: input.Pagination.CurrentPage,
                                                                 totalItems: output.Any() ? output.First().TotalCount : 0,
                                                                 sortOrder: input.Pagination.SortType,
                                                                 sortColumn: input.Pagination.SortColum)
            {
                Items = output,
                TotalRecords = output.Count()
            };

            _userReadOnly.Setup(x => x.GetUsers(It.IsAny<SearchUserInput>()))
                         .Returns(output);

            // Act
            var result = _useCase.Execute(input);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(result));

            _userReadOnly.Verify(x => x.GetUsers(It.IsAny<SearchUserInput>()), Times.Once);
        }

        [Fact]
        public void Execute_WhenError_MustReturnDefault()
        {
            // Arrange

            var input = SearchUserInputBuilder.New().Builder();

            _userReadOnly.Setup(x => x.GetUsers(It.IsAny<SearchUserInput>()))
                         .Throws(new Exception("Teste"));

            // Act
            var result = _useCase.Execute(input);

            // Assert
            Assert.Equal(default!, result);

            _userReadOnly.Verify(x => x.GetUsers(It.IsAny<SearchUserInput>()), Times.Once);
        }
    }
}
