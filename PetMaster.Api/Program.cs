using PetMaster.Api.Enpoints;
using PetMaster.Api.Configuration;
using PetMaster.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.AddResponsibleEnpoints();
app.AddProductEnpoints();
app.AddServiceEnpoints();
app.AddPetEnpoints();
app.AddUserEnpoints();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PetMasterContext>();
    var creator = db.Database.GetInfrastructure().GetService<IRelationalDatabaseCreator>() as RelationalDatabaseCreator;
    if (!creator.Exists())
    {
        db.Database.Migrate();
    }
}

app.Run();