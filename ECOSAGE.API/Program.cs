using ECOSAGE.DATA.db;
using ECOSAGE.REPOSITORY.activity;
using ECOSAGE.REPOSITORY.carbonFootprint;
using ECOSAGE.REPOSITORY.user;
using ECOSAGE.SERVICE.activity;
using ECOSAGE.SERVICE.ai;
using ECOSAGE.SERVICE.carbonFootprint;
using ECOSAGE.SERVICE.user;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
