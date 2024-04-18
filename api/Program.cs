
using api.Helper;
using infrastructure;
using infrastructure.Repository;
using Microsoft.Net.Http.Headers;
using service;

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


var frontEndRelativePath = "./../frontend/www/";

builder.Services.AddSpaStaticFiles(configuration => 
    { configuration.RootPath = "./../frontend/www/"; });

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
    { frontendApp.UseSpa(spa =>
    { spa.Options.SourcePath = "./app/www/"; }); });


app.UseSpaStaticFiles();
app.UseSpa(conf =>
{
    conf.Options.SourcePath = frontEndRelativePath;
});


app.MapControllers();

app.Run();