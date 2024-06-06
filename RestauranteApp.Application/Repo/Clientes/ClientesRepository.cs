using Microsoft.EntityFrameworkCore;
using RestaurantesApp.Models;
using RestaurantesApp.Data;
using RestauranteApp.Application.Interfaces.Cliente;
namespace RestauranteApp.Application.Repositories.Cliente
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly RestaurantesContext _context;

        public ClientesRepository(RestaurantesContext context)
        {
            _context = context;
        }

        public IEnumerable<Clientes> GetAll()
        {
            return _context.Clientes.AsNoTracking().ToList();
        }

        public Clientes GetById(int id)
        {
            return _context.Clientes.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public void Add(Clientes cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Update(Clientes cliente)
        {
            var existingCliente = _context.Clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (existingCliente != null)
            {
                existingCliente.Nome = cliente.Nome;
                existingCliente.CPF = cliente.CPF;
                existingCliente.Email = cliente.Email;
                existingCliente.Telefone = cliente.Telefone;
                existingCliente.Senha = cliente.Senha;
                existingCliente.Endereco = cliente.Endereco;
                existingCliente.Numero = cliente.Numero;
                existingCliente.Complemento = cliente.Complemento;
                existingCliente.Cidade = cliente.Cidade;
                existingCliente.Estado = cliente.Estado;
                existingCliente.CEP = cliente.CEP;

                _context.SaveChanges();
            }
        }

        public void Delete(Clientes cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }
}
