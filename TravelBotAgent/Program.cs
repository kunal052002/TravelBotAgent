using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using TravelBotAgent.Interface;
using TravelBotAgent.Models;
using TravelBotAgent.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TravelBotNewContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));
builder.Services.AddScoped<IProcessingIncomingMessage, ProcessingIncomingMessage>();
builder.Services.AddScoped<IPrepareOutGoingDtos, PrepareOutGoingDtos>();
builder.Services.AddScoped<ISendMessage, SendMessage>();
builder.Services.AddScoped<ICreatePDF,  CreatePDF>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Doc")),
    RequestPath = "/Doc"
});

app.Run();
