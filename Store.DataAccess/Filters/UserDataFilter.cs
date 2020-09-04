using Store.Shared.Enums.Filter;

namespace Store.DataAccess.Filters
{
    public class UserDataFilter
    {
        public string PropertyName { get; set; }
        public SortType SortType{ get; set; }
    }
}
