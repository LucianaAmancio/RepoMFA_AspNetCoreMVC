using AspNetCoreMvc.Repositories;
using AspNetCoreMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc.Controllers
{
    public class ComidaController: Controller
    {
        private readonly IComidaRepository _comidaRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        //Criação das instancias de acesso ao repositório
        public ComidaController(IComidaRepository comidaRepository, ICategoriaRepository categoriaRepository)
        {
            _comidaRepository = comidaRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List() 
        {

            //Formas de passar as informações de um Controller para uma View

            //1ª Primeira forma
            ViewBag.Comida = "Comidas";

            //2ª Primeira forma
            ViewData["Categoria"] = "Categoria";

            //3ª Primeira forma
            //var comidas = _comidaRepository.Comidas;
            //return View(comidas);


            //Cria uma instância da View
            var comidaslistViewModel = new ComidaListViewModel();
            comidaslistViewModel.Comidas = _comidaRepository.Comidas;
            comidaslistViewModel.CategoriaAtual = "Categoria Atual";
            return View(comidaslistViewModel);
        }

    }
}
