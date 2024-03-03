using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPedido.Models
{
    [Table("PedidoProduto")]
    public class PedidoProduto
    {

        [Key]
        public int PedidoProdutoId {get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }

        [JsonIgnore]
        public Produto? Cliente
        {
            get; set;
        }//propriedade de navegação

        [JsonIgnore]
        public Pedido? Pedido
        {
            get; set;
        }//propriedade de navegação

    }
}
