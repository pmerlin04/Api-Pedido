using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPedido.Migrations
{
    public partial class PopulaPedidos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Pedidos(PrecoPedido, DataCadastro, ClienteId)" +
               "values (200.0, now(), 1)" );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
