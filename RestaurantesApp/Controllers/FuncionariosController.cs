using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteApp.Application.Interfaces.Funcionario;
using RestauranteApp.Application.Repositories.Funcionario;
using RestaurantesApp.Models;

namespace RestaurantesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioRepository _funcionariosRepository;
        
        public FuncionariosController(IFuncionarioRepository funcionariosRepository)
        {
            _funcionariosRepository = funcionariosRepository;
        }

        public ActionResult Get() {
            return Ok(_funcionariosRepository.GetAll());
        }
        public ActionResult GetById(int id) {
            var funcionario = _funcionariosRepository.GetById(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }
        public ActionResult Post(Funcionarios funcionario) {
            _funcionariosRepository.Add(funcionario);
            return CreatedAtAction(nameof(GetById), new { id = funcionario.Id }, funcionario);
        }
        public ActionResult Put(int id, Funcionarios funcionario) {
            var existingFuncionario = _funcionariosRepository.GetById(id);
            if (existingFuncionario == null) {
                return NotFound();
            }
            funcionario.Id = id;
            _funcionariosRepository.Update(funcionario);
            return NoContent();
        }
        public ActionResult Delete(int id) {
            var funcionario = _funcionariosRepository.GetById(id);
            if (funcionario == null) {
                return NotFound();
            }
            _funcionariosRepository.Delete(funcionario);
            return NoContent();
        }

    }
}
