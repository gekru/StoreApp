using Microsoft.EntityFrameworkCore;
using Store.DataAccess.AppContext;
using Store.DataAccess.Entities;
using Store.DataAccess.Extensions;
using Store.DataAccess.Filters;
using Store.DataAccess.Repositories.Base;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class OrderRepository : BaseEFRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }
       
        public async Task<IEnumerable<Order>> GetFilteredOrdersAsync(PaginationDataFilterModel pageFilter,
          OrderDataFilterModel orderFilter)
        {
            var authors = _entityDbSet.AsQueryable();

            if (orderFilter.PropertyName is not null)
            {
                authors = authors.OrderBy(orderFilter.PropertyName, orderFilter.SortType.ToString());
            }

            var skip = (pageFilter.PageNumber - pageFilter.firstPage) * pageFilter.PageSize;

            var result = await authors.Skip(skip).Take(pageFilter.PageSize).ToListAsync();

            return result;
        }
    }
}
