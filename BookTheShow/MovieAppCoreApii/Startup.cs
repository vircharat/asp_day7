using BookTheShowBLL.services;
using BookTheShowDAL;
using BookTheShowDAL.Repost;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppCoreApii
{
    public class Startup
    {  //middle ware startup.cs file after main execution comes here all request comes here
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; } //TO ACCESS JSON WE NEED iconfiguration interface

        // This method gets called by the runtime. Use this method to add services to the container.
        //we need to add service(movie service)
        public void ConfigureServices(IServiceCollection services)//object builder class it will call when this function automatically called at runtime it creates object
        {
            string connectionStr = Configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<MovieDBcontextv>(options => options.UseSqlServer(connectionStr));
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Movie API",
                    Description = "Movie Management System API",
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
            });
            services.AddTransient<ImovieRepository, MovieRepost>();
            services.AddTransient<IshowTimeRepositry,ShowTimeRepost>();
            services.AddTransient<IuserRepositry, UserRepost>();
            services.AddTransient<IbookingRepositry, BookingRepost>();
            services.AddTransient<ItheatreRepositry,TheatreeRepost>();
            services.AddTransient<IAdmin, AdminRepost>();

            services.AddTransient<MovieSevice, MovieSevice>();
            services.AddTransient<ShowTimeService,ShowTimeService>();
            services.AddTransient<UserService, UserService>();
            services.AddTransient<TheatreService, TheatreService>();
            services.AddTransient<BookingService, BookingService>();
            services.AddTransient<AdminService, AdminService>();


            services.AddTransient<UserService,UserService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization(); //authorize is working

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
