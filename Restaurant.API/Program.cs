using Restaurant.Infrastructure.Extensions;
using Restaurant.Infrastructure.Seeders;
using Restaurant.Application.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

//Seeding data 
var scope = app.Services.CreateScope(); //creating service scope
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>(); //required service
await seeder.Seed(); //seed it 


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
