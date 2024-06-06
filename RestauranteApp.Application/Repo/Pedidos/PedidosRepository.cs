using Microsoft.EntityFrameworkCore;
using RestauranteApp.Application.Interfaces.Pedido;
using RestaurantesApp.Data;
using RestaurantesApp.Models;

namespace RestauranteApp.Application.Repositories.Pedido
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly RestaurantesContext _context;

        public PedidosRepository(RestaurantesContext context)
        {
            _context = context;
        }
        
        public List<Pedidos> GetAll()
        {
            return _context.Pedidos.AsNoTracking().ToList();
        }
        public Pedidos GetById(int id)
        {
            return _context.Pedidos.AsNoTracking().FirstOrDefault(p => p.IdPedido == id);
        }
        public void Add(Pedidos pedido)
        {
                if (pedido == null)
                {
                    throw new ArgumentNullException(nameof(pedido));
                }
                _context.Pedidos.Add(pedido);
                _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var pedido = _context.Pedidos.FirstOrDefault(p => p.IdPedido == id);
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido));
            }
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }

        public void Update(Pedidos pedido)
        {
            var existingPedido = _context.Pedidos.FirstOrDefault(p => p.IdPedido == pedido.IdPedido);
            if (existingPedido != null)
            {
                existingPedido.Status = pedido.Status;
                existingPedido.FormaPagamento = pedido.FormaPagamento;
                existingPedido.EnderecoEntrega = pedido.EnderecoEntrega;
                existingPedido.Numero = pedido.Numero;
                existingPedido.Complemento = pedido.Complemento;
                existingPedido.Cidade = pedido.Cidade;
                existingPedido.Estado = pedido.Estado;
                existingPedido.CEP = pedido.CEP;
                existingPedido.Observacoes = pedido.Observacoes;
                existingPedido.DataPedido = pedido.DataPedido;
                existingPedido.DataEntrega = pedido.DataEntrega;

                _context.SaveChanges();
            }
        }
    }

}
    

    
    

