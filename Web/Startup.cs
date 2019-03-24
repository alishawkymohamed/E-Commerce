using DbContexts.DatabaseExtensions;
using HelperServices.Hubs;
using IBusinessServices;
using IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NSwag.CodeGeneration.TypeScript;
using Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApplication
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<BearerTokensOptions>(options => Configuration.GetSection("BearerTokens").Bind(options));
            services.Configure<AppSettings>(options => Configuration.Bind(options));

            //Enable GZip Compression
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                // You Can use fastest compression
                options.Level = CompressionLevel.Optimal;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddOptions();
            //services.Configure<IHelperServices.Models.AppSettings>(options => Configuration.Bind(options));

            services.AddCors();
            // Using Cache with ServerState option
            services.AddDistributedMemoryCache();
            // Default IdleTimeout 20 Minutes
            services.AddSession();
            services.AddAutoMapper();

            services.AddSwaggerGen(action =>
            {
                action.SwaggerGeneratorOptions = new Swashbuckle.AspNetCore.SwaggerGen.SwaggerGeneratorOptions()
                {
                    OperationIdSelector = x => x.ActionDescriptor.AttributeRouteInfo.Template.Replace('{', '_').Replace('}', '_')
                };
                action.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "eCommerce WebApi", Version = "v1" });
            });

            services.AddEntityFrameworkSqlServer().AddDbContext<MainDbContext>(options =>
            {
                options.UseLazyLoadingProxies(true)
                .UseSqlServer(Configuration.GetConnectionString("MainConnectionString"), serverDbContextOptionsBuilder =>
                        {
                            int minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                            serverDbContextOptionsBuilder.CommandTimeout(minutes);
                            serverDbContextOptionsBuilder.EnableRetryOnFailure();
                        });
            });

            services.AddSingleton(typeof(DbContextOptionsBuilder<MainDbContext>), new DbContextOptionsBuilder<MainDbContext>().UseSqlServer(Configuration.GetConnectionString("MainConnectionString")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IStringLocalizer), typeof(DbStringLocalizer));

            services.AddHelperServices();
            services.AddBusinessServices();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("HasPermissionPolicy", policy =>
            //        policy.Requirements.Add(new HasPermissionRequirment()));
            //    options.AddPolicy("AuthenticatedOnlyPolicy", policy =>
            //        policy.Requirements.Add(new AuthenticatedOnlyRequirment()));
            //});

            services.AddScoped<IAuthorizationHandler, AuthenticatedOnlyFilter>();
            //services.AddScoped<IAuthorizationHandler, AuthHandler>();

            services
               .AddAuthentication(options =>
               {
                   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               })
               .AddJwtBearer(cfg =>
               {
                   cfg.RequireHttpsMetadata = false;
                   cfg.SaveToken = true;
                   cfg.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidIssuer = Configuration["BearerTokens:Issuer"], // site that makes the token
                       ValidateIssuer = false, // TODO: change this to avoid forwarding attacks
                       ValidAudience = Configuration["BearerTokens:Audience"], // site that consumes the token
                       ValidateAudience = false, // TODO: change this to avoid forwarding attacks
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["BearerTokens:Key"])),
                       ValidateIssuerSigningKey = true, // verify signature to avoid tampering
                       ValidateLifetime = true, // validate the expiration
                       ClockSkew = TimeSpan.FromMinutes(5) // tolerance for the expiration date
                   };
                   cfg.Events = new JwtBearerEvents
                   {
                       OnAuthenticationFailed = context =>
                       {
                           ILogger logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                           logger.LogError("Authentication failed.", context.Exception);
                           return Task.CompletedTask;
                       },
                       OnTokenValidated = context =>
                       {
                           ITokenValidatorService tokenValidatorService = context.HttpContext.RequestServices.GetRequiredService<ITokenValidatorService>();
                           return tokenValidatorService.ValidateAsync(context);
                       },
                       OnChallenge = context =>
                       {
                           ILogger logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                           logger.LogError("OnChallenge error", context.Error, context.ErrorDescription);
                           return Task.CompletedTask;
                       },
                       //OnMessageReceived = context =>
                       //{
                       //    Microsoft.Extensions.Primitives.StringValues accessToken = context.Request.Query["access_token"];

                       //    // If the request is for our hub...
                       //    PathString path = context.HttpContext.Request.Path;
                       //    if (!string.IsNullOrEmpty(accessToken) &&
                       //        (path.StartsWithSegments("/SignalR")))
                       //    {
                       //        // Read the token out of the query string
                       //        context.Token = accessToken;
                       //    }
                       //    return Task.CompletedTask;
                       //}
                   };
               });

            //services.AddAntiforgery(x => x.HeaderName = "X-XSRF-TOKEN");
            //services.AddMvc(options =>
            //    {
            //        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            //    })

            services.AddMvc()
                .AddDataAnnotationsLocalization()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            //services.AddSignalR(options => options.EnableDetailedErrors = true);
            // To use Username instead of ConnectionId in Communication 
            services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                CultureInfo[] supportedCultures = new[] { new CultureInfo("ar"), new CultureInfo("en") };
                options.DefaultRequestCulture = new RequestCulture("ar");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    IExceptionHandlerFeature error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;
                    if (error != null && error.Error is SecurityTokenExpiredException)
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            State = 401,
                            Msg = "Token Expired"
                        }));
                    }
                    else if (error != null && error.Error != null)
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            State = 500,
                            Msg = error.Error.Message
                        }));
                    }
                    else
                    {
                        await next();
                    }
                });
            });

            app.UseResponseCompression();
            app.UseSession();
            app.UseCors(builder => builder.AllowCredentials().AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5000").Build());

            app.UseSwagger(action => { });
            app.UseSwaggerUI(action => { action.SwaggerEndpoint("/swagger/v1/swagger.json", "eCommerce WebApi"); });

            app.UseAuthentication();

            //if (Configuration.GetValue("SeedData:SeedDataOnStart", false))
            //{
            //    var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            //    using (var scope = scopeFactory.CreateScope())
            //    {
            //        var dbInitializer = scope.ServiceProvider.GetService<IDbInitializerService>();
            //        //dbInitializer.Initialize();
            //        dbInitializer.SeedData();
            //    }
            //}


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions()
            {
                ContentTypeProvider = new FileExtensionContentTypeProvider(new Dictionary<string, string>() {
                    { ".xlf","application/x-msdownload"},
                    { ".exe","application/octect-stream"},
                })
            });

            app.UseSpaStaticFiles();

            app.UseStatusCodePages();
            app.UseDefaultFiles(); // so index.html is not required
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ar"),
                SupportedCultures = new[] { new CultureInfo("en"), new CultureInfo("ar") },
                SupportedUICultures = new[] { new CultureInfo("en"), new CultureInfo("ar") }
            });

            app.UseFileServer(new FileServerOptions()
            {
                EnableDirectoryBrowsing = false
            });

            //app.UseSignalR(options =>
            //{
            //    options.MapHub<SignalRHub>("/SignalR");
            //});

            app.UseMvc();
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    spa.Options.StartupTimeout = TimeSpan.FromMinutes(10);
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:4444");
                }
            });

            if (env.IsDevelopment())
            {
                Task.Run(() =>
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        string SourceDocumentAbsoluteUrl = Configuration["SwaggerToTypeScriptSettings:SourceDocumentAbsoluteUrl"];
                        string OutputDocumentRelativePath = Configuration["SwaggerToTypeScriptSettings:OutputDocumentRelativePath"];
                        using (Stream contentStream = httpClient.GetStreamAsync(SourceDocumentAbsoluteUrl).Result)
                        using (StreamReader streamReader = new StreamReader(contentStream))
                        {
                            string json = streamReader.ReadToEnd();
                            NSwag.SwaggerDocument document = NSwag.SwaggerDocument.FromJsonAsync(json).Result;
                            SwaggerToTypeScriptClientGeneratorSettings settings = new SwaggerToTypeScriptClientGeneratorSettings
                            {
                                ClassName = "SwaggerClient",
                                Template = TypeScriptTemplate.Angular,
                                RxJsVersion = 6.0M,
                                HttpClass = HttpClass.HttpClient,
                                InjectionTokenType = InjectionTokenType.InjectionToken,
                                BaseUrlTokenName = "API_BASE_URL",
                                UseSingletonProvider = true
                            };
                            SwaggerToTypeScriptClientGenerator generator = new SwaggerToTypeScriptClientGenerator(document, settings);
                            string code = generator.GenerateFile();
                            new FileInfo(OutputDocumentRelativePath).Directory.Create();
                            try
                            {
                                File.WriteAllText(OutputDocumentRelativePath, code);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                });
            }

            if (Configuration.GetValue("LocalizationSettings:LoadLocalizationOnStart", false))
                new LocalizationHelper().GenerateLocalizationFilesForTypescript(Configuration);
        }
    }
}
