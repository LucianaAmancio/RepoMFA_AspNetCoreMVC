using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreMvc.Migrations
{
    public partial class PopularTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) VALUES('Comida Típica Brasileira','Comida com arroz, feijão, carne ou frango, legumes e salada.') ");
            //migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) VALUES('Comida Mineira','Comida com arroz, feijão tropeiro, frango com quiabo.') ");


            migrationBuilder.Sql("INSERT INTO COMIDAS(Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsComidaPreferida, EmEstoque, CategoriaId) VALUES('Cheese Salada','Pão, hambúrger, ovo, presunto, queijo e batata palha','Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha',12.50, 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg',1, 1 , 3)");
            migrationBuilder.Sql("INSERT INTO COMIDAS(Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsComidaPreferida, EmEstoque, CategoriaId) VALUES('Salada','Pão, hambúrger, presunto, queijo e batata palha','Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha',15.55, 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg',1, 0 , 3)");
            //migrationBuilder.Sql("INSERT INTO COMIDAS(Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsComidaPreferida, EmEstoque, CategoriaId) VALUES('Cheese','Pão, hambúrger, ovo,  queijo e batata palha','Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha',10.78, 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg',1, 0 , 1)");
            //migrationBuilder.Sql("INSERT INTO COMIDAS(Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsComidaPreferida, EmEstoque, CategoriaId) VALUES('Comida','Pão, hambúrger, ovo, presunto','Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha',11.00, 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg',1, 0 , 2)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
            migrationBuilder.Sql("DELETE FROM Comidas");
        }
    }
}
