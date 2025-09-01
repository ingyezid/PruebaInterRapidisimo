using Microsoft.EntityFrameworkCore;
using PruebaInterRapidisimo.DataContext;
using PruebaInterRapidisimo.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();


// base de datos relacional y en sql server
builder.Services.AddSqlServer<ProjectContext>(builder.Configuration.GetConnectionString("conexionProject"));

// agregando lo servicios
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<IEstudianteMateriaService, EstudianteMateriaService>();

var app = builder.Build();

// Configuración del pipeline de middlewares
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Para que se actualice la base de datos tan pronto se lanza o dice run sin abrir el navegador
using (var context = new ProjectContext(app.Configuration))
{
    context.Database.Migrate();
    DataSeeder.Seed(context);    
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Definir la ruta por defecto en MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
