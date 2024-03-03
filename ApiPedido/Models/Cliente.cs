using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPedido.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public Cliente()
        {
            Pedidos = new Collection<Pedido>();
        }

        [Key]
        public int ClienteId { get; set; }
        [Required]
        [StringLength(50)]
        public string? NomeCliente { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }
        //esta é uma propriedade de navegação
        //com isso o EF Core entende que há um relacionamento entre Cliente e Pedido
        //essa propriedade é colocada na tabela principal
    }
}
