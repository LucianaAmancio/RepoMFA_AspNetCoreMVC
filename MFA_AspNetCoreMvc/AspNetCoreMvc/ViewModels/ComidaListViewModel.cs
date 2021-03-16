using AspNetCoreMvc.Models;
using System.Collections.Generic;

namespace AspNetCoreMvc.ViewModels
{
    public class ComidaListViewModel
    {

        public IEnumerable<Comida> Comidas { get; set; }

        public string CategoriaAtual { get; set; }
    }
}
