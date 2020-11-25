using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; // usamos Microsoft.AspNetCore.Mvc;

namespace ViewComponentsExample.ViewComponents
{
    public class PersonCardViewComponent : ViewComponent // que herede de ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(int id)                            //metodo invokeAsync (recib entero es el id de la lista de personas)
        {
            return Task.FromResult<IViewComponentResult>(View("CardDesign", id));
        }
    }
}
