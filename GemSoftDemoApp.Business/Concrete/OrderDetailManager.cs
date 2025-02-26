using AutoMapper;
using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.DataAccess.Abstract;
using GemSoftDemoApp.Dto.BrandDtos;
using GemSoftDemoApp.Dto.OrderDetailDtos;
using GemSoftDemoApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Concrete
{
    public class OrderDetailManager : GenericManager<OrderDetail, OrderDetailDto, CreateOrderDetailDto, UpdateOrderDetailDto>, IOrderDetailService
    {
        public OrderDetailManager(IRepository<OrderDetail> _repository, IMapper mapper) : base(_repository, mapper)
        {
        }
    }
}
