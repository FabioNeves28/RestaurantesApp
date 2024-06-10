using RestaurantesApp.Models;

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
