using Microsoft.EntityFrameworkCore;
using MigdalApi.BusinessLogic;
using MigdalApi.BusinessLogic.Interfaces;
using MigdalApi.Data;
using MigdalApi.Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IGarageRepository, GarageRepository>();
builder.Services.AddScoped<IGarageBL, GarageBL>();
builder.Services.AddScoped<IGovApiBL, GovApiBL>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Security
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
      builder =>
      {
          builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
