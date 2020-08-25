using AspNetCoreMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc.ViewModels
{
    public class ComidaListViewModel
    {

        public IEnumerable<Comida> Comidas { get; set; }

        public string CategoriaAtual { get; set; }
    }
}
