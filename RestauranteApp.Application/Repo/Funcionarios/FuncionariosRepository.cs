using Microsoft.EntityFrameworkCore;
using RestauranteApp.Application.Interfaces.Funcionario;
using RestaurantesApp.Data;
using RestaurantesApp.Models;

namespace RestauranteApp.Application.Repositories.Funcionario
{
    public class FuncionariosRepository : IFuncionarioRepository
    {

        private readonly RestaurantesContext _context;  

        public FuncionariosRepository(RestaurantesContext context) 
        {

        _context = context;

        }
        public IEnumerable<Funcionarios> GetAll()
        {
            return _context.Funcionarios.AsNoTracking().ToList();
        }
        public Funcionarios GetById(int id) {
            return _context.Funcionarios.AsNoTracking().FirstOrDefault(f => f.Id == id);
        }
        public void Add(Funcionarios funcionario)
        {
            if (funcionario == null)
            {
                throw new ArgumentNullException(nameof(funcionario));
            }
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }
        public void Update(Funcionarios funcionario)
        {
            var existingFuncionario = _context.Funcionarios.FirstOrDefault(f => f.Id == funcionario.Id);
            if (existingFuncionario != null)
            {
                existingFuncionario.Nome = funcionario.Nome;
                existingFuncionario.CPF = funcionario.CPF;
                existingFuncionario.Email = funcionario.Email;
                existingFuncionario.Telefone = funcionario.Telefone;
                existingFuncionario.Endereco = funcionario.Endereco;
                existingFuncionario.Numero = funcionario.Numero;
                existingFuncionario.Complemento = funcionario.Complemento;
                existingFuncionario.Cidade = funcionario.Cidade;
                existingFuncionario.Estado = funcionario.Estado;
                existingFuncionario.CEP = funcionario.CEP;

                _context.SaveChanges();
            }
        }
        public void Delete(Funcionarios funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
        }

    }
}
