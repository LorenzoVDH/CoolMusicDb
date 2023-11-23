using LorenzoVDH.CoolMusicDb.API.AutoMapperProfiles;
using LorenzoVDH.CoolMusicDb.API.DTOs;
using LorenzoVDH.CoolMusicDb.Application;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.Infrastructure.Repositories;
using LorenzoVDH.CoolMusicDb.Infrastructure.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DevConnection"); 

builder.Services.AddDbContext<CoolMusicDbContext>( options => options.UseNpgsql(connectionString) );
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ArtistAutoMapperProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));

//Projects 
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

//Repositories
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();


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
