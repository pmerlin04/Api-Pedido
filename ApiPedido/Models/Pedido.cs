using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPedido.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        [Required]
        [Column(TypeName ="decimal(10,2")]
        public decimal PrecoPedido { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        public int ClienteId { get; set; }//chave estrangeira

        [JsonIgnore]
        public Cliente? Cliente { get; set; }//propriedade de navegação
        //explicando que UM Pedido está relacionado a UM Cliente
    }
}