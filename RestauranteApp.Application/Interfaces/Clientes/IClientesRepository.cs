using RestaurantesApp.Models;
using System.Collections.Generic;

namespace RestauranteApp.Application.Interfaces.Cliente
{
    public interface IClientesRepository
    {
        IEnumerable<Clientes> GetAll();
        Clientes GetById(int id);
        void Add(Clientes cliente);
        void Update(Clientes cliente);
        void Delete(Clientes cliente);
    }
}
