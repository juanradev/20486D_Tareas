using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupcakes.Models;    // el modelo porque sino mal

namespace Cupcakes.Repositories
{
    public interface ICupcakeRepository
    {
        IEnumerable<Cupcake> GetCupcakes();                       //un CRUD
        Cupcake GetCupcakeById(int id);
        void CreateCupcake(Cupcake cupcake);
        void DeleteCupcake(int id);
        void SaveChanges();                                         // un SaveChanges
        IQueryable<Bakery> PopulateBakeriesDropDownList();          // llenar un DropDownList
    }
}
