using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPedido.Migrations
{
    public partial class PopulaPedidoProduto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO PedidoProduto (PedidoId, ProdutoId) " +
                "values (2, 1), (2, 2), (2, 3), (2, 4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
