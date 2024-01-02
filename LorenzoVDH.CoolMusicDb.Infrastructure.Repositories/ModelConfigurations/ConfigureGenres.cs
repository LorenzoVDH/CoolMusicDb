using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace LorenzoVDH.CoolMusicDb.Infrastructure.Repositories.ModelConfigurations;

public static class ConfigureGenres
{
    public static void ConfigureGenresProperties(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>()
            .HasMany(g => g.PopularArtists)
            .WithMany()
            .UsingEntity(j => j.ToTable("GenrePopularArtists"));

        modelBuilder.Entity<Genre>()
            .HasMany(pg => pg.SubGenres)
            .WithMany(cg => cg.ParentGenres)
            .UsingEntity(j => j.ToTable("GenreGenre"));
    }
}
