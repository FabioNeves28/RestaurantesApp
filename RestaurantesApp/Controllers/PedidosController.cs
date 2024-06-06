using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteApp.Application.Interfaces.Pedido;
using RestaurantesApp.Models;

namespace RestaurantesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosRepository _pedidosRepository;
        public PedidosController(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_pedidosRepository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pedido = _pedidosRepository.GetById(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }
        [HttpPost]
        public IActionResult Post(Pedidos pedido)
        {
            _pedidosRepository.Add(pedido);
            return CreatedAtAction(nameof(GetById), new { id = pedido.IdPedido }, pedido);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var pedido = _pedidosRepository.GetById(id);
            if (pedido == null)
            {
                return NotFound();
            }
            _pedidosRepository.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pedidos pedido)
        {
            var existingPedido = _pedidosRepository.GetById(id);
            if (existingPedido == null)
            {
                return NotFound();
            }
            pedido.IdPedido = id;
            _pedidosRepository.Update(pedido);
            return NoContent();
        }



    }
    
}
