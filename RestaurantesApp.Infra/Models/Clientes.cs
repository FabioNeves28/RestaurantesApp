using System.ComponentModel.DataAnnotations;

namespace RestaurantesApp.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Senha { get; set; }
        public string? Endereco { get; set;}
        public string Numero { get; set; }  
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public ICollection<Pedidos>? Pedidos { get; set; }

    }
}
