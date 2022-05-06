using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StarterBank.Data;

namespace StarterBank
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            string securityKey = "starterbank_api_rest_projeto_starter";
            var symmectricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            //Diz oo sistema que vamos usar jwt como forma de autenticação
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters  //definindo como o sistema deve ler nosso token
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "STARTERBANKAPI",
                    ValidAudience = "usuario_comum",
                    IssuerSigningKey = symmectricKey,
                }
            );

            services.AddControllers();
            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "StarterBank", Version = "v1", Description = "Admin - Login: 1234444444444444 Senha: string -------- User_Comum - Login: 4321444444444444 Senha: string" });
                 c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 {
                     In = ParameterLocation.Header,
                     Description = "Please insert token",
                     Name = "Authorization",
                     Type = SecuritySchemeType.Http,
                     BearerFormat = "JWT",
                     Scheme = "bearer"
                 });
                 var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                 var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                 c.IncludeXmlComments(xmlPath);


                 c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                     {
                         new OpenApiSecurityScheme{
                             Reference=new OpenApiReference  {
                                    Type=ReferenceType.SecurityScheme,
                                    Id="Bearer"
                             }
                         },
                         new string[]{}
                     }
               });
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarterBank v1"));
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarterBank v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
