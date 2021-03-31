
using StudentApp.mapper;
using StudentApp.Models;
using StudentApp.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using StudentApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CommunicateWithBooksApi.EntityFrameworkCore.BooksApiContract;
using CommunicateWithBooksApi.EntityFrameworkCore.BookApiRepository;


namespace StudentApp
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
            services.AddDbContext<StudentContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(Maps));

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ILevel, LevelRepository>();
            services.AddScoped<IBookApi, BookApi>();

            services.AddMvc().AddFluentValidation();

            services.AddTransient<IValidator<StudentVM>, StudentVMValidator>();
            services.AddTransient<IValidator<LevelVM>, LevelVMValidator>();
            //
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
