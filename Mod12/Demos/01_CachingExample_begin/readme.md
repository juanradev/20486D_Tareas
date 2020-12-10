## Module 12: Performance and Communication

### Lesson 1: Implementing a Caching Strategy

#### Demonstration: How to Configure Caching


Abrimos la solución del repositorio 01_CachingExample_begin

El proyecto tiene la siguiente estructura 

![c1](imagenes/c1.PNG)

Empezamos modificando [Models/Products](CachingExample/Models/Product.cs) a la que le añadimos la propiedad public DataTime LoadFromDatabase
````c#
 public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float BasePrice { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        [Display(Name = "Price")]
        public string FormattedPrice
        {
            get
            {
                return BasePrice.ToString($"C2", CultureInfo.GetCultureInfo("en-US"));
            }
        }
        [NotMapped]
        [Display(Name = "Last retrieved on")]
        public DateTime LoadedFromDatabase { get; set; }

    }
````
el mapeo de esta clase en base de datos esta

![c2](imagenes/c2.PNG)


Modificamos [Repositories/ProductRepository](CachingExample/Repositories/ProductRepository.cs)  
Añadiendo el if al metodo GetProduct  
```c#  
      public Product GetProduct(int id)
        {
            Product product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                product.LoadedFromDatabase = DateTime.Now;
            }

            return product;
        }
````
Modifcamos entonces [Views/Shared/Components/Product/SelectedProduct.cshtm](CachingExample/Views/Shared/Components/Product/SelectedProduct.cshtml) 
para mostrar el LoadedFromDatabase

y probamos a ejecutar



Hasta aqui nada nuevo. Hemos añadido un nuevo campo al modelo y lo mostramos en la vista 

![c3](imagenes/c3.PNG)  


, como ves no está cacheado  


![c4](imagenes/c4.PNG)  

Bien pues para cachearlo solo vamos a añadir <cache vary-by="@ViewBag.SelectedProductId"> a la hora de cargar el componente en la vista [Product/Index.cshtml](CachingExample/Views/Product/Index.cshtml)  
```c# 
	<cache vary-by="@ViewBag.SelectedProductId">
		<div>
			@await Component.InvokeAsync("Product", @ViewBag.SelectedProductId)
		</div>
	</cache>
````

y ahora comprobamos que se cachea en funcion del ViewBag.SelectedProductId"


Aunque refresquemos no varia

![c5](imagenes/c5.PNG) 

![c6](imagenes/c6.PNG) 


![c5](imagenes/c5.PNG) 





