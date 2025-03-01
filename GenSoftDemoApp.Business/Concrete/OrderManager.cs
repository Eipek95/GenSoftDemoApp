using AutoMapper;
using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.DataAccess.Abstract;
using GemSoftDemoApp.Dto.OrderDtos;
using GemSoftDemoApp.Dto.ResponseDtos;
using GemSoftDemoApp.Entity.Entities;

namespace GemSoftDemoApp.Business.Concrete
{
    public class OrderManager : GenericManager<Order, OrderDto, CreateOrderDto, UpdateOrderDto>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderManager(IRepository<Order> _repository, IMapper mapper, IOrderRepository orderRepository) : base(_repository, mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<MyResponse<List<OrderDto>>> TGetOrdersWithDetails()
        {
            List<Order> orders = await _orderRepository.GetOrdersWithDetails();
            if (!orders.Any())
                return MyResponse<List<OrderDto>>.Fail(new ErrorDto("Sipariş Bulunamadı", false), 404);
            var map = _mapper.Map<List<OrderDto>>(orders);
            return MyResponse<List<OrderDto>>.Success(map, 200);
        }

        public async Task<MyResponse<OrderDto>> TGetOrderWithDetailById(int id)
        {
            Order order = await _orderRepository.GetOrderWithDetailById(id);
            if (order is null)
                return MyResponse<OrderDto>.Fail(new ErrorDto("Sipariş Bulunamadı", false), 404);

            var map = _mapper.Map<OrderDto>(order);
            return MyResponse<OrderDto>.Success(map, 200);
        }

        public async Task<MyResponse<OrderDto>> TGetOrderWithDetailByOrderNumber(string orderNumber)
        {
            Order order = await _orderRepository.GetOrderWithDetailByOrderNumber(orderNumber);
            if (order is null)
                return MyResponse<OrderDto>.Fail(new ErrorDto("Sipariş Bulunamadı", false), 404);

            var map = _mapper.Map<OrderDto>(order);
            return MyResponse<OrderDto>.Success(map, 200);
        }

        public async Task<MyResponse<NoDataDto>> TUpdateOrder(UpdateOrderDto order)
        {
            var map = _mapper.Map<Order>(order);
            var result = await _orderRepository.UpdateOrder(map);
            if (result == System.Net.HttpStatusCode.NotFound)
                return MyResponse<NoDataDto>.Fail(new ErrorDto("Güncellenecek Sipariş Bulunamadı", false), 404);
            return MyResponse<NoDataDto>.Success(200);
        }
    }
}
