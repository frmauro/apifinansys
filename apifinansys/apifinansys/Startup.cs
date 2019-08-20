using apifinansys.EFContext;
using apifinansys.Extensions;
using apifinansys.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace apifinansys
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IHeaderEvent, HeaderEvent>();

            //var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<FinansysContext>
            //    (options => options.UseSqlServer(connection));

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200", "http://192.168.99.100:3000");
                    builder.AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddDbContext<FinansysContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("FinansysContext")));
            services.ConfigureRepositoryWrapper();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(opt =>
            //    {
            //        opt.Events = new JwtBearerEvents
            //        {
            //            OnMessageReceived = ctx =>
            //            {
            //                // Access ctx.Request here for the query-string, route, etc.
            //                //ctx.Token = "";

            //                //var unencryptedToken = ctx.Request.Headers;
            //                //var encryptedToken = Decrypt(unencryptedToken);
            //                //ctx.Token = encryptedToken;

            //                return Task.CompletedTask;
            //            }
            //        };

            //opt.Events.MessageReceived = context =>
            //{
            //    var unencryptedToken = context.Token;
            //    var encryptedToken = Decrypt(unencryptedToken);
            //    context.Token = encryptedToken;
            //};

            //opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //{
            //    ValidateIssuer = true,
            //    ValidateAudience = true,
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
            //};


            //});

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            //Fixar Cultura para en-US
            var localizationOptions = new RequestLocalizationOptions
            {
                SupportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR") },
                SupportedUICultures = new List<CultureInfo> { new CultureInfo("pt-BR") },
                DefaultRequestCulture = new RequestCulture("pt-BR")
            };

            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseRequestLocalization(localizationOptions);

            app.UseStoreUserData();
            app.UseAuthentication();

            app.UseMvc();

        }
    }
}
