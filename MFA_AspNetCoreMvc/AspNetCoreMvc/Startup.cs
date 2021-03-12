using AspNetCoreMvc.Context;
using AspNetCoreMvc.Models;
using AspNetCoreMvc.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Cria o serviço de conexão com o banco de dados
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                  .AddEntityFrameworkStores<AppDbContext>()
                  .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Home/AccessDenied");

            //fornece uma instancia de HttpContextAcessor //Registra o serviço do CarrinhoCompra
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();          

            //Cria o serviço que utiliza as clases da pasta Repository
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IComidaRepository, ComidaRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            //cria um objeto Scoped, ou seja um objeto que esta associado a requisição
            //isso significa que se duas pessoas solicitarem o objeto CarrinhoCompra ao  mesmo tempo
            //elas vão obter instâncias diferentes
            //Define o carrinho para cada requisição sem ter ligação com a instância
            services.AddScoped(cp => CarrinhoCompra.GetCarrinho(cp));

            services.AddControllersWithViews();

            //configura o uso da Sessão
            services.AddMemoryCache();
            services.AddSession();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();                     
            app.UseSession(); //Ativa o recurso da Session para ser utilizado pela aplicação. //Ativado para criação do carrinho de compras

            app.UseAuthentication();          
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //informando ao framework que está usando area
                endpoints.MapControllerRoute(
                   name: "AdminArea",
                   pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "filtrarPorCategoria",
                    pattern: "Comida/{action}/{categoria?}",
                    defaults: new {Controller="Comida", action="List"}
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
