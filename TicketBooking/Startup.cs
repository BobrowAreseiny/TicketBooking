using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicketBooking.Data;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;
using TicketBooking.Data.Repository;

namespace TicketBooking
{
    public class Startup
    {

        private readonly IConfigurationRoot _confString;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            ////////////////////////
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));


            //services.AddIdentity<Account, IdentityRole>(opts => {
            //    opts.User.RequireUniqueEmail = true;    // уникальный email
            //    opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz"; // допустимые символы
            //}).AddEntityFrameworkStores<ApplicationDbContext>();


            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new PathString("/SelectedUser/Login");
                });                 
            services.AddControllersWithViews();

            /////////////////////////
            //services.AddAuthorization(opts => {
            //    opts.AddPolicy("OnlyAdmin", policy => {
            //        policy.RequireClaim("Name", "Администратор");
            //    });
            //});
            /////////////////////////
            //services.AddAuthorization(opts => {
            //    opts.AddPolicy("OnlyForLondon", policy => {
            //        policy.RequireClaim(ClaimTypes.Locality, "Лондон", "London");// Доступ только из лондона
            //    });
            //    opts.AddPolicy("OnlyForMicrosoft", policy => {
            //        policy.RequireClaim("company", "Microsoft");
            //    });
            //});

            services.AddTransient<IConcertCatalog, ConcertRepository>();
            services.AddTransient<IConcertTicket, TicketRepository>();
            services.AddTransient<IAllOrders, OrderRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IConcertService, ConcertService>();
            services.AddTransient<IAutorisation, AutorisationRepository>();
            services.AddTransient<IUserPage, UserPageRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(sp => CashBox.GetTickets(sp));         
            services.AddMvc();  
            services.AddMemoryCache();
            services.AddSession();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseSession();

            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                  name: "categoryFilter",
                  pattern: "Concert/{action}/{category?}");
               
            });
            using var scope = app.ApplicationServices.CreateScope();
            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            AddToDb.PutAndTake(/*app*/context);
        }
    }
}
