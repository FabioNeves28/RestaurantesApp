using Microsoft.EntityFrameworkCore;
using RestauranteApp.Login.Infra.Exceptions;
using RestauranteApp.Login.Infra.Models;
using RestaurantesApp.Data;
using System.Net;

namespace RestaurantesApp.Login.Application.Repo
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly LoginContext _loginContext;
        public UsuariosRepository(LoginContext loginContext) 
        { 
             _loginContext = loginContext; 
        }
        public void Add(Usuarios usuario)
        {
            _loginContext.Usuarios.Add(usuario);
            _loginContext.SaveChanges();
        }
        public void Update(Usuarios usuario) {
            _loginContext.Usuarios.Update(usuario);
            _loginContext.SaveChanges();
        }
        public List<Usuarios> GetAll()
        {
            return _loginContext.Usuarios.ToList();
        }
        public Usuarios GetById(int id)
        {

            return _loginContext.Usuarios.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public void Delete(Usuarios usuario)
        {
            
            _loginContext.Usuarios.Remove(usuario);
            _loginContext.SaveChanges();
        }

        public Usuarios GetByEmail(string email)
        {
            try
            {
                return _loginContext.Usuarios.AsEnumerable().SingleOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            }
            catch (DbUpdateException ex)
            {
             
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError, "An error occurred while adding the user.", ex);
            }
        }




    }
}
