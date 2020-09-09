using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.Orders;
using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(OrderModel orderModel);
        Task DeleteOrderAsync(long orderId);
        Task<Order> GetOrderByIdAsync(long orderId);
        Task<IEnumerable<Order>> GetOrdersAsync(PaginationFilterModel pageFilter, OrderFilterModel orderFilter);
        Task UpdateOrderAsync(OrderModel orderModel);
    }
}
