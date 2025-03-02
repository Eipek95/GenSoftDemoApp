using GenSoftDemoApp.Dto.OrderDtos;
using GenSoftDemoApp.Dto.ResponseDtos;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.Business.Abstract
{
    public interface IOrderService : IGenericService<Order, OrderDto, CreateOrderDto, UpdateOrderDto>
    {
        Task<MyResponse<List<OrderDto>>> TGetOrdersWithDetails();
        Task<MyResponse<OrderDto>> TGetOrderWithDetailById(int id);
        Task<MyResponse<OrderDto>> TGetOrderWithDetailByOrderNumber(string orderNumber);
        Task<MyResponse<NoDataDto>> TUpdateOrder(UpdateOrderDto order);
        Task<MyResponse<OrderDto>> TGetOrderWithDetailByUserId(int userId);
        Task<MyResponse<List<OrderDto>>> TGetOrdersWithDetailByUserId(int userId);
    }
}
