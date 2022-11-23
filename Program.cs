using test_proj_843823.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using test_proj_843823.Data.Entities;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(cfg=>cfg.SerializerSettings.ReferenceLoopHandling= Newtonsoft.Json.ReferenceLoopHandling.Ignore); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ShopDbContext>();
builder.Services.AddTransient<ClothesDataSeeder>();
builder.Services.AddIdentity<ShopUser , IdentityRole>(cfg =>
{
    cfg.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ShopDbContext>();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IClothesRepository, ClothesRepository>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAuthentication().AddCookie().AddJwtBearer(
//    cfg =>
//{
//    cfg.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = builder.Configuration["Token:Issuer"]
//    }
//}
);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    if (args.Length > 0 && args[0].ToLower() == "/seed")
    {
        RunSeeding(app);
        return;
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();



void RunSeeding(IHost host)
{
    var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopeFactory.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetService<ClothesDataSeeder>();
        seeder.SeedAsync().Wait();
    }
}