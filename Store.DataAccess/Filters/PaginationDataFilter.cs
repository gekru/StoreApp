namespace Store.DataAccess.Filters
{
    public class PaginationDataFilter
    {
        public readonly int firstPage = 1;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
