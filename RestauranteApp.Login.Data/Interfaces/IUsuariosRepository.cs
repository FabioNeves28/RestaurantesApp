using RestauranteApp.Login.Infra.Models;

namespace RestauranteApp.Login.Data.IService
{
    public interface IUsuariosRepository
    {
        Usuarios Registrar(Usuarios usuario);
        Usuarios Login(Usuarios usuario);

        List<Usuarios> GetAll();
    }
}
