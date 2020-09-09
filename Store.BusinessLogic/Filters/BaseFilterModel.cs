using static Store.Shared.Enums.Enums;

namespace Store.BusinessLogic.Filters
{
    public class BaseFilterModel
    {
        public string PropertyName { get; set; }
        public SortType SortType { get; set; }
    }
}
