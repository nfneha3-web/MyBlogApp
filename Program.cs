using BranchApp.Application;
using BranchApp.Application.Command;
using BranchApp.Application.Mappings;

using BranchApp.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Cfg;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped(factory =>
{
    var sessionFactory = factory.GetRequiredService<ISessionFactory>();
    return sessionFactory.OpenSession();
});
builder.Services.AddSingleton(factory =>
{
    return NHibernateHelper.CreateSessionFactory(builder.Configuration);
});

builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddMediatR(config =>
{
    
    config.RegisterServicesFromAssemblyContaining<CreateBranchCommand>();
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateBranchCommandValidator>();
builder.Services.AddAutoMapper(typeof(BranchProfile)); // Or typeof(Program)
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
