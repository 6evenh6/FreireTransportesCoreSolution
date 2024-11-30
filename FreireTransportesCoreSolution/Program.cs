using FreireTransportesCoreSolution.Models;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona a connection string ao contexto do DbContext
builder.Services.AddSingleton<IDbConnection>((sp) => 
new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar o repositório e o serviço
builder.Services.AddScoped<ClienteRepository>(); 
builder.Services.AddScoped<ClienteService>();


// Adicionar suporte a MVC e Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true);



// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors("AllowAllOrigins");

// Configurar rotas para Razor Pages e MVC


//app.MapControllerRoute(
//    name: "Alterar", 
//    pattern: "Cliente/Alterar/{id}", 
//    defaults: new { controller = "Cliente", action = "Alterar" });

//app.MapControllerRoute(
//    name: "Details",
//    pattern: "Cliente/Details",
//    defaults: new { controller = "Cliente", action = "Details" });

app.MapControllerRoute(name: "Cliente", pattern: "{controller=Cliente}/{action=Cliente}");
app.MapControllerRoute(name: "ListarClientes", pattern: "{controller=Cliente}/{action=ListarClientes}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
