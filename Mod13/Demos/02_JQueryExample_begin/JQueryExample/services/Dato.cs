using JQueryExample.Models;
using System.Collections.Generic;
using System.Linq;


namespace JQueryExample.services
{
    public class Dato : IDato
    {
        private List<Pizza> _pizzas = new List<Pizza>();

        public Dato()
        {
            _pizzas.Add(new Pizza() { Id = 1, Toppings = "mushrooms", Price = 10 });
            _pizzas.Add(new Pizza() { Id = 2, Toppings = "extra cheese", Price = 8 });
            _pizzas.Add(new Pizza() { Id = 3, Toppings = "black olives", Price = 9 });
            _pizzas.Add(new Pizza() { Id = 4, Toppings = "pineapple", Price = 12 });
        }

        public int addPizza(Pizza pizza)
        {
            int pizzaMaxId = _pizzas.Max(i => i.Id);
            pizza.Id = ++pizzaMaxId;
            _pizzas.Add(pizza);
            return pizzaMaxId;

        }

        public IEnumerable<Pizza> GetPizzas() => _pizzas;

        public Pizza GetPizza(int id)
        {
            Pizza pizza = _pizzas.SingleOrDefault(p => p.Id == id);
            return pizza;
        }
    }
}
