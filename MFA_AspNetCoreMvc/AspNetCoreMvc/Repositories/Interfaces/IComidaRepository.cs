using AspNetCoreMvc.Models;
using System.Collections.Generic;

namespace AspNetCoreMvc.Repositories
{
    public interface IComidaRepository
    {

        IEnumerable<Comida> Comidas { get; }
        IEnumerable<Comida>  ComidasPreferidas { get; }
        Comida GetComidaById(int comidaId);

    }
}
