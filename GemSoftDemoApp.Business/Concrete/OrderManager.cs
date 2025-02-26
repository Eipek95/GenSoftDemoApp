using AutoMapper;
using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.DataAccess.Abstract;
using GemSoftDemoApp.Dto.BrandDtos;
using GemSoftDemoApp.Dto.OrderDtos;
using GemSoftDemoApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Concrete
{
    public class OrderManager : GenericManager<Order, OrderDto, CreateOrderDto, UpdateOrderDto>, IOrderService
    {
        public OrderManager(IRepository<Order> _repository, IMapper mapper) : base(_repository, mapper)
        {
        }
    }
}
