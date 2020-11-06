using AspNetCoreMvc.Models;

namespace AspNetCoreMvc.Repositories
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
    }
}