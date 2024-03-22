using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>(); 
        
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("5d997b60-6592-47ae-a311-44826951c5f3"), Nombre = "Actividades pendientes", Peso = 20 });
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("bba57e73-fdc4-4247-93d8-02e49731ea82"), Nombre = "Actividades Personales", Peso = 50 });
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("bfe30f5b-116a-4781-bb5c-bf956e457201"), Nombre = "Actividades Escolares", Peso = 60 });
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("19269fe4-2d5c-4d7d-bcae-6ef190b53390"), Nombre = "Actividades Personales", Peso = 20 });


        modelBuilder.Entity<Categoria>(categoria=> 
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);

            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);

            categoria.Property(p=> p.Descripcion).IsRequired(false);

            categoria.Property(p=> p.Peso);

            categoria.HasData(categoriasInit);
        });

       List<Tarea> tareasInit = new List<Tarea>();

       tareasInit.Add(new Tarea (){ TareaId = Guid.Parse("3d3c69c7-868c-418b-9bc0-49b4bfd68550"), CategoriaId = Guid.Parse("5d997b60-6592-47ae-a311-44826951c5f3"), PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.Now });
       tareasInit.Add(new Tarea (){ TareaId = Guid.Parse("db64cd9a-f505-4d46-8a2c-68b225aaf50a"), CategoriaId = Guid.Parse("bba57e73-fdc4-4247-93d8-02e49731ea82"), PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de hacer tu limpieza de Habitacion", FechaCreacion = DateTime.Now });
       tareasInit.Add(new Tarea (){ TareaId = Guid.Parse("d4250210-9322-4183-b05c-d6199284c09c"), CategoriaId = Guid.Parse("bfe30f5b-116a-4781-bb5c-bf956e457201"), PrioridadTarea = Prioridad.Alta, Titulo = "Terminar la Web API con el Metodo GET y PUT", FechaCreacion = DateTime.Now, Terminada = (false) });
       tareasInit.Add(new Tarea (){ TareaId = Guid.Parse("2d18f412-bda7-41de-b19d-99f6837a0811"), CategoriaId = Guid.Parse("19269fe4-2d5c-4d7d-bcae-6ef190b53390"), PrioridadTarea = Prioridad.Media, Titulo = "Inscribirse al GYM", FechaCreacion = DateTime.Now, Terminada = (true) });


       modelBuilder.Entity<Tarea>(tarea => {
        tarea.ToTable("Tarea");
        tarea.HasKey(p=> p.TareaId);
        tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);;
        tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
        tarea.Property(p=> p.Descripcion).IsRequired(false);
        tarea.Property(p=> p.PrioridadTarea);
        tarea.Property(p=> p.FechaCreacion);
        tarea.Ignore(p=> p.Resumen);
        tarea.Property(p=> p.Terminada);
        tarea.HasData(tareasInit);
       });
    }
}