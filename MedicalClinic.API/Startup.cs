
using AutoMapper;
using MedicalClinic.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MedicalClinic.DataAccess.Repositories;
using MedicalClinic.DataAccess.Interfaces;
using MedicalClinic.Business.Services.Services;
using MedicalClinic.Business.Services.Interfaces;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using MedicalClinic.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MedicalClinic.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<MedicalClinicDBContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:MedicalClinicDB"]));
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MedicalClinicDBContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAppointmentTypeRepository, AppointmentTypeRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddScoped<IAppointmentService, AppoinmentService>();
            services.AddScoped<IAppointmentTypeService, AppointmentTypeService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IAuthService, AuthService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "docs";
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            // Use Cors Middleware
            app.UseCors(builder => builder.AllowAnyOrigin().AllowCredentials().AllowAnyHeader().AllowAnyMethod());

            app.UseExceptionHandler(
               builder =>
               {
                   builder.Run(
                     async context =>
                     {
                         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                         context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                         var error = context.Features.Get<IExceptionHandlerFeature>();
                         if (error != null)
                         {
                             //context.Response.AddApplicationError(error.Error.Message);
                             await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                         }
                     });
               });

            app.UseHttpsRedirection();
            app.UseMvc();
            

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
        }
    }
}
