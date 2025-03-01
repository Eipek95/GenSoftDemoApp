using GenSoftDemoApp.Dto.OrderDetailDtos;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.Business.Abstract
{
    public interface IOrderDetailService :IGenericService<OrderDetail, OrderDetailDto, CreateOrderDetailDto, UpdateOrderDetailDto>
    {
    }
}
