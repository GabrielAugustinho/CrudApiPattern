using System.Diagnostics.CodeAnalysis;

namespace CrudApiPattern.Core.Application.OutputPort.User
{
    [ExcludeFromCodeCoverage]
    public class SearchUserOutput
    {
        public int Id { get; set; }
        public int Family { get; set; }
        public string? Name { get; set; }
        public int TotalCount { get; set; }
    }
}
