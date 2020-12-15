using System.Collections.Generic;
using JQueryExample.Models;
namespace JQueryExample.services
{
    public interface IDato
    {
        IEnumerable<Pizza> GetPizzas();
        Pizza GetPizza(int id);
        int addPizza(Pizza pizza);
     }
}
