using ECOSAGE.DATA.db;
using ECOSAGE.REPOSITORY.activity;
using ECOSAGE.REPOSITORY.carbonFootprint;
using ECOSAGE.REPOSITORY.user;
using ECOSAGE.SERVICE.activity;
using ECOSAGE.SERVICE.ai;
using ECOSAGE.SERVICE.carbonFootprint;
using ECOSAGE.SERVICE.user;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "EcoSage - C#",
        Description = "API documentation for EcoSage project",
        Contact = new OpenApiContact
        {
            Name = "Igor Luiz",
            Email = "rm99809@fiap.com.br",
            Url = new Uri("https://github.com/IgorLuiz777")
        },
        License = new OpenApiLicense
        {
            Name = "Source Code",
            Url = new Uri("https://github.com/IgorLuiz777/EcoSage-CSharp")
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<OracleDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("FIAPDatabase"));
});

builder.Services.AddControllers();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<ActivityRepository>();
builder.Services.AddScoped<ActivityService>();

builder.Services.AddScoped<CarbonFootprintRepository>();
builder.Services.AddScoped<CarbonFootprintService>();

builder.Services.AddScoped<AiService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); 
});


app.UseHttpsRedirection();

app.Run();
