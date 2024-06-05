using RestaurantesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApp.Application.Interfaces.Funcionario
{
    public interface IFuncionarioRepository
    {
        IEnumerable<Funcionarios> GetAll();
        Funcionarios GetById(int id);
        void Add(Funcionarios funcionario);
        void Update(Funcionarios funcionario);
        void Delete(Funcionarios funcionario);

    }
}
