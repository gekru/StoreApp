namespace Store.BusinessLogic.Filters
{
    public class PaginationFilterModel
    {
        // Default values 
        private int _pageNumberByDefault = 1;
        private int _pageSizeByDefault = 10;
        
        public int PageNumber
        {
            get
            {
                return _pageNumberByDefault;
            }
            set
            {
                // Value assignment, where values can not be less than 1
                _pageNumberByDefault = (value < 1) ? _pageNumberByDefault : value;
            }
        }

        public int PageSize
        {
            get
            {
                return _pageSizeByDefault;
            }
            set
            {
                // Value assignment, where values can not be less than 1
                _pageSizeByDefault = (value < 1) ? _pageSizeByDefault : value;
            }
        }
    }
}
