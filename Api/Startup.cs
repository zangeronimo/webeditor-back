using Domain.Interfaces;
using Domain.Models.Webeditor;
using Domain.Services.Webeditor;
using Infra.Context;
using Infra.Repositories.Webeditor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Api
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
            services
                .AddDbContext<WebeditorContext>(options =>
                    options
                        .UseNpgsql(Configuration
                            .GetConnectionString("WebeditorDB")));

            services
                .AddScoped(typeof (IRepository<User>), typeof (UserRepository));
            services
                .AddScoped(typeof (IRepository<Company>),
                typeof (CompanyRepository));
            services
                .AddScoped(typeof (IRepository<Role>), typeof (RoleRepository));
            services
                .AddScoped(typeof (IRepository<Module>),
                typeof (ModuleRepository));

            services.AddScoped(typeof (ShowUserService));
            services.AddScoped(typeof (CreateUserService));
            services.AddScoped(typeof (UpdateUserService));
            services.AddScoped(typeof (DeleteUserService));

            services.AddScoped(typeof (ShowCompanyService));
            services.AddScoped(typeof (ShowRoleService));
            services.AddScoped(typeof (ShowModuleService));

            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services
                .AddSwaggerGen(c =>
                {
                    c
                        .SwaggerDoc("v1",
                        new OpenApiInfo { Title = "Api", Version = "v1" });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app
                    .UseSwaggerUI(c =>
                        c
                            .SwaggerEndpoint("/swagger/v1/swagger.json",
                            "Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
