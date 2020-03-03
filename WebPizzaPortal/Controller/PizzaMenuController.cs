using WebPizzaPortal.Model;
using WebPizzaPortal.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebPizzaPortal.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaMenuController : ControllerBase
    {
        private readonly PizzaService _pizzaService;

        public PizzaMenuController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public ActionResult<List<PizzaModel>> Get() =>
            _pizzaService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPizza")]
        public ActionResult<PizzaModel> Get(string id)
        {
            var pizzaModel = _pizzaService.Get(id);

            if (pizzaModel == null)
            {
                return NotFound();
            }

            return pizzaModel;
        }

        [HttpPost]
        public ActionResult<PizzaModel> Create(PizzaModel pizzaModel)
        {
            _pizzaService.Create(pizzaModel);

            return CreatedAtRoute("GetPizza", new { id = pizzaModel.Id.ToString() }, pizzaModel);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, PizzaModel pizzaModelIn)
        {
            var pizzaModel = _pizzaService.Get(id);

            if (pizzaModel == null)
            {
                return NotFound();
            }

            _pizzaService.Update(id, pizzaModelIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var pizzaModel = _pizzaService.Get(id);

            if (pizzaModel == null)
            {
                return NotFound();
            }

            _pizzaService.Remove(pizzaModel.Id);

            return NoContent();
        }
    }
}