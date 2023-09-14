using AutoMapper;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.Services.Implementations.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Contracts.Token;
using MediatR;
using NetDevPack.Mediator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = new MapperConfiguration(cfg =>
{

});

builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<IMediaService, MediaService>();
builder.Services.AddTransient<IMediator, Mediator>();
builder.Services.AddTransient<IMediaRepository, IMediaRepository>();
//builder.Services.AddTransient<IRequestTokenRepository, RequestTokenRepository>();
builder.Services.AddTransient<IMediatorHandler, MediatorHandler>();
builder.Services.AddSingleton<IMapper>(configuration.CreateMapper());

builder.Services.AddCors(options =>
{
    options.AddPolicy("my-cors",
                          policy =>
                          {
                              policy
                              .AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                          });
});

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

app.Run();
public partial class Program {}
