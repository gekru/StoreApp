namespace Store.DataAccess.Filters
{
    public class PaginationDataFilterModel
    {
        public readonly int firstPage = 1;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
