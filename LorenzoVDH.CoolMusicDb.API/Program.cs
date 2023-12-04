using LorenzoVDH.CoolMusicDb.API.AutoMapperProfiles;
using LorenzoVDH.CoolMusicDb.Application;
using LorenzoVDH.CoolMusicDb.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DevConnection");

builder.Services.AddDbContext<CoolMusicDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date",
        Example = new OpenApiString("2022-01-01")
    })
);
builder.Services.AddAutoMapper(typeof(ArtistAutoMapperProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(
        policy =>
        {
            policy
                .SetIsOriginAllowed(origin => true)
                .WithOrigins("http://localhost:3001")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    )
);

//Projects 
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
