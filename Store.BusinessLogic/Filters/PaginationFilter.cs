namespace Store.BusinessLogic.Filters
{
    public class PaginationFilter
    {
        public const int PageNumberByDefault = 1;
        public const int PageSizeByDefault = 10;

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationFilter()
        {
            // Default view set
            PageNumber = PageNumberByDefault;
            PageSize = PageSizeByDefault;
        }

    }
}
