using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.Dto.OrderDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController(IOrderService _orderService) : CustomBaseController
    {
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAll() => ActionResultInstance(await _orderService.TGetOrdersWithDetails());

        [Authorize(Roles ="Admin,User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => ActionResultInstance(await _orderService.TGetOrderWithDetailById(id));
        [HttpGet("{userId}")]
        [Authorize(Roles ="Admin,User")]
        public async Task<IActionResult> GetOrderWithDetailByUserId(int userId) => ActionResultInstance(await _orderService.TGetOrderWithDetailByUserId(userId));
        [Authorize(Roles ="Admin,User")]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrdersWithDetailByUserId(int userId) => ActionResultInstance(await _orderService.TGetOrdersWithDetailByUserId(userId));
        [Authorize(Roles ="Admin,User")]
        [HttpGet]
        public async Task<IActionResult> GetOrderWithDetailByOrderNumber(string orderNumber) => ActionResultInstance(await _orderService.TGetOrderWithDetailByOrderNumber(orderNumber));

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto orderDto) => ActionResultInstance(await _orderService.TCreate(orderDto));

        [Authorize(Roles ="Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderDto updateOrderDto) => ActionResultInstance(await _orderService.TUpdateOrder(updateOrderDto));

        [HttpDelete]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id) => ActionResultInstance(await _orderService.TDelete(id));
    }
}
