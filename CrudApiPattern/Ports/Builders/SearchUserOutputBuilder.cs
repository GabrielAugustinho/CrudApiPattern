using CrudApiPattern.Core.Application.OutputPort.User;

namespace CrudApiPattern.Ports.Builders
{
    public class SearchUserOutputBuilder
    {
        private int _Id { get; set; }
        private int _Family { get; set; }
        private string _Name { get; set; }
        private int _TotalCount { get; set; }

        public static SearchUserOutputBuilder New()
        {
            return new SearchUserOutputBuilder();
        }

        public SearchUserOutputBuilder Id(int id)
        {
            _Id = id;
            return this;
        }

        public SearchUserOutputBuilder Family(int family)
        {
            _Family = family;
            return this;
        }

        public SearchUserOutputBuilder Name(string name)
        {
            _Name = name;
            return this;
        }

        public SearchUserOutputBuilder TotalCount(int totalCount)
        {
            _TotalCount = totalCount;
            return this;
        }

        public SearchUserOutput Builder()
        {
            var input = new SearchUserOutput(_Id, _Family, _Name, _TotalCount);

            return input;
        }
    }
}
