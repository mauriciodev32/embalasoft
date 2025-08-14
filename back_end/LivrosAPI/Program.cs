using LivrosAPI.Data;
using LivrosAPI.Repository;
using LivrosAPI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("LivrosDb"));


builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<LivroService>();
builder.Services.AddScoped<LivroRepository>();



builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("LivrosPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("LivrosPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
