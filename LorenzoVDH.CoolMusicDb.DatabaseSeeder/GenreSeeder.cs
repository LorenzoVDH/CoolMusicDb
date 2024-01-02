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
                CountryCodes = new() { "US", "GB" },
                SpotifyTrackPreviewId = "7cv9zyMZRbWfOh2sAcleYL",
                SubGenres = new List<Genre>(){
                    new Genre()
                    {
                        Name = "Classic Rock",
                        DateOfOrigin = new DateOnly(1960, 1, 1),
                        Description = "A radio format which developed from the album-oriented rock (AOR) format.",
                        CountryCodes = new(){"US", "GB"},
                        SpotifyTrackPreviewId = "6H3kDe7CGoWYBabAeVWGiD",
                        SubGenres = new List<Genre>(){
                            new Genre()
                            {
                                Name = "Prog Rock",
                                DateOfOrigin = new DateOnly(1970, 1, 1),
                                Description = "A genre that combines rock music with classical and other forms of music.",
                                CountryCodes = new(){"US", "GB"},
                                SpotifyTrackPreviewId = "0D3Ra0iqmNHaLqJsASTEaP",
                            },
                            new Genre()
                            {
                                Name = "Southern Rock",
                                DateOfOrigin = new DateOnly(1970, 1, 1),
                                CountryCodes = new(){"US"},
                                Description = "A subgenre of rock that developed in the Southern United States.",
                                SpotifyTrackPreviewId = "5EWPGh7jbTNO2wakv8LjUI",
                            }
                        }
                    },
                    new Genre()
                    {
                        Name = "Punk Rock",
                        DateOfOrigin = new DateOnly(1970, 1, 1),
                        Description = "A genre characterized by a fast tempo, short songs, and stripped-down instrumentation.",
                        CountryCodes = new(){"GB"},
                        SpotifyTrackPreviewId = "5moTxUGPZXgGmosl4rIELm",
                        SubGenres = new List<Genre>(){
                            new Genre()
                            {
                                Name = "Hardcore Punk",
                                DateOfOrigin = new DateOnly(1980, 1, 1),
                                Description = "A subgenre of punk rock known for its fast tempo, short songs, and abrasive sound.",
                                CountryCodes = new(){"GB"},
                                SpotifyTrackPreviewId = "0YnP5BtP6lTwQV8gLOzaov",
                            },
                            new Genre()
                            {
                                Name = "Pop Punk",
                                DateOfOrigin = new DateOnly(1990, 1, 1),
                                Description = "A subgenre that combines elements of punk rock with pop music.",
                                CountryCodes = new(){"US"},
                                SpotifyTrackPreviewId = "78pHMOI9qUWonIMySjO3XY",
                            }
                        }
                    }
                }
            }
        );
    }
}
