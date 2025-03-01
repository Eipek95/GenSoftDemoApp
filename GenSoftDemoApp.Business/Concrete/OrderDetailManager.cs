using AutoMapper;
using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.DataAccess.Abstract;
using GenSoftDemoApp.Dto.OrderDetailDtos;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.Business.Concrete
{
    public class OrderDetailManager : GenericManager<OrderDetail, OrderDetailDto, CreateOrderDetailDto, UpdateOrderDetailDto>, IOrderDetailService
    {
        public OrderDetailManager(IRepository<OrderDetail> _repository, IMapper mapper) : base(_repository, mapper)
        {
        }
    }
}
