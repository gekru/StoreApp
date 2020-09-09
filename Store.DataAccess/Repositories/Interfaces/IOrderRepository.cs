using Store.DataAccess.Entities;
using Store.DataAccess.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetFilteredOrdersAsync(PaginationDataFilterModel pageFilter, OrderDataFilterModel orderFilter);
    }
}
