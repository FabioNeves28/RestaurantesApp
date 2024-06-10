using RestaurantesApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteApp.Login.Infra.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public int IdCliente { get; set; } 
        public string? Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsVerified { get; set; }
        [ForeignKey("IdCliente")]
        public Clientes? Cliente { get; set; }
    }
}
