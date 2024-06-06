using RestaurantesApp.Models;

namespace RestauranteApp.Application.Interfaces.Pedido
{
    public interface IPedidosRepository
    {
        List<Pedidos> GetAll();
        Pedidos GetById(int id);
        void Add(Pedidos pedido);
        void Delete(int id);
        void Update(Pedidos pedido);

        
    }
}
