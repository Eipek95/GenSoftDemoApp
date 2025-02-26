using GemSoftDemoApp.Dto.BrandDtos;
using GemSoftDemoApp.Dto.OrderDtos;
using GemSoftDemoApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Abstract
{
    public interface IOrderService: IGenericService<Order, OrderDto, CreateOrderDto, UpdateOrderDto>
    {
    }
}
