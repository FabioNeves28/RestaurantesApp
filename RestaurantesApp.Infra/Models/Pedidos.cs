namespace RestaurantesApp.Models
{
    public class Pedidos
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string? Status { get; set; }
        public string? FormaPagamento { get; set; }
        public string? EnderecoEntrega { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }
        public string? Observacoes { get; set; }
        public string? DataPedido { get; set; }
        public string? DataEntrega { get; set; }

        public Clientes Cliente { get; set; }



    }
}
