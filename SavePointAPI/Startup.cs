using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SavePointAPI.Data;
using SavePointAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Http;
using SavePointAPI.Helpers;
using AutoMapper;

namespace SavePointAPI
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
            // Service for Automapper
            services.AddAutoMapper();
            // Service for connecting to a database
            services.AddDbContext<GamesDbContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            // Service to seed a database with pregenerated user data
            services.AddTransient<Seed>();
            // Add Service to allow MVC
            // Add Json options to ignore reference loop handling
            services.AddMvc().AddJsonOptions(opt => {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            // Service to all CORS headers
            services.AddCors();
            // Service to add Scoped injection for Auth Repository
            // This will initiate the Auth Repository for each HTTP request
            services.AddScoped<IAuthRepository, AuthRepository>();
            // Add scoped injection for Games Repository
            services.AddScoped<IGamesRepository, GamesRepository>();
			// Key variable for Issuer Signing Key for authentication service
			var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value);
			// Add service to allow JWT authentication
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seed seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                // Global Exception Handler
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context => {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();

                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });

            }
            // Seed user data to the database
            // seeder.SeedUsers();

            // Import Cors headers for use in application
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            // Serve static files from the wwwroot folder for Angular
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
