using AspNetCoreMvc.Context;
using AspNetCoreMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreMvc.Repositories
{
    public class ComidaRepository : IComidaRepository
    {
        private readonly AppDbContext _context;

        public ComidaRepository(AppDbContext context)
        {
            _context = context;

        }
        public IEnumerable<Comida> Comidas => _context.Comidas.Include(c => c.Categoria);

        public IEnumerable<Comida> ComidasPreferidas => _context.Comidas.Where(p => p.IsComidaPreferida).Include(c => c.Categoria);

        public Comida GetComidaById(int comidaId)
        {
            return _context.Comidas.FirstOrDefault(l => l.ComidaId == comidaId); 
        }
    }
}
