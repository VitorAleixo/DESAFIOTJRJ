using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TJRJ.Livros.Application.DTOs.Sub;
using TJRJ.Livros.Application.Interfaces;
using TJRJ.Livros.Application.Interfaces.Relations;
using TJRJ.Livros.Application.UseCases;
using TJRJ.Livros.Application.UseCases.Relations;
using TJRJ.Livros.Infrastructure.Context;
using TJRJ.Livros.Infrastructure.Repositories;
using TJRJ.Livros.Infrastructure.Repositories.Relations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddDbContext<LivroDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TJRJ Livros API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no campo abaixo:\nExemplo: Bearer {seu_token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}
        }
    });
});

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ILivroUseCase, LivroUseCase>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IAutorUseCase, AutorUseCase>();
builder.Services.AddScoped<IAssuntoRepository, AssuntoRepository>();
builder.Services.AddScoped<IAssuntoUseCase, AssuntoUseCase>();
builder.Services.AddScoped<ITipoVendaRepository, TipoVendaRepository>();
builder.Services.AddScoped<ITipoVendaUseCase, TipoVendaUseCase>();

builder.Services.AddScoped<ILivroAssuntoRepository, LivroAssuntoRepository>();
builder.Services.AddScoped<ILivroAssuntoUseCase, LivroAssuntoUseCase>();
builder.Services.AddScoped<ILivroAutorRepository, LivroAutorRepository>();
builder.Services.AddScoped<ILivroAutorUseCase, LivroAutorUseCase>();
builder.Services.AddScoped<ILivroTipoVendaRepository, LivroTipoVendaRepository>();
builder.Services.AddScoped<ILivroTipoVendaUseCase, LivroTipoVendaUseCase>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
