namespace RestaurantesApp.Models
{
    public class Funcionarios
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set;}
        public string Numero { get; set; }  
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Cargo { get; set; }
        public string Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }
    }
}
