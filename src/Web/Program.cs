using Fiap.UI.Escola.Web.Abstractions;
using Fiap.UI.Escola.Web.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient(configuration["ApiSettings:Name"]!, client =>
{
    client.BaseAddress = new Uri(configuration["ApiSettings:Uri"]!);
});

builder.Services
    .AddScoped<ITurmaService, TurmaService>()
    .AddScoped<IAlunoService, AlunoService>();

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
