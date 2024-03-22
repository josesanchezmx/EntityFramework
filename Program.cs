using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;
using proyectoef.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
// Configuracion para SQL Server
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
//configuracion para postgres SQL
//builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("TareasDB"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());

});
// end point General para ver todos los datos de la base de datos
app.MapGet("/api/tareasGeneral", async ([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Tareas.Include(p=> p.Categoria));
});
// end point  para obtener todas las tareas
app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria).Where(p=> p.PrioridadTarea == proyectoef.Models.Prioridad.Baja));
});

app.MapGet("/api/tareasterminada", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas
        .Where(p => p.Terminada == true)
        .ToList());
});

// end point para guardar datos en la base de datos
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea)=>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    //await dbContext.Tareas.AddAsync(tarea);

    await dbContext.SaveChangesAsync();

    return Results.Ok();   
});

// End Point para actulizar datos en la base de datos

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id)=>
{
    // manera mas efectiva de realizar actulizacion de datos de la base de datos

    var tareaActual = dbContext.Tareas.Find(id);
    if (tareaActual !=null)
    {
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;
        await dbContext.SaveChangesAsync();
        return Results.Ok("Registro Actualizado Correctamente");
    }
    return Results.NotFound("Error No se Actualizaron los Datos");   
});

// End Point para pedir las categorias 
app.MapGet("/api/CategoriasGeneral", async ([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Categorias);
});

// End Point para actuliazar Categorias 

app.MapPut("/api/categorias/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Categoria categoria, [FromRoute] Guid id)=>
{
    // manera mas efectiva de realizar actulizacion de datos de la base de datos

    var categoriaActual = dbContext.Categorias.Find(id);
    if (categoriaActual !=null)
    {
        categoriaActual.CategoriaId = categoria.CategoriaId;
        categoriaActual.Nombre = categoria.Nombre;
        categoriaActual.Descripcion =  categoria.Descripcion;
        categoriaActual.Peso = categoria.Peso;
        await dbContext.SaveChangesAsync();
        return Results.Ok("Registro Actualizado Correctamente");
    }
    return Results.NotFound("Error No se Actualizaron los Datos");   
});

app.Run();
