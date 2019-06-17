using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Implementation.Services;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PresentationLayer.WebApplication.ApiClients;
using PresentationLayer.WebApplication.Common.Options;
using PresentationLayer.WebApplication.Constants;

namespace PresentationLayer.WebApplication
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
            services.Configure<ApiOptions>(Configuration.GetSection("ApiOptions"));

            services.AddHttpContextAccessor();

            services.AddScoped<IAdvertService, AdvertServiceProxy>();
            services.AddScoped<ILikeService, LikeServiceProxy>();
            services.AddScoped<IAdvertCommentService, AdvertCommentServiceProxy>();
            services.AddScoped<ISubCategoryService, SubCategoryServiceProxy>();
            services.AddScoped<IUserInfoService, UserInfoServiceProxy>();
            services.AddScoped<IPromptService, PromptServiceProxy>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = ChallengeScheme.OpenIdConnect;

                })
                .AddCookie()
                .AddOpenIdConnect(ChallengeScheme.OpenIdConnect, options =>
                {
                    options.Authority = Configuration.GetValue<string>("IdentityServerUrl");
                    options.RequireHttpsMetadata = false;
                    options.ClientId = Configuration.GetValue<string>("ClientId");
                    options.ClientSecret = Configuration.GetValue<string>("ClientSecret");
                    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                    options.Scope.Clear();
                    options.Scope.Add(RecourseScopes.Profile);
                    options.Scope.Add(RecourseScopes.OpenId);
                    options.Scope.Add(RecourseScopes.Api);
                    options.Scope.Add(JwtClaimTypes.Role);
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.SaveTokens = true;
                });

            services.AddCors(options =>
            {
                options.AddPolicy(Configuration.GetSection("CORS").GetValue<string>("PolicyName"), builder =>
                {
                    builder.WithOrigins(Configuration.GetSection("CORS").GetValue<string>("AllowedOrigins"));
                });
            });
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddAutoMapper(options => options.AddProfile<MappingProfile>());

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCors(Configuration.GetSection("CORS").GetValue<string>("PolicyName"));

            var supportedCultures = new[] { new CultureInfo(LocaleConstants.Russian), new CultureInfo(LocaleConstants.English) };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(LocaleConstants.Russian),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Advert}/{action=Index}/{id?}");
            });
        }
    }
}
