using Restaurant.Infrastructure.Extensions;
using Restaurant.Infrastructure.Seeders;
using Restaurant.Application.Extensions;
using Serilog;
using Serilog.Events;
using Restaurant.API.Middlewares;
using Restaurant.API.RequestsTimeLoggingMiddleware;
using Restaurant.Domain;
using Microsoft.OpenApi.Models;
using Restaurant.API.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

//Seeding data 
var scope = app.Services.CreateScope(); //creating service scope
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>(); //required service
await seeder.Seed(); //seed it 

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();
// Configure the HTTP request pipeline.
app.UseSerilogRequestLogging();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.MapIdentityApi<User>();
app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();
    

app.UseAuthorization();

app.MapControllers();

app.Run();
