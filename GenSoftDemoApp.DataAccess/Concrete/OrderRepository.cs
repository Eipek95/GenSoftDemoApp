using GenSoftDemoApp.DataAccess.Abstract;
using GenSoftDemoApp.DataAccess.Context;
using GenSoftDemoApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace GenSoftDemoApp.DataAccess.Concrete
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Order> GetOrderWithDetailByOrderNumber(string orderNumber)
        {
            Order? order = await _context.Orders
                .AsNoTracking()
                .Where(p => p.OrderNumber == orderNumber)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product).FirstOrDefaultAsync();
            return order;
        }

        public async Task<List<Order>> GetOrdersWithDetails()
        {
            List<Order>? orders = await _context.Orders
                .AsNoTracking()
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .ToListAsync();
            return orders;
        }

        public async Task<Order> GetOrderWithDetailById(int id)
        {
            Order? order = await _context.Orders
                .AsNoTracking()
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .FirstOrDefaultAsync(x => x.Id == id);
            return order;
        }

        public async Task<HttpStatusCode> UpdateOrder(Order order)
        {
            var existingOrder = await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == order.Id);
            if (existingOrder is null)
                return HttpStatusCode.NotFound;


            existingOrder.Status = order.Status;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
