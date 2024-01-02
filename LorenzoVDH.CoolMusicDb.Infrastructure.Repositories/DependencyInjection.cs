using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.Infrastructure.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LorenzoVDH.CoolMusicDb.Infrastructure.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            return services;
        }
    }
}
