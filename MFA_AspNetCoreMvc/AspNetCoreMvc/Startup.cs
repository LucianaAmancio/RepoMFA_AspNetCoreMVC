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

            //Cria o servi�o de conex�o com o banco de dados
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                  .AddEntityFrameworkStores<AppDbContext>()
                  .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Home/AccessDenied");

            //fornece uma instancia de HttpContextAcessor //Registra o servi�o do CarrinhoCompra
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();          

            //Cria o servi�o que utiliza as clases da pasta Repository
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IComidaRepository, ComidaRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            //cria um objeto Scoped, ou seja um objeto que esta associado a requisi��o
            //isso significa que se duas pessoas solicitarem o objeto CarrinhoCompra ao  mesmo tempo
            //elas v�o obter inst�ncias diferentes
            //Define o carrinho para cada requisi��o sem ter liga��o com a inst�ncia
            services.AddScoped(cp => CarrinhoCompra.GetCarrinho(cp));

            services.AddControllersWithViews();

            //configura o uso da Sess�o
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
            app.UseSession(); //Ativa o recurso da Session para ser utilizado pela aplica��o. //Ativado para cria��o do carrinho de compras

            app.UseAuthentication();          
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //informando ao framework que est� usando area
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
