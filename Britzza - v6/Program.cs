using Britzza___v6.Interfaces;
using Britzza___v6.Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "mongodb+srv://vandi123:vandiBritzza@cluster0.mjg9q9v.mongodb.net/";
var databaseName = "britzza";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserRepository, UserRepository>(x => new UserRepository(connectionString, databaseName));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>(x => new ClienteRepository(connectionString, databaseName));


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
