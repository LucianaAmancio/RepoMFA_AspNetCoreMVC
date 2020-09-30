using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc.Models
{
    public class CarrinhoCompraItem
    {

        public int CarrinhoCompraItemId { get; set; }

        public Comida Comida { get; set; }

        public int Quantidade { get; set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }

    }
}
