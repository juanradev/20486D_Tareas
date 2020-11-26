### Module 6: Developing Models

#### Lab: Developing Models


Se trata de crear un formulario para que si el modelo es válido presentarlo en un Index



#### Exercise 1: Adding a Model

El primer paso es añadir el modelo ya que Models.Butterfly esta vacia, nos creamos también ButterfliesShop

````
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesShop.Models
{
    public class Butterfly
    {
        public int Id { get; set; }
        public string CommonName { get; set; }
        public Family? ButterflyFamily { get; set; }
        public int? Quantity { get; set; }
        public string Characteristics { get; set; }
        public DateTime CreatedDate { get; set; }
        public IFormFile PhotoAvatar { get; set; }   // Microsoft.AspNetCore.Http;
        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesShop.Models
{
    public class IndexViewModel
    {
        public List<Butterfly> Butterflies { get; set; }
    }
}
````````



Lo siquiente es usar el modelo en las vistas para ello modificamos Index.cshtml  
En esta le pasamos IndexViewModel que es una lista  
y recorremos con un foreach para mostrar las mariposas  

Ademas un button con onclick="location.href='@Url.Action("Create", "Butterfly")'"  

````
@model ButterfliesShop.Models.IndexViewModel
@{ Layout = null; }

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
    <link type="text/css" rel="stylesheet" href="~/css/butterflies-shop-styles.css" />
</head>
<body>
    <div class="container">
        <h1 class="main-title">Butterflies Shop</h1>
        <p class="into">Welcome to our Web Store, Enjoy a Wide Variety of Butterflies</p>
        <p class="into">Our Butterflies in the Shop</p>
        <button type="button" onclick="location.href='@Url.Action("Create", "Butterfly")'">Add Butterflies</button>
        <div class="img-container">
            @foreach (var item in Model.Butterflies)
            {
                <div class="photo-index-card">
                    <p>@item.CommonName</p>
                    <p>@item.ButterflyFamily</p>
                    <p>@item.Quantity</p>
                    <p>@item.CreatedDate</p>
                </div>
        }
        </div>
    </div>
</body>
</html>
``````

Y por último hay que pasar el modelo del controlador a la vista 
Tambien nos piden añadir Systm.IO pero sera para despues pintar la foto

````
public IActionResult Index()
{
	IndexViewModel indexViewModel = new IndexViewModel();
	indexViewModel.Butterflies = _data.ButterfliesList;
	return View(indexViewModel);
}
		
````


![c4](images/c4.PNG)


No pulses el buton porque la accion create no está implementada

![c5](images/c5.PNG)


Para la Accion create vamos a implementar dos metodos (GET) y (POST)


Bien el [HttpGet] tiene un error en el lak 
viene return View();
y habrá que pasarle también el modelo porque si no peta   
solucion return View(new Butterfly());  

````
		[HttpGet]
        public IActionResult Create()
        {
			 
             return View(new Butterfly());
        }

        [HttpPost]
        public IActionResult Create(Butterfly butterfly)
        {
            Butterfly lastButterfly = _data.ButterfliesList.LastOrDefault();
            butterfly.CreatedDate = DateTime.Today;
            if (butterfly.PhotoAvatar != null && butterfly.PhotoAvatar.Length > 0)
            {
                butterfly.ImageMimeType = butterfly.PhotoAvatar.ContentType;
                butterfly.ImageName = Path.GetFileName(butterfly.PhotoAvatar.FileName);
                butterfly.Id = lastButterfly.Id + 1;
                _butterfliesQuantityService.AddButterfliesQuantityData(butterfly);
                using (var memoryStream = new MemoryStream())
                {
                    butterfly.PhotoAvatar.CopyTo(memoryStream);
                    butterfly.PhotoFile = memoryStream.ToArray();
                }
                _data.AddButterfly(butterfly);
                return RedirectToAction("Index");
            }
            return View(butterfly);
        }
````		


#### Exercise 2: Working with Forms

vamos a decorar el modelo con System.ComponentModel.DataAnnotations;

````
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ButterfliesShop.Models
{
    public class Butterfly
    {
        public int Id { get; set; }
        [Display(Name = "Common Name:")]
        public string CommonName { get; set; }
        [Display(Name = "Butterfly Family:")]
        public Family? ButterflyFamily { get; set; }
        [Display(Name = "Butterflies Quantity:")]
        public int? Quantity { get; set; }
        public string Characteristics { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Updated on:")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Butterflies Picture:")]
        public IFormFile PhotoAvatar { get; set; }
        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }

    }
}
````

