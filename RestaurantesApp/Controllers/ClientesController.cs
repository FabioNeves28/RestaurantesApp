using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using RestauranteApp.Application.Interfaces.Cliente;
using RestaurantesApp.Data;
using RestaurantesApp.Models;

namespace RestaurantesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository _clienteRepository;
        private readonly RestaurantesContext _context;
        public ClientesController(IClientesRepository clienteRepository, RestaurantesContext context)
        {
            _clienteRepository = clienteRepository;
            _context = context;
        }
        [HttpGet("{idCliente}/pedidos")]
        public IActionResult GetPedidosDoCliente(int idCliente)
        {
            var pedidosDoCliente = _context.Pedidos
                .Where(p => p.IdCliente == idCliente)
                .ToList();

            return Ok(pedidosDoCliente);
        }
        [HttpGet]
        public IActionResult Get()
        {
           
            return Ok(_clienteRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Post(Clientes cliente)
        {
            _clienteRepository.Add(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Clientes cliente)
        {
            var existingCliente = _clienteRepository.GetById(id);
            if (existingCliente == null)
            {
                return NotFound();
            }
            cliente.Id = id;
            _clienteRepository.Update(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _clienteRepository.Delete(cliente);
            return NoContent();
        }
    }
}
