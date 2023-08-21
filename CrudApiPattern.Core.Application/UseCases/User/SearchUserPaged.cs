using CrudApiPattern.Core.Application.InputPort.User;
using CrudApiPattern.Core.Application.Models;
using CrudApiPattern.Core.Application.OutputPort.User;

namespace CrudApiPattern.Core.Application.UseCases.User
{
    public class SearchUserPaged : ISearchUserPaged
    {
        public PageModel<SearchUserOutput> Execute(SearchUserInput input)
        {
            try
            {
                var mockedDataBase = new List<SearchUserOutput>()
                {
                    new SearchUserOutput(){ Id = 0, Family =  0, Name = "Blitz", TotalCount = 6},
                    new SearchUserOutput(){ Id = 1, Family =  0, Name = "Gabriel", TotalCount = 6},
                    new SearchUserOutput(){ Id = 2, Family =  0, Name = "Stheppanhy", TotalCount = 6},
                    new SearchUserOutput(){ Id = 3, Family =  1, Name = "Larissa", TotalCount = 6},
                    new SearchUserOutput(){ Id = 4, Family =  1, Name = "Zezinho", TotalCount = 6},
                    new SearchUserOutput(){ Id = 5, Family =  1, Name = "Raquel", TotalCount = 6}
                };

                var userOutputList = from users in mockedDataBase
                                     where (input.Id == null || users.Id == input.Id) &&
                                           (input.Familia == null || users.Family == input.Familia) &&
                                           (input.Nome == null || users.Name == input.Nome)
                                     select users;

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
