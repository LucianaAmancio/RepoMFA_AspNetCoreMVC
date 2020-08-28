﻿using AspNetCoreMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace AspNetCoreMvc.Context
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        { }

        public DbSet<Comida> Comidas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

    }
}
