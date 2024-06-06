using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestauranteApp.Login.Infra.Models;
using RestaurantesApp.Login.Application.Repo;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

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
        private Usuarios AuthenticateUser(Usuarios login)
        {
            // Verificar se o usuário existe no repositório
            var user = _usuariosRepository.GetByEmail(login.Email);
            if (user != null && user.Senha == login.Senha)
            {
                return user;
            }
            return null;
        }

        private string GenerateToken(Usuarios userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                             _config["Jwt:Issuer"],
                                          null,
                                                       expires: DateTime.Now.AddMinutes(120),
                                                                    signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuarios login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
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
    }
}
