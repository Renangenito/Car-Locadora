using ProjetoCarLocadora.Front.Servico;
using ProjetoCarLocadora.Models.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IApiToken, ApiToken>();

builder.Services.Configure<DadosBase>(builder.Configuration.GetSection("DadosBase"));
builder.Services.AddSingleton<LoginRespostaModel>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
