using GemSoftDemoApp.Dto.OrderDtos;
using GemSoftDemoApp.Dto.ResponseDtos;
using GemSoftDemoApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.DataAccess.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetOrdersWithDetails();
        Task<Order> GetOrderWithDetailById(int id);
        Task<Order> GetOrderWithDetailByOrderNumber(string orderNumber);
        Task<HttpStatusCode> UpdateOrder(Order order);

    }
}
