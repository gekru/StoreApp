using Store.Shared.Enums.Filter;

namespace Store.BusinessLogic.Filters
{
    public class UserFilter
    {
        public string PropertyName { get; set; }
        public SortType SortType { get; set; }
    }
}
