using Microsoft.EntityFrameworkCore;
using PruebaInterRapidisimo.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


// base de datos relacional y en sql server
builder.Services.AddSqlServer<ProjectContext>(builder.Configuration.GetConnectionString("conexionProject"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

app.MapRazorPages();

app.Run();
