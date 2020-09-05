using static Store.Shared.Enums.Filter.Enums;

namespace Store.BusinessLogic.Filters
{
    public class UserFilter
    {
        public string PropertyName { get; set; }
        public SortType SortType { get; set; }
    }
}
