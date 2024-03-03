using ApiPedido.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPedido.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Produto>? Produtos
        {get; set; }

        public DbSet<Pedido>? Pedidos
        {
            get; set;
        }

        public DbSet<Cliente>? Clientes
        {
            get; set;
        }
        public DbSet<PedidoProduto> PedidosProdutos { get; set; }

    }
}
