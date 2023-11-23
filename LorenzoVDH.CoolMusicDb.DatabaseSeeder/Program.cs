using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using LorenzoVDH.CoolMusicDb.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Begin Seeding...");

var dbContextOptions = new DbContextOptionsBuilder<CoolMusicDbContext>()
    .UseNpgsql("Server=localhost;Port=5432;Database=CoolMusicDb;User Id=postgres;Password=easilyhackablepassword;")
    .Options; 
using var dbContext = new CoolMusicDbContext(dbContextOptions);

dbContext.Artists.Add(
    new Artist("Taylor", "Swift")
    {
        Pseudonym = "T-Swizzle",
        Albums = new List<Album>() {
            new Album() { ReleaseDate = new DateTime(2006, 10, 24).ToUniversalTime(), Name = "Taylor Swift",  URL = "https://example.com/taylorswift" },
            new Album() { ReleaseDate = new DateTime(2008, 11, 11).ToUniversalTime(),   Name = "Fearless",  URL = "https://example.com/fearless" },
            new Album() { ReleaseDate = new DateTime(2010, 10, 25).ToUniversalTime(), Name = "Speak Now",  URL = "https://example.com/speaknow" },
        }
    });

dbContext.Artists.Add(
    new Artist("Ed", "Sheeran")
    {
        Pseudonym = "Ginger Jesus",
        Albums = new List<Album>() {
            new Album() { ReleaseDate = new DateTime(2011, 9, 9).ToUniversalTime(), Name = "+",  URL = "https://example.com/edsheeranplus" },
            new Album() { ReleaseDate = new DateTime(2014, 6, 23).ToUniversalTime(),   Name = "x",  URL = "https://example.com/edsheeranx" },
            new Album() { ReleaseDate = new DateTime(2017, 3, 3).ToUniversalTime(), Name = "÷",  URL = "https://example.com/edsheerandivide" },
        }
    });

dbContext.Artists.Add(
    new Artist("Beyoncé", "Knowles")
    {
        Pseudonym = "Queen Bey",
        Albums = new List<Album>() {
            new Album() { ReleaseDate = new DateTime(2003, 6, 24).ToUniversalTime(), Name = "Dangerously In Love",  URL = "https://example.com/beyonce-dangerouslyinlove" },
            new Album() { ReleaseDate = new DateTime(2008, 11, 18).ToUniversalTime(),   Name = "I Am... Sasha Fierce",  URL = "https://example.com/beyonce-iamsashafierce" },
            new Album() { ReleaseDate = new DateTime(2013, 12, 13).ToUniversalTime(), Name = "Beyoncé",  URL = "https://example.com/beyonce-beyonce" },
        }
    });

dbContext.Artists.Add(
    new Artist("Adele")
    {
        Pseudonym = "The British Songbird",
        Albums = new List<Album>() {
            new Album() { ReleaseDate = new DateTime(2008, 1, 28).ToUniversalTime(), Name = "19",  URL = "https://example.com/adele-19" },
            new Album() { ReleaseDate = new DateTime(2011, 2, 22).ToUniversalTime(),   Name = "21",  URL = "https://example.com/adele-21" },
            new Album() { ReleaseDate = new DateTime(2015, 11, 20).ToUniversalTime(), Name = "25",  URL = "https://example.com/adele-25" },
        }
    });

dbContext.Artists.Add(
    new Artist("Bruno", "Mars")
    {
        Pseudonym = "The Smeezingtons",
        Albums = new List<Album>() {
            new Album() { ReleaseDate = new DateTime(2010, 10, 4).ToUniversalTime(), Name = "Doo-Wops & Hooligans",  URL = "https://example.com/brunomars-doowopsandhooligans" },
            new Album() { ReleaseDate = new DateTime(2012, 12, 7).ToUniversalTime(),   Name = "Unorthodox Jukebox",  URL = "https://example.com/brunomars-unorthodoxjukebox" },
            new Album() { ReleaseDate = new DateTime(2016, 11, 18).ToUniversalTime(), Name = "24K Magic",  URL = "https://example.com/brunomars-24kmagic" },
        }
    });

dbContext.Artists.Add(
    new Artist("Rihanna")
    {
        Pseudonym = "Bad Gal Riri",
        Albums = new List<Album>() {
            new Album() { ReleaseDate = new DateTime(2005, 8, 30).ToUniversalTime(), Name = "Music of the Sun",  URL = "https://example.com/rihanna-musicofthesun" },
            new Album() { ReleaseDate = new DateTime(2007, 6, 5).ToUniversalTime(),   Name = "Good Girl Gone Bad",  URL = "https://example.com/rihanna-goodgirlgonebad" },
            new Album() { ReleaseDate = new DateTime(2016, 1, 28).ToUniversalTime(), Name = "Anti",  URL = "https://example.com/rihanna-anti" },
        }
    });


dbContext.SaveChanges();

Console.WriteLine("Seeding ended!"); 
