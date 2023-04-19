using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Repository;
using Microsoft.EntityFrameworkCore;
using static arabiquantum.Data.seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPostRepository, PostRepo>();
builder.Services.AddScoped<ICommentRepository, CommentRepo>();


string _GetConnStringName = builder.Configuration.GetConnectionString("DefaultConnectionMySQL");

builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseMySQL(connectionString: _GetConnStringName));


var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    //await Seed.SeedUsersAndRolesAsync(app);
    Seed.SeedData(app);
}


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
