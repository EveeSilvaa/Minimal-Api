using Microsoft.EntityFrameworkCore;
using Minimal_Api.Infraestutura.Db;
using Minimal_Api.DTOs;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContexto>(Options => {
    Options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

var app = builder.Build();

app.MapGet("/", () => "Olá pessoal!");

app.MapPost("/login", (Minimal_Api.DTOs.LoginDTO loginDTO) => {
    if(loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
        return Results.Ok("Login com Sucesso");
    else
        return Results.Unauthorized();
});

app.Run();

