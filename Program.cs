using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
// Configuracion para SQL Server
builder.Services.AddSqlServer<TareasContext>("Data Source=LAPTOP-PFPGKMUG; Initial Catalog=TareasDB; Integrated Security=True; TrustServerCertificate=True");
//configuracion para postgres SQL
//builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("TareasDB"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());

});

app.Run();
