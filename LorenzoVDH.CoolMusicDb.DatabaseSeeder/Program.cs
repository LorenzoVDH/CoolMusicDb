using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using LorenzoVDH.CoolMusicDb.DatabaseSeeder;
using LorenzoVDH.CoolMusicDb.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Begin Seeding...");

var dbContextOptions = new DbContextOptionsBuilder<CoolMusicDbContext>()
    .UseNpgsql("Server=localhost;Port=5432;Database=CoolMusicDb;User Id=postgres;Password=easilyhackablepassword;")
    .Options;
using var dbContext = new CoolMusicDbContext(dbContextOptions);

ArtistSeeder.SeedArtistsWithAlbums(dbContext);
GenreSeeder.SeedGenresWithChildren(dbContext);

dbContext.SaveChanges();

Console.WriteLine("Seeding ended!");
