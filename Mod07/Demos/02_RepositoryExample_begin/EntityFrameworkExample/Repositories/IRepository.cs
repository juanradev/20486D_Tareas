using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExample.Models; // Añadimos el using
namespace EntityFrameworkExample.Repositories
{
    public interface IRepository
    {
        IEnumerable<Person> GetPeople();
        void CreatePerson();
        void UpdatePerson(int id);
        void DeletePerson(int id);
    }
}
