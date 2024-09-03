using HotelManagementSystem.Data;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Register DapperContext and UserRepository
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection("Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;User ID=interns;Password=Wel#123@Team;"));
builder.Services.AddScoped<UserRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
