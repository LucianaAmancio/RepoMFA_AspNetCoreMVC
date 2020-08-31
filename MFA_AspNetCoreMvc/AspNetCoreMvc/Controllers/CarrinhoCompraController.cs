using AspNetCoreMvc.Models;
using AspNetCoreMvc.Repositories;
using AspNetCoreMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreMvc.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IComidaRepository _comidaRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IComidaRepository comidaRepository, CarrinhoCompra carrinhoCompra)
        {
            //instâncias criadas
            _comidaRepository = comidaRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraViewModel = new CarrinhoCompraViewModel();
            var CarrinhoCompra = _carrinhoCompra;
            var CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal();
           
            return View(carrinhoCompraViewModel);
         }

        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int comidaId)
        {
            var comidaSelecionada = _comidaRepository.Comidas.FirstOrDefault(p => p.ComidaId == comidaId);

            if (comidaSelecionada != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(comidaSelecionada, 1);
            }

            return RedirectToAction("Index");
        }

    }  
    
}

