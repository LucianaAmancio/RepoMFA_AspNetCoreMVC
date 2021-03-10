using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreMvc.Models
{
    public class PedidoDetalhe
    {
        public int PedidoDetalheId { get; set; }
        public int PedidoId { get; set; }
        public int ComidaId { get; set; }
        public int  Quantidade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco  { get; set; }

        //Indica ao framework o relacionamento entre as classes Pedido e PedidoDetalhe
        public virtual Comida Comida  { get; set; }
        public virtual Pedido Pedido  { get; set; }

}
}
