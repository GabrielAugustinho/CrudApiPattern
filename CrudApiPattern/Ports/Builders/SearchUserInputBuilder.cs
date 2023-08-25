using CrudApiPattern.Core.Application.InputPort;
using CrudApiPattern.Core.Application.InputPort.User;
using System.Diagnostics.CodeAnalysis;

namespace CrudApiPattern.Ports.Builders
{
    [ExcludeFromCodeCoverage]
    public class SearchUserInputBuilder
    {
        private int? _Id { get; set; }
        private int? _Familia { get; set; }
        private string? _Nome { get; set; }
        private PaginationInput _Pagination { get; set; }

        public static SearchUserInputBuilder New()
        {
            return new SearchUserInputBuilder()
            {
                _Id = null,
                _Familia = null,
                _Nome = null,
                _Pagination = new PaginationInput(currentPage: 1, itensPerPage: 10, sortType: "", sortColum: "")
            };
        }

        public SearchUserInputBuilder Id(int? id)
        {
            _Id = id;
            return this;
        }

        public SearchUserInputBuilder Familia(int? familia)
        {
            _Familia = familia;
            return this;
        }

        public SearchUserInputBuilder Nome(string? nome)
        {
            _Nome = nome;
            return this;
        }

        public SearchUserInput Builder()
        {
            var input = new SearchUserInput()
            {
                Familia = _Familia,
                Id = _Id,
                Nome = _Nome,
                Pagination = _Pagination
            };

            return input;
        }
    }
}
