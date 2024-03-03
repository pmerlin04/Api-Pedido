using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPedido.Migrations
{
    public partial class PopulaClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO clientes(NomeCliente) values ('Pedro Merlin')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from clientes");
        }
    }
}
