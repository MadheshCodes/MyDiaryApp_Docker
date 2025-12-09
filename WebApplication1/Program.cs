//using Microsoft.EntityFrameworkCore;
//using WebApplication1.Data;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//var app = builder.Build();

//// apply EF Core migrations at startup (safe for single-instance or small projects)
//using (var scope = app.Services.CreateScope())
//{
//    try
//    {
//        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//        db.Database.Migrate();
//    }
//    catch (Exception ex)
//    {
//        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred migrating the database.");
//        throw;
//    }
//}

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Account}/{action=Login}/{id?}");

//app.Run();






using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Determine connection string
string connectionString;

var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
if (!string.IsNullOrEmpty(databaseUrl))
{
    // Convert Render DATABASE_URL to Npgsql connection string
    var pgUri = new Uri(databaseUrl);
    var userInfo = pgUri.UserInfo.Split(':');

    var npgsqlBuilder = new NpgsqlConnectionStringBuilder()
    {
        Host = pgUri.Host,
        Port = pgUri.Port,
        Username = userInfo[0],
        Password = userInfo[1],
        Database = pgUri.AbsolutePath.TrimStart('/'),
        SslMode = SslMode.Require,
        TrustServerCertificate = true
    };

    connectionString = npgsqlBuilder.ToString();
}
else
{
    // Use local connection string
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Apply EF Core migrations at startup (safe for small projects)
using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred migrating the database.");
        throw;
    }
}

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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
