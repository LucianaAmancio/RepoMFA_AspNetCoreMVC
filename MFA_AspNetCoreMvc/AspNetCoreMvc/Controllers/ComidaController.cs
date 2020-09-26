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

    }
}
