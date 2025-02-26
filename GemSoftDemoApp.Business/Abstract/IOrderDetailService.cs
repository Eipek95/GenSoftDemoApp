using GemSoftDemoApp.Dto.OrderDetailDtos;
using GemSoftDemoApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Abstract
{
    public interface IOrderDetailService :IGenericService<OrderDetail, OrderDetailDto, CreateOrderDetailDto, UpdateOrderDetailDto>
    {
    }
}
