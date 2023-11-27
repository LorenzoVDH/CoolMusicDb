using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using LorenzoVDH.CoolMusicDb.Infrastructure.Repositories;

namespace LorenzoVDH.CoolMusicDb.DatabaseSeeder;

public static class GenreSeeder
{
    public static void SeedGenresWithChildren(CoolMusicDbContext dbContext)
    {
        dbContext.Genres.Add(
            new Genre()
            {
                Name = "Rock",
                DateOfOrigin = new DateOnly(1950, 1, 1),
                Description = "A genre of popular music that originated as \"rock and roll\" in the United States in the 1950s.",
                SubGenres = new List<Genre>(){
                    new Genre()
                    {
                        Name = "Classic Rock",
                        DateOfOrigin = new DateOnly(1960, 1, 1),
                        Description = "A radio format which developed from the album-oriented rock (AOR) format.",
                        SubGenres = new List<Genre>(){
                            new Genre()
                            {
                                Name = "Prog Rock",
                                DateOfOrigin = new DateOnly(1970, 1, 1),
                                Description = "A genre that combines rock music with classical and other forms of music.",
                            },
                            new Genre()
                            {
                                Name = "Southern Rock",
                                DateOfOrigin = new DateOnly(1970, 1, 1),
                                Description = "A subgenre of rock that developed in the Southern United States.",
                            }
                        }
                    },
                    new Genre()
                    {
                        Name = "Punk Rock",
                        DateOfOrigin = new DateOnly(1970, 1, 1),
                        Description = "A genre characterized by a fast tempo, short songs, and stripped-down instrumentation.",
                        SubGenres = new List<Genre>(){
                            new Genre()
                            {
                                Name = "Hardcore Punk",
                                DateOfOrigin = new DateOnly(1980, 1, 1),
                                Description = "A subgenre of punk rock known for its fast tempo, short songs, and abrasive sound.",
                            },
                            new Genre()
                            {
                                Name = "Pop Punk",
                                DateOfOrigin = new DateOnly(1990, 1, 1),
                                Description = "A subgenre that combines elements of punk rock with pop music.",
                            }
                        }
                    }
                }
            }
        );
    }
}
