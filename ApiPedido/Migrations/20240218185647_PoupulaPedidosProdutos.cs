using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPedido.Migrations
{
    public partial class PoupulaPedidosProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO PedidoProduto (PedidoId, ProdutoId)" +
               "values (1, 1)," +
               "(1, 2)," +
               "(1, 3)," +
               "(1, 4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from pedidoproduto");
        }
    }
}
