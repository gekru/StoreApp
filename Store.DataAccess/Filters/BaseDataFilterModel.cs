using static Store.Shared.Enums.Enums;

namespace Store.DataAccess.Filters
{
    public class BaseDataFilterModel
    {
        public string PropertyName { get; set; }
        public SortType SortType { get; set; }
    }
}
