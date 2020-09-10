using AutoMapper;
using Store.BusinessLogic.Filters;
using Store.BusinessLogic.Models.Orders;
using Store.BusinessLogic.Models.Payments;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Filters;
using Store.DataAccess.Repositories.Interfaces;
using Stripe;
using System.Collections.Generic;
using System.Threading.Tasks;
using Order = Store.DataAccess.Entities.Order;

namespace Store.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(PaginationFilterModel pageFilter,
            OrderFilterModel orderFilter)
        {
            var mapperPageFilter = _mapper.Map<PaginationDataFilterModel>(pageFilter);
            var mappeOrderFilter = _mapper.Map<OrderDataFilterModel>(orderFilter);

            var result = await _orderRepository.GetFilteredOrdersAsync(mapperPageFilter, mappeOrderFilter);

            return result;
        }

        public async Task<Order> GetOrderByIdAsync(long orderId)
        {
            return await _orderRepository.GetByIdAsync(orderId);
        }

        public async Task<Order> CreateOrderAsync(OrderModel orderModel)
        {
            var mapperOrder = _mapper.Map<Order>(orderModel);

            return await _orderRepository.CreateAsync(mapperOrder);
        }

        public async Task DeleteOrderAsync(long orderId)
        {
            await _orderRepository.DeleteAsync(orderId);
        }

        public async Task UpdateOrderAsync(OrderModel orderModel)
        {
            var mapperOrder = _mapper.Map<Order>(orderModel);

            await _orderRepository.UpdateAsync(mapperOrder);
        }

        public async Task OrderPaymentAsync(PaymentModel paymentModel)
        {
            var customerService = new CustomerService();
            var chargeService = new ChargeService();

            var customerOption = await customerService.CreateAsync(new CustomerCreateOptions
            {
                Email = paymentModel.UserEmail,
                Source = paymentModel.StripeToken
            });

            var chargeOptions = new ChargeCreateOptions
            {
                Amount = paymentModel.Amount,
                Description = paymentModel.Description,
                Currency = paymentModel.Currency.ToString(),
                Customer = customerOption.Id,
            };

            await chargeService.CreateAsync(chargeOptions);
        }
    }
}
