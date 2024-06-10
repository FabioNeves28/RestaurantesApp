using BCrypt.Net;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RestauranteApp.Login.Infra.Models;
using RestaurantesApp.Login.Application.Repo;

namespace RestauranteApp.API.Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private IConfiguration _config;

        public UsuariosController(IUsuariosRepository usuariosRepository, IConfiguration config)
        {
            _usuariosRepository = usuariosRepository;
            _config = config;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuariosRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _usuariosRepository.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post(Usuarios usuario)
        {
            
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            _usuariosRepository.Add(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuarios usuario)
        {
            var existingUsuario = _usuariosRepository.GetById(id);
            if (existingUsuario == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(usuario.Senha))
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            }
            else
            {
                usuario.Senha = existingUsuario.Senha;
            }

            usuario.Id = id;
            _usuariosRepository.Update(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _usuariosRepository.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _usuariosRepository.Delete(usuario);
            return NoContent();
        }
        [HttpPost("login")]
        public IActionResult Login(Usuarios loginRequest)
        {
            var usuario = _usuariosRepository.GetByEmail(loginRequest.Email);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Senha, usuario.Senha))
            {
                return Unauthorized("Usuário ou senha inválidos");
            }

            return Ok("Logado com sucesso");
        }
    }
}
