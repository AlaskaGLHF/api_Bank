using api_Bank.Interfaces;
using api_bank.Repositories;
using api_Bank.Services;
using Microsoft.EntityFrameworkCore;
using api_bank.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy => //Свагер ругался на метод и пришлось этим фиксить
    {
        policy.AllowAnyOrigin() 
            .AllowAnyMethod()  
            .AllowAnyHeader(); 
    });
});

builder.Services.AddControllers();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICardRepository, CardRepository>();

builder.Services.AddDbContext<BankContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Configuration.AddUserSecrets<Program>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();