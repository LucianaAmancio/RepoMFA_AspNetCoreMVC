using AspNetCoreMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc.Repositories
{
    public interface IComidaRepository
    {

        IEnumerable<Comida> Comidas { get; }
        IEnumerable<Comida>  ComidasPreferidas { get; }
        Comida GetComidaById(int comidaId);

    }
}
