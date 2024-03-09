using Auctions.Data;
using Auctions.Data.Repositories.Bids;
using Auctions.Data.Repositories.Comments;
using Auctions.Data.Repositories.Listings;
using Auctions.Services.Bids;
using Auctions.Services.Comments;
using Auctions.Services.Listings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Build a config object using env vars and JSON providers.
IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextPool<DataContext>(options => 
    options.UseSqlServer(connectionString));

//Repositories
builder.Services.AddScoped<IListingsRepository,ListingsRepository>();
builder.Services.AddScoped<ICommentsRepository,CommentsRepository>();
builder.Services.AddScoped<IBidsRepository,BidsRepository>();

//Services
builder.Services.AddScoped<IListingsService,ListingsService>();
builder.Services.AddScoped<ICommentsService,CommentsService>();
builder.Services.AddScoped<IBidsService,BidsService>();

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
