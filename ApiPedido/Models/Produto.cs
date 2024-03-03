using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPedido.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(100)]
        public string? NomeProduto { get; set; }
        [Required]
        [StringLength(100)]
        public string? ImagemUrl { get; set; }
        [Required]
        [StringLength(100)]
        public string? Descricao { get; set; }
        public  int Estoque { get; set; }

    }
}
