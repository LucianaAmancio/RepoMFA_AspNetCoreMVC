using AspNetCoreMvc.Repositories;
using AspNetCoreMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IComidaRepository _comidaRepository;

        public  HomeController(IComidaRepository comidaRepository) 
        {
            _comidaRepository = comidaRepository;
        }
        
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                ComidasPreferidas = _comidaRepository.ComidasPreferidas
            };
            return View(homeViewModel);
        }

        public ViewResult AccessDenied()
        {
            return View();
        }
    }
}
