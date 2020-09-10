using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.Orders;
using Store.BusinessLogic.Models.Payments;
using Store.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilterModel paginationFilter,
            [FromQuery] OrderFilterModel orderFilter)
        {
            var result = await _orderService.GetOrdersAsync(paginationFilter, orderFilter);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(long orderId)
        {
            var result = await _orderService.GetOrderByIdAsync(orderId);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderModel orderModel)
        {
            await _orderService.CreateOrderAsync(orderModel);
            return Ok(orderModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(OrderModel orderModel)
        {
            var order = await _orderService.GetOrderByIdAsync(orderModel.Id);
            if (order is null)
            {
                return NotFound();
            }

            await _orderService.UpdateOrderAsync(orderModel);
            return Ok(orderModel);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(long orderId)
        {
            var result = await _orderService.GetOrderByIdAsync(orderId);
            if (result is null)
            {
                return NotFound();
            }

            await _orderService.DeleteOrderAsync(orderId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Charge(PaymentModel paymentModel)
        {
            await _orderService.OrderPaymentAsync(paymentModel);
            return Ok();
        }
    }
}
