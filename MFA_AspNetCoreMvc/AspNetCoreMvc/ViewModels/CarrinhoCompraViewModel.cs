using AspNetCoreMvc.Models;

namespace AspNetCoreMvc.ViewModels
{
    public class CarrinhoCompraViewModel
    {

        //Será o que você quer exibir na View

        public CarrinhoCompra CarrinhoCompra { get; set; }
        public decimal CarrinhoCompraTotal { get; set; }


    }
}
