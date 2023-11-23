using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using LorenzoVDH.CoolMusicDb.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Begin Seeding...");

var dbContextOptions = new DbContextOptionsBuilder<CoolMusicDbContext>()
    .UseNpgsql("Server=localhost;Port=5432;Database=CoolMusicDb;User Id=postgres;Password=easilyhackablepassword;")
    .Options; 
using var dbContext = new CoolMusicDbContext(dbContextOptions);

//Remove all artists so we start with a clean test database 
var allArtists = dbContext.Artists.ToList();
dbContext.Artists.RemoveRange(allArtists);

//Seed the artists with their albums 
dbContext.Artists.Add(
    new Artist("Taylor Swift")
    {
        FirstName = "Taylor",
        LastName = "Swift", 
        Description = "Taylor Alison Swift is an American singer-songwriter. Recognized for her songwriting, musical versatility, " + 
                      "artistic reinventions, and influence on the music industry, she is a prominent cultural figure of the 21st century.", 
        DateOfBirth = new DateOnly(1989,12,13),
        Albums = new List<Album>() {
            new Album() { ReleaseDate = new DateOnly(2006, 10, 24), Name = "Taylor Swift",  URL = "https://example.com/taylorswift" },
            new Album() { ReleaseDate = new DateOnly(2008, 11, 11),   Name = "Fearless",  URL = "https://example.com/fearless" },
            new Album() { ReleaseDate = new DateOnly(2010, 10, 25), Name = "Speak Now",  URL = "https://example.com/speaknow" },
        }
    });

dbContext.Artists.Add(
    new Artist("Ed Sheeran")
    {
        FirstName = "Ed",
        LastName = "Sheeran", 
        Description = "Edward Christopher Sheeran MBE is an English singer-songwriter. Born in Halifax, West Yorkshire, and raised " + 
                      "in Framlingham, Suffolk, he began writing songs around the age of eleven. In early 2011, Sheeran independently " + 
                      "released the extended play No. 5 Collaborations Project. He signed with Asylum Records the same year.",
        DateOfBirth = new DateOnly(1991, 2, 17),
        Albums = new List<Album>() {
            new Album() { ReleaseDate = new DateOnly(2011, 9, 9), Name = "+",  URL = "https://example.com/edsheeranplus" },
            new Album() { ReleaseDate = new DateOnly(2014, 6, 23), Name = "x",  URL = "https://example.com/edsheeranx" },
            new Album() { ReleaseDate = new DateOnly(2017, 3, 3), Name = "÷",  URL = "https://example.com/edsheerandivide" },
        }
    });

dbContext.Artists.Add(
    new Artist("Beyoncé")
    {
        FirstName = "Beyoncé",
        LastName = "Knowles", 
        Description = "Beyoncé Giselle Knowles-Carter is an American singer, songwriter and businesswoman. Known as \"Queen Bey\"," + 
                      "she has been recognized for her boundary-pushing artistry, vocals, and performances. Named one of the greatest " + 
                      "singers of all time by Rolling Stone, her contributions to music and visual media and her concert performances have " + 
                      "led her to become a prominent cultural icon of the 21st century.",
        DateOfBirth = new DateOnly(1981, 9, 4),
        Albums = new List<Album>() {
            new Album() { ReleaseDate = new DateOnly(2003, 6, 24) , Name = "Dangerously In Love",  URL = "https://example.com/beyonce-dangerouslyinlove" },
            new Album() { ReleaseDate = new DateOnly(2008, 11, 18), Name = "I Am... Sasha Fierce",  URL = "https://example.com/beyonce-iamsashafierce" },
            new Album() { ReleaseDate = new DateOnly(2013, 12, 13), Name = "Beyoncé",  URL = "https://example.com/beyonce-beyonce" },
        }
    });

dbContext.Artists.Add(
    new Artist("Adele")
    {
        FirstName = "Adele",
        LastName = "Laurie Blue Adkins", 
        Description = "Adele Laurie Blue Adkins, known mononymously as Adele, is an English singer-songwriter. She is known for her mezzo-soprano" + 
                      "vocals and sentimental songwriting. Adele has received numerous accolades including 16 Grammy Awards, 12 Brit Awards (including " + 
                      "three for British Album of the Year), an Academy Award, a Primetime Emmy Award, and a Golden Globe Award.",
        DateOfBirth = new DateOnly(1988, 5, 5),
        Albums = new List<Album>() {
            new Album() { ReleaseDate = new DateOnly(2008, 1, 28) , Name = "19",  URL = "https://example.com/adele-19" },
            new Album() { ReleaseDate = new DateOnly(2011, 2, 22) , Name = "21",  URL = "https://example.com/adele-21" },
            new Album() { ReleaseDate = new DateOnly(2015, 11, 20), Name = "25",  URL = "https://example.com/adele-25" },
        }
    });

dbContext.Artists.Add(
    new Artist("Bruno Mars")
    {
        FirstName = "Peter",
        LastName = "Gene Hernandez", 
        Description = "Peter Gene Hernandez, known professionally as Bruno Mars, is an American singer-songwriter and record producer. " + 
                      "He is known for his stage performances, retro showmanship, and for performing in a wide range of musical styles, " + 
                      "including pop, R&B, funk, soul, reggae, disco, and rock.",
        DateOfBirth = new DateOnly(1985, 9, 8), 
        Albums = new List<Album>() {
            new Album() { ReleaseDate = new DateOnly(2010, 10, 4) , Name = "Doo-Wops & Hooligans",  URL = "https://example.com/brunomars-doowopsandhooligans" },
            new Album() { ReleaseDate = new DateOnly(2012, 12, 7) ,   Name = "Unorthodox Jukebox",  URL = "https://example.com/brunomars-unorthodoxjukebox" },
            new Album() { ReleaseDate = new DateOnly(2016, 11, 18), Name = "24K Magic",  URL = "https://example.com/brunomars-24kmagic" },
        }
    });

dbContext.Artists.Add(
    new Artist("Rihanna")
    {
        FirstName = "Robyn",
        LastName = "Rihanna Fenty", 
        Description = "Robyn Rihanna Fenty is a Barbadian singer, songwriter, businesswoman, and actress. She is widely regarded as one " + 
                      "of the most prominent singers of the 21st century. ",
        DateOfBirth = new DateOnly(1988, 2, 20), 
        Albums = new List<Album>() {
            new Album() { ReleaseDate = new DateOnly(2005, 8, 30), Name = "Music of the Sun",  URL = "https://example.com/rihanna-musicofthesun" },
            new Album() { ReleaseDate = new DateOnly(2007, 6, 5) ,   Name = "Good Girl Gone Bad",  URL = "https://example.com/rihanna-goodgirlgonebad" },
            new Album() { ReleaseDate = new DateOnly(2016, 1, 28), Name = "Anti",  URL = "https://example.com/rihanna-anti" },
        }
    });


dbContext.SaveChanges();

Console.WriteLine("Seeding ended!"); 
