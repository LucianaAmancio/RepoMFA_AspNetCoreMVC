using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {            
                return View();            
        }
    }
}
