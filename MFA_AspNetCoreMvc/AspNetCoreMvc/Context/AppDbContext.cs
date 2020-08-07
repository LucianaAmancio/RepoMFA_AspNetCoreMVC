using AspNetCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc.Context
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        { }


        public DbSet<Comida> Comidas { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

    }
}
