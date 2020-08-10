using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [StringLength(100)]
        public string CategoriaNome { get; set; }

        [StringLength(100)]
        public string Descricao { get; set; }

        public List<Comida> Comidas { get; set; }

    }
}
