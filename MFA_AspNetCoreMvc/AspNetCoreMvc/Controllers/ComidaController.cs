using AspNetCoreMvc.Models;
using AspNetCoreMvc.Repositories;
using AspNetCoreMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult List(string categoria)
        {
            string _categoria = categoria;
            IEnumerable<Comida> comidas;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                comidas = _comidaRepository.Comidas.OrderBy(l => l.ComidaId);
                categoriaAtual = "Todas as comidas";
            }
            else 
            { 
                if(string.Equals("Fitness", _categoria, StringComparison.OrdinalIgnoreCase))
                {
                    comidas = _comidaRepository.Comidas.Where(l => l.Categoria.CategoriaNome.Equals("Fitness")).OrderBy(l => l.Nome);
                }
                else
                {
                    comidas = _comidaRepository.Comidas.Where(l => l.Categoria.CategoriaNome.Equals("Normal")).OrderBy(l => l.Nome);
                }

                categoriaAtual = _categoria;    
                
            }

            //Cria uma instância da View
            var comidasListViewModel = new ComidaListViewModel
            {
                Comidas = comidas,
                CategoriaAtual = categoriaAtual
            };        
     
            return View(comidasListViewModel);

        }

        public IActionResult Details(int comidaId)
        {
            var comida = _comidaRepository.Comidas.FirstOrDefault(l => l.ComidaId == comidaId);

            if (comida == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }

            return View(comida);
        }

        public IActionResult Search(string searchstring) 
        {
            string _searchstring = searchstring;
            IEnumerable<Comida> comidas;
            string _categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(_searchstring)) 
            {
                comidas = _comidaRepository.Comidas.OrderBy(l => l.ComidaId);                   
            }
            else 
            {
                comidas = _comidaRepository.Comidas.Where(l => l.Nome.ToLower().Contains(_searchstring.ToLower()));                
            }

            return View("~/Views/Comida/List.cshtml", new ComidaListViewModel { Comidas = comidas, CategoriaAtual = "Todas as comidas" });
        }

    }
}
