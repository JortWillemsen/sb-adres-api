using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SBAddressAPI.Models;
using SBAddressAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddDbContext<AddressContext>(o => 
    o.UseSqlite("Data source=address.db"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
