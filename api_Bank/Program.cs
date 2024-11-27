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
    options.TokenValidationParameters = new
   TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new
   SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(s: builder.Configuration["JWT:SigninKey"])),
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

builder.Services.AddDbContext<BankContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enable Swagger annotations and customize SchemaId to avoid conflicts
builder.Services.AddSwaggerGen(options =>
{
    options.MapType<api_Bank.Dtos.UserDto.UserDtoUpdate>(() => new OpenApiSchema { Type = "object", Title = "UserDto_Update" });
    options.MapType<api_Bank.Dtos.CardDto.CardDtoUpdate>(() => new OpenApiSchema { Type = "object", Title = "CardDto_Update" });

    // Register the CustomSchemaIdFilter
    options.SchemaFilter<CustomSchemaIdFilter>();
    options.EnableAnnotations();
    options.SchemaFilter<CustomSchemaIdFilter>();

    options.SwaggerDoc("v1", new OpenApiInfo { Title = "API Bank", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
