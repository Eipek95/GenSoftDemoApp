using GenSoftDemoApp.DataAccess.Abstract;
using GenSoftDemoApp.DataAccess.Context;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.DataAccess.Concrete
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
}
