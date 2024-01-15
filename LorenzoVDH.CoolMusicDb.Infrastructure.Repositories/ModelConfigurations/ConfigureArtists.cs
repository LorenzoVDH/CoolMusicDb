using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace LorenzoVDH.CoolMusicDb.Infrastructure.Repositories
{
    public static class ConfigureArtists
    {
        public static void ConfigureArtistsProperties(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .Property(e => e.CountryCode)
                .HasColumnType("CHAR(2)");
        }
    }
}
