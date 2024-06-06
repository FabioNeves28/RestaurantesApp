using RestauranteApp.Login.Data.IService;
using RestauranteApp.Login.Infra.Common;
using RestauranteApp.Login.Infra.Models;

namespace RestauranteApp.Login.Data.Service
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public List<Usuarios> GetAll()
        {
            return Global.Usuarios;
        }

        public Usuarios Login(Usuarios usuarios)
        {

            var user= Global.Usuarios.SingleOrDefault(x => x.Email == usuarios.Senha);

            bool IsValidPassword = BCrypt.Net.BCrypt.Verify(usuarios.Senha, user.Senha);

            if (user != null && IsValidPassword)
                return user;

            return null;
            
        }

        public Usuarios Registrar(Usuarios usuario)
        {
            usuario.Id = Global.Usuarios.Count + 1;
            Global.Usuarios.Add(usuario);
            return usuario;
        }

    }
}
