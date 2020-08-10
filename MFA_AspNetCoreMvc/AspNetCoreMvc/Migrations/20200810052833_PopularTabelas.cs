using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreMvc.Migrations
{
    public partial class PopularTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Popula a tabela Categorias
            migrationBuilder.Sql(

                "INSERT INTO Categorias(CategoriaNome," +
                "Descricao) " +

                "VALUES('Lanche Natural'," +
                "'Lanche feito com ingredientes integrais e naturais')"

                );

            //Popula a tabela Comidas
            migrationBuilder.Sql(

                "INSERT INTO Comidas(Nome, " +
                "DescricaoCurta, " +
                "DescricaoDetalhada,  " +
                "Preco,  " +
                "ImagemUrl," +
                " ImagemThumbnailUrl, " +
                "IsComidaPreferida, " +
                "EmEstoque, " +
                "CategoriaId)" +

                "VALUES('Lanche Natural'," +
                "'teste', " +
                "'teste teste teste', " +
                "12.5," +
                " 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg', " +
                "'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg'," +
                "0," +
                "1," +
                "1)"
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
            migrationBuilder.Sql("DELETE FROM Comidas");
        }
    }
}
