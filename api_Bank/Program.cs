using api_Bank.Interfaces;
using api_Bank.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using api_bank.Repositories;
using api_Bank;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using api_bank.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme =
    JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigninKey"])),
        ValidateLifetime = true,
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy =>
        policy.RequireRole("User"));
    options.AddPolicy("Admin", policy =>
        policy.RequireRole("Admin"));
});

builder.Services.AddControllers();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddDbContext<BankContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enable Swagger annotations and customize SchemaId to avoid conflicts
builder.Services.AddSwaggerGen(option =>
{
    // Конфигурация документации Swagger
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Demo API",
        Version = "v1"
    });

    // Определение схемы безопасности
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    // Требование безопасности для всех операций
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
