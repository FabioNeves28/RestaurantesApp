using RestauranteApp.Login.Infra.Models;

namespace RestaurantesApp.Login.Application.Repo
{
    public interface IUsuariosRepository
    {
        List<Usuarios> GetAll();
        Usuarios GetById(int id);
        Usuarios GetByEmail(string email);
        void Add(Usuarios usuario);
        void Delete(Usuarios usuario);
        void Update(Usuarios usuario);
    }
}
