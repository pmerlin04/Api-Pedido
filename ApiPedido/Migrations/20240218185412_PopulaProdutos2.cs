using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPedido.Migrations
{
    public partial class PopulaProdutos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO produtos(NomeProduto, ImagemUrl, Descricao, Estoque)" +
               "values ('Meia adidas', 'meia-adidas.jpg', 'Meia adidas cano médio', 600)," +
               "('Chuteira nike', 'chuteira-nike.jpg', 'Chuteira nike futsal', 50)," +
               "('Chuteira adidas', 'chuteira-adidas.jpg', 'chuteira adidas futsal', 70)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from produtos");
        }
    }
}
