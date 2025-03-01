using GenSoftDemoApp.Entity.Entities;
using System.Net;

namespace GenSoftDemoApp.DataAccess.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetOrdersWithDetails();
        Task<Order> GetOrderWithDetailById(int id);
        Task<Order> GetOrderWithDetailByOrderNumber(string orderNumber);
        Task<HttpStatusCode> UpdateOrder(Order order);

    }
}
