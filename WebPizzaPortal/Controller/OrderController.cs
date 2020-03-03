using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebPizzaPortal.Model;
using WebPizzaPortal.Settings;

namespace WebPizzaPortal.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<OrderModel>> Get() =>
            _orderService.Get();
        
        [HttpGet("{id:length(24)}", Name = "GetOrder")]
        public ActionResult<OrderModel> Get(string id)
        {
            var orderModel = _orderService.Get(id);

            if (orderModel == null)
            {
                return NotFound();
            }

            return orderModel;
        }

        [HttpPost]
        public ActionResult<OrderModel> Create(OrderModel orderModel)
        {
            _orderService.Create(orderModel);

            return CreatedAtRoute("GetOrder", new { id = orderModel.Id.ToString() }, orderModel);
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var orderModel = _orderService.Get(id);

            if (orderModel == null)
            {
                return NotFound();
            }

            _orderService.Remove(orderModel.Id);

            return NoContent();
        }

    }
}