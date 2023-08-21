using System.Diagnostics.CodeAnalysis;

namespace CrudApiPattern.Core.Application.InputPort.User
{
    [ExcludeFromCodeCoverage]
    public class SearchUserInput
    {
        public int? Id { get; set; }
        public int? Familia { get; set; }
        public string? Nome { get; set; }
        public PaginationInput Pagination { get; set; }
    }
}
