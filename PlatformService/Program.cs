using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();

builder.Services.AddAutoMapper(typeof(Platform));

//var connectionString = builder.Configuration.GetConnectionString("MyWebApiConection");
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseNpgsql(connectionString));


builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));

builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

Console.WriteLine($"Command Service EndPoint :{builder.Configuration["CommandService"]}");


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



//Console.WriteLine("Command Service EndPoint :");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
