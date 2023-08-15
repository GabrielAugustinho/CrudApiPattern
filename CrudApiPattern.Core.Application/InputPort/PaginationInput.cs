using System.Diagnostics.CodeAnalysis;

namespace CrudApiPattern.Core.Application.InputPort
{
    [ExcludeFromCodeCoverage]
    public class PaginationInput
    {
        public int? CurrentPage { get; set; }
        public int ItensPerPage { get; set; }
        public string SortType { get; set; }
        public string SortColum { get; set; }

        public PaginationInput(int? currentPage, int itensPerPage, string sortType, string sortColum)
        {
            CurrentPage = currentPage;
            ItensPerPage = itensPerPage;
            SortType = sortType;
            SortColum = sortColum;
        }
    }
}
