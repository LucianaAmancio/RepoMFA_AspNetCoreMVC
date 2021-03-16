using AspNetCoreMvc.Models;
using System.Collections.Generic;

namespace AspNetCoreMvc.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
