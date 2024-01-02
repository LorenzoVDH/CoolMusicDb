using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using LorenzoVDH.CoolMusicDb.Infrastructure.Repositories.ModelConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LorenzoVDH.CoolMusicDb.Infrastructure.Repositories
{
    public class CoolMusicDbContext : DbContext
    {
        public CoolMusicDbContext() { }
        public CoolMusicDbContext(DbContextOptions<CoolMusicDbContext> options) : base(options) { }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeding is done using the DatabaseSeeder Project
            modelBuilder.ConfigureArtistsProperties();
            modelBuilder.ConfigureGenresProperties();

            base.OnModelCreating(modelBuilder);
        }
    }
}
