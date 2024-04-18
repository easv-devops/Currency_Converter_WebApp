
using Microsoft.Net.Http.Headers;
using api.Helper;
using infrastructure;
using infrastructure.Repository;
using service;

namespace api
{
    public static class Startup
    {
        public static void Main(string[] args)
        {
            var webApp = Start(args);
            webApp.Run();
        }

        public static WebApplication Start(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddNpgsqlDataSource(Utilities.ProperlyFormattedConnectionString,
                    dataSourceBuilder => dataSourceBuilder.EnableParameterLogging());
            }

            if (builder.Environment.IsProduction())
            {
                builder.Services.AddNpgsqlDataSource(Utilities.ProperlyFormattedConnectionString);
            }

            builder.Services.AddSingleton<ConverterService>();
            builder.Services.AddSingleton<HistoryService>();
            builder.Services.AddSingleton<ConvRepository>();
            builder.Services.AddSingleton<ResponseHelper>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var frontEndRelativePath = "./../frontend/";

            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "./../frontend/";
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(options =>
            {
                options.SetIsOriginAllowed(origin => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });

            app.UseSpaStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });

            app.Map("/frontend",
                (IApplicationBuilder frontendApp) =>
                {
                    frontendApp.UseSpa(spa =>
                    {
                        spa.Options.SourcePath = "./app/";
                    });
                });

            app.UseSpaStaticFiles();
            app.UseSpa(conf =>
            {
                conf.Options.SourcePath = frontEndRelativePath;
            });

            app.MapControllers();
            //app.UseMiddleware<ExceptionHandlingMiddleware>();

            return app;
        }
    }
}
