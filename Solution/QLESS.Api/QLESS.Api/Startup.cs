using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QLESS.Controller.Service;
using QLESS.Data;
using QLESS.Data.Repository;
using QLESS.Domain;
using QLESS.Domain.Mapper;
using QLESS.Domain.Repository;
using QLESS.Domain.Service;

namespace QLESS.Api
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
            services.AddControllers();

            // Swagger
            services.AddSwaggerGen();

            // DB
            services.AddDbContext<QLESSContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("QLESSConnection"),
                b => b.MigrationsAssembly(typeof(QLESSContext).Assembly.FullName)));

            // Unit Of Work
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Mapper
            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<CardMapper>(), typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<CardRegTypeMapper>(), typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<CardLoadHistMapper>(), typeof(Startup));

            // Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<ICardRegTypeRepository, CardRegTypeRepository>();
            services.AddTransient<ICardLoadHistRepository, CardLoadHistRepository>();

            // Services
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<ICardRegTypeService, CardRegTypeService>();
            services.AddTransient<ICardLoadHistService, CardLoadHistService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Q-LESS");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<QLESSContext>().Database.Migrate();
            }
        }
    }
}
