using RestauranteApp.Login.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