Como vamos a trabajar con ficheros e imagenes...
implementamos la accion GetImage(int id) que retorna un File  

````
  public IActionResult GetImage(int id)
        {
            Butterfly requestedButterfly = _data.GetButterflyById(id);
            if (requestedButterfly != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedButterfly.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes, requestedButterfly.ImageMimeType);
                }
                else
                {
                    if (requestedButterfly.PhotoFile.Length > 0)
                    {
                        return File(requestedButterfly.PhotoFile, requestedButterfly.ImageMimeType);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            else
            {
                return NotFound();
            }
        }

````
y como tenemos la imagen retocamos la index

````
@foreach (var item in Model.Butterflies)
            {
                <div class="photo-index-card">
                    <h3 class="display-picture-title">
                        "@Html.DisplayFor(modelItem => item.CommonName)"
                    </h3>
                    @if (item.ImageName != null)
                    {
                        <div class="photo-display">
                            <img class="photo-display-img" src="@Url.Action("GetImage", "Butterfly", new { Id = item.Id })" />
                        </div>
                    }
                    <div>
                        <p class="display-label">
                            @Html.DisplayNameFor(model => item.ButterflyFamily)
                        </p>
                        <br />
                        <p class="display-field">
                            @Html.DisplayFor(model => item.ButterflyFamily)
                        </p>
                    </div>
                    <div class="display-info">
                        <p class="display-label">
                            @Html.DisplayNameFor(model => item.Characteristics)
                        </p>
                        <p class="display-field">
                            @Html.DisplayFor(model => item.Characteristics)
                        </p>
                    </div>
                    <div>
                        <p class="display-label">
                            @Html.DisplayNameFor(model => item.Quantity)
                        </p>
                        <p class="display-field">
                            @Html.DisplayFor(model => item.Quantity)
                        </p>
                    </div>
                    <div>
                        <p class="display-label">
                            @Html.DisplayNameFor(model => item.CreatedDate)
                        </p>
                        <p class="display-field">
                            @Html.DisplayFor(model => item.CreatedDate)
                        </p>
                    </div>
                </div>
            }
````


Ahora nos metemos con la Create.cshtml

````
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Create</title>
    <link type="text/css" rel="stylesheet" href="~/css/butterflies-shop-styles.css" />
</head>
<body>
    <div class="container">
        <h1 class="main-title">Add Butterflies to the Shop</h1>
        <form method="post" enctype="multipart/form-data" asp-action="Create">
            <div class="form-field">
                <label asp-for="CommonName"></label>
                <input asp-for="CommonName" />
            </div>
            <div class="form-field">
                <label asp-for="ButterflyFamily"></label>
                <select asp-for="ButterflyFamily" asp-items="Html.GetEnumSelectList<Family>()">
                    <option selected="selected" value="">Select</option>
                </select>
            </div>
            <div class="form-field">
                <label asp-for="Characteristics"></label>
                <textarea asp-for="Characteristics"></textarea>
            </div>
            <div class="form-field">
                <label asp-for="Quantity"></label>
                <input asp-for="Quantity" />
            </div>
            <div class="form-field">
                <label asp-for="PhotoAvatar"></label>
                <input asp-for="PhotoAvatar" type="file" />
            </div>
            <div class="form-field">
                <input type="submit" value="Submit" />
            </div>
        </form>
    </div>
</body>
</html>
````

Probamos la aplicacion

![c6](images/c6.PNG)


Al hacer click esto te pasaría si no le hubiesemos pasado el modelo  

![c7](images/c7.PNG)

Pero como nosotros si se lo pasamos..  

![c8](images/c8.PNG)

abrimos el formulario sin problema  

![c9](images/c9.PNG)

y añadimos nuestra mariposa  

![c10](images/c10.PNG)

#### Exercise 3: Adding Validation


Para añadirle validación volvemos a decorar la clase Butterfly con atributos de validacion..


````
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ButterfliesShop.Models
{
    public class Butterfly
    {
        public int Id { get; set; }
        [Display(Name = "Common Name:")]
        [Required(ErrorMessage = "Please enter the butterfly name")]
        public string CommonName { get; set; }
        [Display(Name = "Butterfly Family:")]
        [Required(ErrorMessage = "Please select the butterfly family")]
        public Family? ButterflyFamily { get; set; }
        [Display(Name = "Butterflies Quantity:")]
        [Required(ErrorMessage = "Please select the butterfly quantity")]
        public int? Quantity { get; set; }
        [Required(ErrorMessage = "Please type the characteristics")]
        [StringLength(50)]
        public string Characteristics { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Updated on:")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Butterflies Picture:")]
        [Required(ErrorMessage = "Please select the butterflies picture")]
        public IFormFile PhotoAvatar { get; set; }
        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }

    }
}
````


