using GemSoftDemoApp.Dto.BrandDtos;
using GemSoftDemoApp.Dto.OrderDtos;
using GemSoftDemoApp.Dto.ResponseDtos;
using GemSoftDemoApp.Entity.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Abstract
{
    public interface IOrderService: IGenericService<Order, OrderDto, CreateOrderDto, UpdateOrderDto>
    {
        Task<MyResponse< List<OrderDto>>> TGetOrdersWithDetails();
        Task<MyResponse<OrderDto>> TGetOrderWithDetailById(int id);
        Task<MyResponse<OrderDto>> TGetOrderWithDetailByOrderNumber(string orderNumber);
        Task<MyResponse<NoDataDto>> TUpdateOrder(UpdateOrderDto order);

    }
}
