using AspNetCoreMvc.Context;
using AspNetCoreMvc.Models;
using System;

namespace AspNetCoreMvc.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)            
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetalhe = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    ComidaId = carrinhoItem.Comida.ComidaId,
                    PedidoId = pedido.PedidoId, 
                    Preco = carrinhoItem.Comida.Preco                    
                };
                _appDbContext.PedidoDetalhes.Add(pedidoDetalhe);
            }
            _appDbContext.SaveChanges();
        }
    }
}
