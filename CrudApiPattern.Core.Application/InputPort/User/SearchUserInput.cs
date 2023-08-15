using System.Diagnostics.CodeAnalysis;

namespace CrudApiPattern.Core.Application.InputPort.User
{
    [ExcludeFromCodeCoverage]
    public class SearchUserInput
    {
        public int? Id { get; set; }
        // public PaginationInput Pagination { get; set; }
    }
}
