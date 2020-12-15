using Microsoft.AspNetCore.Mvc;
using JQueryExample.Models;
using JQueryExample.services;

namespace JQueryExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private IDato _mypizzas;             //      injeccion de depencia

        public PizzaController(IDato mypizzas)
        {
            _mypizzas = mypizzas;
        }

        [HttpGet("{id}")]
        public ActionResult<Pizza> GetById(int id)
        {

            Pizza pizza = _mypizzas.GetPizza(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return pizza;
        }

        [HttpPost]
        public ActionResult<Pizza> Post(Pizza pizza)
        {
            int pizzaMaxId =  _mypizzas.addPizza(pizza);

            return CreatedAtAction(nameof(GetById), new { id = pizza.Id },pizza);
        }

    }
}
