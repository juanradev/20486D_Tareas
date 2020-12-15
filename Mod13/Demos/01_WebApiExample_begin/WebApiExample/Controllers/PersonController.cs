using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;
using System.Text.Json;


namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private List<Person> _people = new List<Person>();

        public PersonController()
        {
            _people.Add(new Person() { Id = 1, FirstName = "James", LastName = "Sprayberry" });
            _people.Add(new Person() { Id = 2, FirstName = "Jason", LastName = "Mosley" });
            _people.Add(new Person() { Id = 3, FirstName = "Jennifer", LastName = "Dietz" });
            _people.Add(new Person() { Id = 4, FirstName = "Bessie", LastName = "Duppstadt" });
        }


        
        public List<Person> GetAll()
        {
                return _people;
        }
        [HttpGet("GetAllXml")]
        [Produces("application/xml")]
        public List<Person> GetAllXml()
        {
            return _people;
        }

        [HttpGet("GetId/{id}")]
        [HttpPost("GetId/{id}")]
        public string GetId(int id)
        {
            return "el parametro es " + id.ToString();
        }

        [HttpGet("GetPbyId/{id}")]
        [Produces("application/json")]
        public IActionResult GetPbyId(int id)
        {

            string json = default;
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person != null)
                json = JsonSerializer.Serialize(person);
            else
                 json = "{\"Id\":"+id + ", \"DirstName\":\"NOT FORUND\"}";
            return Ok(json);
           // return Content(json);
        }


        [HttpGet("GetPersonByID/{id}")]
        public ActionResult<Person> GetPersonByID(int id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }
    }
}
