using static Store.Shared.Enums.Filter.Enums;

namespace Store.DataAccess.Filters
{
    public class UserDataFilter
    {
        public string PropertyName { get; set; }
        public SortType SortType { get; set; }
    }
}
