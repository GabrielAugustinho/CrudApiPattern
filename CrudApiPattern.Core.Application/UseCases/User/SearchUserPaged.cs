using CrudApiPattern.Core.Application.Abstractions.Read;
using CrudApiPattern.Core.Application.InputPort.User;
using CrudApiPattern.Core.Application.Models;
using CrudApiPattern.Core.Application.OutputPort.User;

namespace CrudApiPattern.Core.Application.UseCases.User
{
    public class SearchUserPaged : ISearchUserPaged
    {
        private readonly IUserReadOnly _userReadOnly;

        public SearchUserPaged(IUserReadOnly userReadOnly)
        {
            _userReadOnly = userReadOnly;
        }

        public PageModel<SearchUserOutput> Execute(SearchUserInput input)
        {
            try
            {
                var userOutputList = _userReadOnly.GetUsers(input);

                var page = new PageModel<SearchUserOutput>(itemsPerPage: input.Pagination.ItensPerPage,
                                                           numberPage: input.Pagination.CurrentPage,
                                                           totalItems: userOutputList.Any() ? userOutputList.First().TotalCount : 0,
                                                           sortOrder: input.Pagination.SortType,
                                                           sortColumn: input.Pagination.SortColum)
                {
                    Items = userOutputList,
                    TotalRecords = userOutputList.Count()
                };

                return page;
            }
            catch
            {
                return default!;
            }
        }
    }
}
