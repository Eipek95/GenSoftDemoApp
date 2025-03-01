using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.Dto.OrderDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController(IOrderService _orderService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => ActionResultInstance(await _orderService.TGetOrdersWithDetails()); 

        [HttpGet]
        public async Task<IActionResult> GetById(int id) => ActionResultInstance(await _orderService.TGetOrderWithDetailById(id));
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrderWithDetailByUserId(int userId) => ActionResultInstance(await _orderService.TGetOrderWithDetailByUserId(userId)); 
        
        [HttpGet]
        public async Task<IActionResult> GetOrderWithDetailByOrderNumber(string orderNumber) => ActionResultInstance(await _orderService.TGetOrderWithDetailByOrderNumber(orderNumber));

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto orderDto) => ActionResultInstance(await _orderService.TCreate(orderDto));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderDto updateOrderDto) => ActionResultInstance(await _orderService.TUpdateOrder(updateOrderDto));

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) => ActionResultInstance(await _orderService.TDelete(id));
    }
}