`
Ahora vamos a Create.cshtml para añadirle las tagHelpers de validacion

````
<form method="post" enctype="multipart/form-data" asp-action="Create">
	<div asp-validation-summary="All"></div>  <!--               validation sumary               -->
	<div class="form-field">
		<label asp-for="CommonName"></label>
		<input asp-for="CommonName" />
		<span asp-validation-for="CommonName"></span> <!--               validation for               -->
	</div>
	.....................
			
````

And finally modificamos el POST Create con ModelState.IsValid

````
 [HttpPost]
        public IActionResult Create(Butterfly butterfly)
        {
            if (ModelState.IsValid)
            {
                Butterfly lastButterfly = _data.ButterfliesList.LastOrDefault();
                butterfly.CreatedDate = DateTime.Today;
                if (butterfly.PhotoAvatar != null && butterfly.PhotoAvatar.Length > 0)
                {
                    butterfly.ImageMimeType = butterfly.PhotoAvatar.ContentType;
                    butterfly.ImageName = Path.GetFileName(butterfly.PhotoAvatar.FileName);
                    butterfly.Id = lastButterfly.Id + 1;
                    _butterfliesQuantityService.AddButterfliesQuantityData(butterfly);
                    using (var memoryStream = new MemoryStream())
                    {
                        butterfly.PhotoAvatar.CopyTo(memoryStream);
                        butterfly.PhotoFile = memoryStream.ToArray();
                    }
                    _data.AddButterfly(butterfly);
                    return RedirectToAction("Index");
                }
                return View(butterfly);
            }
            return View(butterfly);
        }
````	

![c11](images/c11.PNG)


Y para terminar un custom Validation

Esto es sencillo creamos Validators.MaxButterflyQuantityValidation
(depende de lo que quieras complicarlo que un valor sea >5 o la lógica que le quieras meter  
pero basicamente que herede : ValidationAttribute
y sobreescriba  protected override ValidationResult IsValid(object value, ValidationContext validationContext)   


````
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterfliesShop.Models;
using ButterfliesShop.Services;
using System.ComponentModel.DataAnnotations;

namespace ButterfliesShop.Validators
{
    public class MaxButterflyQuantityValidation : ValidationAttribute
    {
        private int _maxAmount;
        public MaxButterflyQuantityValidation(int maxAmount)
        {
            _maxAmount = maxAmount;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IButterfliesQuantityService)validationContext.GetService(typeof(IButterfliesQuantityService));
            Butterfly butterfly = (Butterfly)validationContext.ObjectInstance;
            if (butterfly.ButterflyFamily != null)
            {
                int? quantity = service.GetButterflyFamilyQuantity(butterfly.ButterflyFamily.Value);
                int? sumQuantity = quantity + butterfly.Quantity;
                if (sumQuantity > _maxAmount)
                {
                    return new ValidationResult(string.Format("Limit of butterflies from the same family in the store is {0} butterflies. Currently there are {1}", _maxAmount, quantity));
                }
                return ValidationResult.Success;
            }
            return ValidationResult.Success;
        }
    }
}
````

le añadimos a la vista create  
using ButterfliesShop.Validators;
y decoramos quanty añadiendo
[MaxButterflyQuantityValidation(50)]

![c12](images/c12.PNG)